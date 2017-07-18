using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcAgenda.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcAgendaContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcAgendaContext>>()))
            {
                if (context.Agenda.Any())
                {
                    return;
                }

                context.Agenda.AddRange(
                     new Agenda
                     {
                         ClassName = "Introduction to the Doctrine and Covenants and Church History",
                         ReleaseDate = DateTime.Parse("2017-1-1"),
                         HymnName = "I Am a Child of God",
                         FirstPrayer = "Lizandro Conterini Coelho",
                         LastPrayer = "Regiane Silva Simão Coelho"
                     }
                );
                context.SaveChanges();
            }
        }
    }
}