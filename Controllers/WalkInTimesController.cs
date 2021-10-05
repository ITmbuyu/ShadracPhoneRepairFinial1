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
    public class WalkInTimesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WalkInTimesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WalkInTimes
        public async Task<IActionResult> Index()
        {
            return View(await _context.WalkInTimes.ToListAsync());
        }

        // GET: WalkInTimes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var walkInTimes = await _context.WalkInTimes
                .FirstOrDefaultAsync(m => m.WalkInTimesId == id);
            if (walkInTimes == null)
            {
                return NotFound();
            }

            return View(walkInTimes);
        }

        // GET: WalkInTimes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WalkInTimes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WalkInTimesId,WalkInTime")] WalkInTimes walkInTimes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(walkInTimes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(walkInTimes);
        }

        // GET: WalkInTimes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var walkInTimes = await _context.WalkInTimes.FindAsync(id);
            if (walkInTimes == null)
            {
                return NotFound();
            }
            return View(walkInTimes);
        }

        // POST: WalkInTimes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WalkInTimesId,WalkInTime")] WalkInTimes walkInTimes)
        {
            if (id != walkInTimes.WalkInTimesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(walkInTimes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WalkInTimesExists(walkInTimes.WalkInTimesId))
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
            return View(walkInTimes);
        }

        // GET: WalkInTimes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var walkInTimes = await _context.WalkInTimes
                .FirstOrDefaultAsync(m => m.WalkInTimesId == id);
            if (walkInTimes == null)
            {
                return NotFound();
            }

            return View(walkInTimes);
        }

        // POST: WalkInTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var walkInTimes = await _context.WalkInTimes.FindAsync(id);
            _context.WalkInTimes.Remove(walkInTimes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WalkInTimesExists(int id)
        {
            return _context.WalkInTimes.Any(e => e.WalkInTimesId == id);
        }
    }
}
