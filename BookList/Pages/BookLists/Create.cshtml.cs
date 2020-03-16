using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookList.Pages.BookLists
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _db;

        public CreateModel(AppDbContext db)
        {
            this._db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
               await _db.AddAsync(Book);
               await _db.SaveChangesAsync();
                return RedirectToPage("index");
            }
            else
            {
                return Page();
            }
        }
    }
}
