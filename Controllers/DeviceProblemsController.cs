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
    public class DeviceProblemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeviceProblemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DeviceProblems
        public async Task<IActionResult> Index()
        {
            return View(await _context.DeviceProblems.ToListAsync());
        }

        // GET: DeviceProblems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceProblem = await _context.DeviceProblems
                .FirstOrDefaultAsync(m => m.DeviceProblemId == id);
            if (deviceProblem == null)
            {
                return NotFound();
            }

            return View(deviceProblem);
        }

        // GET: DeviceProblems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeviceProblems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeviceProblemId,Description,CostOfP")] DeviceProblem deviceProblem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deviceProblem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deviceProblem);
        }

        // GET: DeviceProblems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceProblem = await _context.DeviceProblems.FindAsync(id);
            if (deviceProblem == null)
            {
                return NotFound();
            }
            return View(deviceProblem);
        }

        // POST: DeviceProblems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeviceProblemId,Description,CostOfP")] DeviceProblem deviceProblem)
        {
            if (id != deviceProblem.DeviceProblemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deviceProblem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeviceProblemExists(deviceProblem.DeviceProblemId))
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
            return View(deviceProblem);
        }

        // GET: DeviceProblems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceProblem = await _context.DeviceProblems
                .FirstOrDefaultAsync(m => m.DeviceProblemId == id);
            if (deviceProblem == null)
            {
                return NotFound();
            }

            return View(deviceProblem);
        }

        // POST: DeviceProblems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deviceProblem = await _context.DeviceProblems.FindAsync(id);
            _context.DeviceProblems.Remove(deviceProblem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceProblemExists(int id)
        {
            return _context.DeviceProblems.Any(e => e.DeviceProblemId == id);
        }
    }
}
