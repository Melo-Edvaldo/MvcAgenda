using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MvcAgenda.Models
{
    public class MvcAgendaContext : DbContext
    {
        public MvcAgendaContext (DbContextOptions<MvcAgendaContext> options)
            : base(options)
        {
        }

        public DbSet<MvcAgenda.Models.Agenda> Agenda { get; set; }
    }
}
