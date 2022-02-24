#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDesk.Data;
using MegaDesk.Models;

namespace MegaDesk.Pages.DeskQuotes
{
    public class IndexModel : PageModel
    {
        private readonly MegaDesk.Data.MegaDeskContext _context;

        public IndexModel(MegaDesk.Data.MegaDeskContext context)
        {
            _context = context;
        }

        // Sorting Functionality
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<DeskQuote> DeskQuote { get;set; }

        // Search Functionality
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchSelection { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            var quotes = from m in _context.DeskQuote
                         select m;

            // Sorting
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            switch (sortOrder)
            {
                case "name_desc":
                    quotes = quotes.OrderByDescending(s => s.FirstName);
                    break;
                case "Date":
                    quotes = quotes.OrderBy(s => s.QuoteDate);
                    break;
                case "date_desc":
                    quotes = quotes.OrderByDescending(s => s.QuoteDate);
                    break;
                default:
                    quotes = quotes.OrderBy(s => s.FirstName);
                    break;
            }

            // Searching
            if (SearchSelection == "FirstName")
            {
                if (!string.IsNullOrEmpty(SearchString))
                {
                    quotes = quotes.Where(s => s.FirstName.Contains(SearchString));
                }
            }
            else if (SearchSelection == "LastName")
            {
                if (!string.IsNullOrEmpty(SearchSelection))
                {
                    quotes = quotes.Where(s => s.LastName.Contains(SearchString));
                }
            }

            DeskQuote = await quotes.ToListAsync();
        }
    }
}
