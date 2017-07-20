using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcAgenda.Models
{
    public class AgendaHymnNameViewModel
    {
        public List<Agenda> agenda;
        public SelectList HymnName;
        public string agendaHymnName { get; set; }
    }
}
