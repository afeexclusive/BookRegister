using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookList.Pages.BookLists
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _db;

        public EditModel(AppDbContext db)
        {
            this._db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task OnGet(int id)
        {
            Book = await _db.Books.FindAsync(id);
        }

        public async Task<IActionResult> OnPost(Book book)
        {
            if (ModelState.IsValid)
            {
                var BookFromDb = _db.Books.Attach(book);
                BookFromDb.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToPage("index");
            }
            return RedirectToPage();
        }
    }
}
