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
    public class StoragesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StoragesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Storages
        public async Task<IActionResult> Index()
        {
            return View(await _context.Storage.ToListAsync());
        }

        // GET: Storages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storage = await _context.Storage
                .FirstOrDefaultAsync(m => m.StorageId == id);
            if (storage == null)
            {
                return NotFound();
            }

            return View(storage);
        }

        // GET: Storages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Storages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StorageId,StorageCapacity")] Storage storage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(storage);
        }

        // GET: Storages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storage = await _context.Storage.FindAsync(id);
            if (storage == null)
            {
                return NotFound();
            }
            return View(storage);
        }

        // POST: Storages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StorageId,StorageCapacity")] Storage storage)
        {
            if (id != storage.StorageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StorageExists(storage.StorageId))
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
            return View(storage);
        }

        // GET: Storages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storage = await _context.Storage
                .FirstOrDefaultAsync(m => m.StorageId == id);
            if (storage == null)
            {
                return NotFound();
            }

            return View(storage);
        }

        // POST: Storages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var storage = await _context.Storage.FindAsync(id);
            _context.Storage.Remove(storage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StorageExists(int id)
        {
            return _context.Storage.Any(e => e.StorageId == id);
        }
    }
}
