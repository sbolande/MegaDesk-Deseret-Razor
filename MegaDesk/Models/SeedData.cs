using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MegaDesk.Data;
using System;
using System.Linq;
using MegaDesk.Models.Helpers;

namespace MegaDesk.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MegaDeskContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MegaDeskContext>>()))
            {
                if (context.DeskQuote.Any())
                {
                    return;
                }

                var deskQuotes = new List<DeskQuote> {
                    new DeskQuote
                    {
                        Width = 48,
                        Depth = 36,
                        DrawerCount = 7,
                        DesktopMaterial = DesktopMaterial.Rosewood,
                        ProductionDays = 14,
                        FirstName = "Lyla",
                        LastName = "Farrow",
                    },
                    new DeskQuote
                    {
                        Width = 24,
                        Depth = 12,
                        DrawerCount = 1,
                        DesktopMaterial = DesktopMaterial.Laminate,
                        ProductionDays = 5,
                        FirstName = "Safia",
                        LastName = "Lowery",
                    },
                    new DeskQuote
                    {
                        Width = 31,
                        Depth = 17,
                        DrawerCount = 3,
                        DesktopMaterial = DesktopMaterial.Oak,
                        ProductionDays = 5,
                        FirstName = "Rhianna",
                        LastName = "Madden",
                    },
                    new DeskQuote
                    {
                        Width = 25,
                        Depth = 13,
                        DrawerCount = 1,
                        DesktopMaterial = DesktopMaterial.Veneer,
                        ProductionDays = 7,
                        FirstName = "Muhammed",
                        LastName = "Sosa",
                    },
                    new DeskQuote
                    {
                        Width = 43,
                        Depth = 26,
                        DrawerCount = 5,
                        DesktopMaterial = DesktopMaterial.Pine,
                        ProductionDays = 3,
                        FirstName = "Iyla",
                        LastName = "Bourne",
                    },
                    new DeskQuote
                    {
                        Width = 26,
                        Depth = 12,
                        DrawerCount = 2,
                        DesktopMaterial = DesktopMaterial.Rosewood,
                        ProductionDays = 14,
                        FirstName = "Violet",
                        LastName = "Hagan",
                    },
                    new DeskQuote
                    {
                        Width = 26,
                        Depth = 12,
                        DrawerCount = 2,
                        DesktopMaterial = DesktopMaterial.Rosewood,
                        ProductionDays = 5,
                        FirstName = "Violet",
                        LastName = "Hagan",
                    },
                    new DeskQuote
                    {
                        Width = 29,
                        Depth = 17,
                        DrawerCount = 5,
                        DesktopMaterial = DesktopMaterial.Pine,
                        ProductionDays = 3,
                        FirstName = "Henry",
                        LastName = "Weston",
                    }
                };

                foreach(var quote in deskQuotes)
                {
                    quote.Value = QuoteHelper.CalculateQuote(quote);
                }
                context.DeskQuote.AddRange(deskQuotes);
                context.SaveChanges();
            }
        }
    }
}
