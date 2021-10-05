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
    public class ColoursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ColoursController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Colours
        public async Task<IActionResult> Index()
        {
            return View(await _context.Colours.ToListAsync());
        }

        // GET: Colours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colour = await _context.Colours
                .FirstOrDefaultAsync(m => m.ColourId == id);
            if (colour == null)
            {
                return NotFound();
            }

            return View(colour);
        }

        // GET: Colours/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Colours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ColourId,Name")] Colour colour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(colour);
        }

        // GET: Colours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colour = await _context.Colours.FindAsync(id);
            if (colour == null)
            {
                return NotFound();
            }
            return View(colour);
        }

        // POST: Colours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ColourId,Name")] Colour colour)
        {
            if (id != colour.ColourId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColourExists(colour.ColourId))
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
            return View(colour);
        }

        // GET: Colours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colour = await _context.Colours
                .FirstOrDefaultAsync(m => m.ColourId == id);
            if (colour == null)
            {
                return NotFound();
            }

            return View(colour);
        }

        // POST: Colours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var colour = await _context.Colours.FindAsync(id);
            _context.Colours.Remove(colour);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColourExists(int id)
        {
            return _context.Colours.Any(e => e.ColourId == id);
        }
    }
}
