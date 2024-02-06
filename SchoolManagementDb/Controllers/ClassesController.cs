using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagementDb.Data;
using SchoolManagementDb.Models;

namespace SchoolManagementDb.Controllers
{
    public class ClassesController : Controller
    {
        private readonly ClassesDbContext _context;

        public ClassesController(ClassesDbContext context)
        {
            _context = context;
        }

        // GET: Classes
        public async Task<IActionResult> Index()
        {
              return _context.Classes != null ? 
                          View(await _context.Classes.ToListAsync()) :
                          Problem("Entity set 'ClassesDbContext.Classes'  is null.");
        }

        // GET: Classes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Classes == null)
            {
                return NotFound();
            }

            var classes = await _context.Classes
                .FirstOrDefaultAsync(m => m.Standard == id);
            if (classes == null)
            {
                return NotFound();
            }

            return View(classes);
        }

        // GET: Classes/Create
        public IActionResult Create()
        {
            return View( new Classes());
        }

        // POST: Classes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Standard,Section")] Classes classes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classes);
        }

        // GET: Classes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Classes == null)
            {
                return NotFound();
            }

            var classes = await _context.Classes.FindAsync(id);
            if (classes == null)
            {
                return NotFound();
            }
            return View(classes);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Standard,Section")] Classes classes)
        {
            if (id != classes.Standard)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassesExists(classes.Standard))
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
            return View(classes);
        }

        // GET: Classes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Classes == null)
            {
                return NotFound();
            }

            var classes = await _context.Classes
                .FirstOrDefaultAsync(m => m.Standard == id);
            if (classes == null)
            {
                return NotFound();
            }

            return View(classes);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Classes == null)
            {
                return Problem("Entity set 'ClassesDbContext.Classes'  is null.");
            }
            var classes = await _context.Classes.FindAsync(id);
            if (classes != null)
            {
                _context.Classes.Remove(classes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassesExists(string id)
        {
          return (_context.Classes?.Any(e => e.Standard == id)).GetValueOrDefault();
        }
    }
}
