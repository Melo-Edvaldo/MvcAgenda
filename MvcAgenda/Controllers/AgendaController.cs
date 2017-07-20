using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcAgenda.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace MvcAgenda.Controllers
{
    public class AgendaController : Controller
    {
        private readonly MvcAgendaContext _context;

        public AgendaController(MvcAgendaContext context)
        {
            _context = context;
        }

        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public async Task<IActionResult> Index(string agendaHymnName, string searchString)
        {
            // Use LINQ to get list of hymns name.
            IQueryable<string> HymnNameQuery = from m in _context.Agenda
                                               orderby m.HymnName
                                               select m.HymnName;

            var agenda = from m in _context.Agenda
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                agenda = agenda.Where(s => s.ClassName.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(agendaHymnName))
            {
                agenda = agenda.Where(x => x.HymnName == agendaHymnName);
            }

            var agendaHymnNameVM = new AgendaHymnNameViewModel();
            agendaHymnNameVM.HymnName = new SelectList(await HymnNameQuery.Distinct().ToListAsync());
            agendaHymnNameVM.agenda = await agenda.ToListAsync();

            return View(agendaHymnNameVM);
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        // GET: Agenda/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Agenda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ClassName,ReleaseDate,HymnName,FirstPrayer,LastPrayer")] Agenda agenda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agenda);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(agenda);
        }

        // GET: Agenda/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _context.Agenda.SingleOrDefaultAsync(m => m.ID == id);
            if (agenda == null)
            {
                return NotFound();
            }
            return View(agenda);
        }

        // POST: Agenda/Edit
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ClassName,ReleaseDate,HymnName,FirstPrayer,LastPrayer")] Agenda agenda)
        {
            if (id != agenda.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgendaExists(agenda.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(agenda);
        }

        // GET: Agenda/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _context.Agenda
                .SingleOrDefaultAsync(m => m.ID == id);
            if (agenda == null)
            {
                return NotFound();
            }

            return View(agenda);
        }

        // POST: Agenda/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agenda = await _context.Agenda.SingleOrDefaultAsync(m => m.ID == id);
            _context.Agenda.Remove(agenda);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AgendaExists(int id)
        {
            return _context.Agenda.Any(e => e.ID == id);
        }
    }
}