using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment.Models;

namespace Assignment.Controllers
{
    public class ProgrammingLanguageController : Controller
    {
        private readonly AssignmentCourseContext _context;

        public ProgrammingLanguageController(AssignmentCourseContext context)
        {
            _context = context;
        }

        // GET: ProgrammingLanguage
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProgrammingLanguages.ToListAsync());
        }

        // GET: ProgrammingLanguage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programmingLanguage = await _context.ProgrammingLanguages
                .FirstOrDefaultAsync(m => m.ID == id);
            if (programmingLanguage == null)
            {
                return NotFound();
            }

            return View(programmingLanguage);
        }

        // GET: ProgrammingLanguage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProgrammingLanguage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Language,Experience")] ProgrammingLanguage programmingLanguage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(programmingLanguage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(programmingLanguage);
        }

        // GET: ProgrammingLanguage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programmingLanguage = await _context.ProgrammingLanguages.FindAsync(id);
            if (programmingLanguage == null)
            {
                return NotFound();
            }
            return View(programmingLanguage);
        }

        // POST: ProgrammingLanguage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Language,Experience")] ProgrammingLanguage programmingLanguage)
        {
            if (id != programmingLanguage.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programmingLanguage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgrammingLanguageExists(programmingLanguage.ID))
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
            return View(programmingLanguage);
        }

        // GET: ProgrammingLanguage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programmingLanguage = await _context.ProgrammingLanguages
                .FirstOrDefaultAsync(m => m.ID == id);
            if (programmingLanguage == null)
            {
                return NotFound();
            }

            return View(programmingLanguage);
        }

        // POST: ProgrammingLanguage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var programmingLanguage = await _context.ProgrammingLanguages.FindAsync(id);
            _context.ProgrammingLanguages.Remove(programmingLanguage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgrammingLanguageExists(int id)
        {
            return _context.ProgrammingLanguages.Any(e => e.ID == id);
        }
    }
}
