using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookList.Pages.BookLists
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;

        public IndexModel(AppDbContext db)
        {
            this._db = db;
        }

        public IEnumerable<Book> Buks { get; set; }

        public async Task OnGet()
        {
            Buks = await _db.Books.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await _db.Books.FindAsync(id);
            if (book== null)
            {
                return NotFound();
            }

            _db.Books.Remove(book);
            await _db.SaveChangesAsync();

            return RedirectToPage("index");
        }
    }
}
