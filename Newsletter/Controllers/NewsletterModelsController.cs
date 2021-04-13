using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newsletter.Data;
using Newsletter.Models;

namespace Newsletter.Controllers
{
    public class NewsletterModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NewsletterModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Vorname,Nachname,Email")] NewsletterModel newsletterModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newsletterModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Newsletter), "home");
            }
            return View();
        }

        //private bool NewsletterModelExists(int id)
        //{
        //    return _context.Newsletters.Any(e => e.Id == id);
        //}
    }
}
