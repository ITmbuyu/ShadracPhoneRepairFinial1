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
    public class DeviceDescriptionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeviceDescriptionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DeviceDescriptions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DeviceDescriptions.Include(d => d.Brand);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DeviceDescriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceDescription = await _context.DeviceDescriptions
                .Include(d => d.Brand)
                .FirstOrDefaultAsync(m => m.DeviceDescriptionId == id);
            if (deviceDescription == null)
            {
                return NotFound();
            }

            return View(deviceDescription);
        }

        // GET: DeviceDescriptions/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName");
            return View();
        }

        // POST: DeviceDescriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeviceDescriptionId,BrandId,DeviceName")] DeviceDescription deviceDescription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deviceDescription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName", deviceDescription.BrandId);
            return View(deviceDescription);
        }

        // GET: DeviceDescriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceDescription = await _context.DeviceDescriptions.FindAsync(id);
            if (deviceDescription == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName", deviceDescription.BrandId);
            return View(deviceDescription);
        }

        // POST: DeviceDescriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeviceDescriptionId,BrandId,DeviceName")] DeviceDescription deviceDescription)
        {
            if (id != deviceDescription.DeviceDescriptionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deviceDescription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeviceDescriptionExists(deviceDescription.DeviceDescriptionId))
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
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName", deviceDescription.BrandId);
            return View(deviceDescription);
        }

        // GET: DeviceDescriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceDescription = await _context.DeviceDescriptions
                .Include(d => d.Brand)
                .FirstOrDefaultAsync(m => m.DeviceDescriptionId == id);
            if (deviceDescription == null)
            {
                return NotFound();
            }

            return View(deviceDescription);
        }

        // POST: DeviceDescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deviceDescription = await _context.DeviceDescriptions.FindAsync(id);
            _context.DeviceDescriptions.Remove(deviceDescription);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceDescriptionExists(int id)
        {
            return _context.DeviceDescriptions.Any(e => e.DeviceDescriptionId == id);
        }
    }
}
