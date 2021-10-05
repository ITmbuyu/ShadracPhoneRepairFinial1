using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShadracPhoneRepairFinial1.Data;
using ShadracPhoneRepairFinial1.Models;

namespace ShadracPhoneRepairFinial1.Controllers
{
    public class PartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Parts
        public async Task<IActionResult> Index()
        {
            return View(await _context.parts.ToListAsync());
        }

        // GET: Parts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parts = await _context.parts
                .FirstOrDefaultAsync(m => m.PartsId == id);
            if (parts == null)
            {
                return NotFound();
            }

            return View(parts);
        }

        // GET: Parts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PartsId,Part_Name,Part_Cost")] Parts parts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parts);
        }

        // GET: Parts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parts = await _context.parts.FindAsync(id);
            if (parts == null)
            {
                return NotFound();
            }
            return View(parts);
        }

        // POST: Parts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PartsId,Part_Name,Part_Cost")] Parts parts)
        {
            if (id != parts.PartsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartsExists(parts.PartsId))
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
            return View(parts);
        }

        // GET: Parts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parts = await _context.parts
                .FirstOrDefaultAsync(m => m.PartsId == id);
            if (parts == null)
            {
                return NotFound();
            }

            return View(parts);
        }

        // POST: Parts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parts = await _context.parts.FindAsync(id);
            _context.parts.Remove(parts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartsExists(int id)
        {
            return _context.parts.Any(e => e.PartsId == id);
        }
    }
}
