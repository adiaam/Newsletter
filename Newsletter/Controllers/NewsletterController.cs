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
    public class NewsletterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NewsletterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Newsletters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Newsletters.ToListAsync());
        }

        // GET: Newsletter/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsletterModel = await _context.Newsletters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newsletterModel == null)
            {
                return NotFound();
            }

            return View(newsletterModel);
        }

        // GET: Newsletter/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Newsletter/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Vorname,Nachname,Email,Spitzname")] NewsletterModel newsletterModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newsletterModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newsletterModel);
        }

        // GET: Newsletter/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsletterModel = await _context.Newsletters.FindAsync(id);
            if (newsletterModel == null)
            {
                return NotFound();
            }
            return View(newsletterModel);
        }

        // POST: Newsletter/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Vorname,Nachname,Email,Spitzname")] NewsletterModel newsletterModel)
        {
            if (id != newsletterModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newsletterModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsletterModelExists(newsletterModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(newsletterModel);
        }

        // GET: Newsletter/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsletterModel = await _context.Newsletters
                .FirstOrDefaultAsync(m => m.Id == id); // foreach(var m in Newsletters){if(m.Id == id) return m;}
            if (newsletterModel == null)
            {
                return NotFound();
            }

            return View(newsletterModel);
        }

        // POST: Newsletter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newsletterModel = await _context.Newsletters.FindAsync(id);
            _context.Newsletters.Remove(newsletterModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsletterModelExists(int id)
        {
            return _context.Newsletters.Any(e => e.Id == id);
        }
    }
}
