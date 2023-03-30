using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testbook.Model;

namespace testbook.Controllers
{
    public class BookController : Controller
    {
        private readonly BookDbContext _db;

        public BookController(BookDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _db.Book.ToList()});
        }
    }
}
