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
    public class RepairStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RepairStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RepairStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.RepairStatuses.ToListAsync());
        }

        // GET: RepairStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairStatus = await _context.RepairStatuses
                .FirstOrDefaultAsync(m => m.RepairStatusId == id);
            if (repairStatus == null)
            {
                return NotFound();
            }

            return View(repairStatus);
        }

        // GET: RepairStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RepairStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RepairStatusId,Status")] RepairStatus repairStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(repairStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(repairStatus);
        }

        // GET: RepairStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairStatus = await _context.RepairStatuses.FindAsync(id);
            if (repairStatus == null)
            {
                return NotFound();
            }
            return View(repairStatus);
        }

        // POST: RepairStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RepairStatusId,Status")] RepairStatus repairStatus)
        {
            if (id != repairStatus.RepairStatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repairStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepairStatusExists(repairStatus.RepairStatusId))
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
            return View(repairStatus);
        }

        // GET: RepairStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairStatus = await _context.RepairStatuses
                .FirstOrDefaultAsync(m => m.RepairStatusId == id);
            if (repairStatus == null)
            {
                return NotFound();
            }

            return View(repairStatus);
        }

        // POST: RepairStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var repairStatus = await _context.RepairStatuses.FindAsync(id);
            _context.RepairStatuses.Remove(repairStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepairStatusExists(int id)
        {
            return _context.RepairStatuses.Any(e => e.RepairStatusId == id);
        }
    }
}
