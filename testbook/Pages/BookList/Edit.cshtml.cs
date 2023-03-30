using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using testbook.Model;

namespace testbook.Pages.BookList
{
    public class EditModel : PageModel
    {
        private BookDbContext _db;
        public EditModel(BookDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task OnGet(int id)
        {
            Book = await _db.Book.FindAsync(id);
        }

        public async Task<ActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookFromDb = await _db.Book.FindAsync(Book.Id);
                
                BookFromDb.Name = Book.Name;
                BookFromDb.Author = Book.Author;
                BookFromDb.ISBN = Book.ISBN;

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
