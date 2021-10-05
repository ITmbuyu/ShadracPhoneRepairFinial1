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
    public class PartsCollectionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PartsCollectionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PartsCollections
        public async Task<IActionResult> Index()
        {
            return View(await _context.PartsCollections.ToListAsync());
        }

        // GET: PartsCollections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partsCollection = await _context.PartsCollections
                .FirstOrDefaultAsync(m => m.PartsCollectionId == id);
            if (partsCollection == null)
            {
                return NotFound();
            }

            return View(partsCollection);
        }

        // GET: PartsCollections/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PartsCollections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PartsCollectionId,PartName,Quaunity,Price,Supplier,SupplierAddress")] PartsCollection partsCollection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partsCollection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(partsCollection);
        }

        // GET: PartsCollections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partsCollection = await _context.PartsCollections.FindAsync(id);
            if (partsCollection == null)
            {
                return NotFound();
            }
            return View(partsCollection);
        }

        // POST: PartsCollections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PartsCollectionId,PartName,Quaunity,Price,Supplier,SupplierAddress")] PartsCollection partsCollection)
        {
            if (id != partsCollection.PartsCollectionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partsCollection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartsCollectionExists(partsCollection.PartsCollectionId))
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
            return View(partsCollection);
        }

        // GET: PartsCollections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partsCollection = await _context.PartsCollections
                .FirstOrDefaultAsync(m => m.PartsCollectionId == id);
            if (partsCollection == null)
            {
                return NotFound();
            }

            return View(partsCollection);
        }

        // POST: PartsCollections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partsCollection = await _context.PartsCollections.FindAsync(id);
            _context.PartsCollections.Remove(partsCollection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartsCollectionExists(int id)
        {
            return _context.PartsCollections.Any(e => e.PartsCollectionId == id);
        }
    }
}
