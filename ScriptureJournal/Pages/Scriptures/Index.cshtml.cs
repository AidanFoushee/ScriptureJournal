using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScriptureJournal.Data;
using ScriptureJournal.Models;

namespace ScriptureJournal.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly ScriptureJournal.Data.ScriptureJournalContext _context;

        public IndexModel(ScriptureJournal.Data.ScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get;set; } = default!;
        public DateTime Currentdate { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of books.
            IQueryable<string> genreQuery = from m in _context.Scripture
                                            orderby m.Book
                                            select m.Book;

            var scriptures = from m in _context.Scripture
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                scriptures = scriptures.Where(s => s.Book.Contains(SearchString));
                
            }

            if (!string.IsNullOrEmpty(SearchNotes))
            {
                scriptures = scriptures.Where(s => s.Notes.Contains(SearchNotes));
                
            }

            if (!string.IsNullOrEmpty(ScriptureBook))
            {
                scriptures = scriptures.Where(x => x.Book == ScriptureBook);
                
            }

            Books = new SelectList(await genreQuery.Distinct().ToListAsync());
            Scripture = await scriptures.ToListAsync();
        }
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Books { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? ScriptureBook { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchNotes {  get; set; }
        public DateTime CurrentDate { get; set; }
    }
}
