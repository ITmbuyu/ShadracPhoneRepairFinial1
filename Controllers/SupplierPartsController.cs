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
    public class SupplierPartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SupplierPartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SupplierParts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.supplierParts.Include(s => s.Parts).Include(s => s.Supplier);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SupplierParts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierPart = await _context.supplierParts
                .Include(s => s.Parts)
                .Include(s => s.Supplier)
                .FirstOrDefaultAsync(m => m.SupplierPartId == id);
            if (supplierPart == null)
            {
                return NotFound();
            }

            return View(supplierPart);
        }

        // GET: SupplierParts/Create
        public IActionResult Create()
        {
            ViewData["PartsId"] = new SelectList(_context.parts, "PartsId", "Part_Name");
            ViewData["SupplierId"] = new SelectList(_context.suppliers, "SupplierId", "Supplier_Name");
            return View();
        }

        // POST: SupplierParts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierPartId,PartsId,SupplierId,PartSupplied_Date,PartSupplied_Quantity")] SupplierPart supplierPart)
        {
            if (ModelState.IsValid)
            {
                //SupplierPart supplierPartt = new SupplierPart();
                //supplierPartt.PartSupplied_Date =  DateTime.Now.ToString();
                //db.supplierParts.Add(supplierPartt);
                //await db.SaveChangesAsync();
                //Parts parts = new Parts();
                //PartsCollection partsCollection = new PartsCollection();
                //var p = db.parts.Where(x => x.PartsId == supplierPart.PartsId);


                supplierPart.PartSupplied_Date = DateTime.Now.ToString();
                _context.supplierParts.Add(supplierPart);
                await _context.SaveChangesAsync();
                Parts parts = new Parts();
                PartsCollection partsCollection = new PartsCollection();
                ////var p = _context.parts.Where(x => x.PartsId == supplierPart.PartsId);
                ////partsCollection.PartName = p.FirstOrDefault().Part_Name;
                partsCollection.PartName = _context.parts.Find(supplierPart.PartsId).Part_Name;
                partsCollection.Quaunity = Convert.ToString(supplierPart.PartSupplied_Quantity);
                partsCollection.Supplier = _context.suppliers.Find(supplierPart.SupplierId).Supplier_Name;
                partsCollection.SupplierAddress = _context.suppliers.Find(supplierPart.SupplierId).Supplier_Address;
                partsCollection.Price = Convert.ToString(parts.Part_Cost * supplierPart.PartSupplied_Quantity);
                _context.PartsCollections.Add(partsCollection);
                _context.Add(supplierPart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PartsId"] = new SelectList(_context.parts, "PartsId", "Part_Name", supplierPart.PartsId);
            ViewData["SupplierId"] = new SelectList(_context.suppliers, "SupplierId", "Supplier_Name", supplierPart.SupplierId);
            return View(supplierPart);
        }

        // GET: SupplierParts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierPart = await _context.supplierParts.FindAsync(id);
            if (supplierPart == null)
            {
                return NotFound();
            }
            ViewData["PartsId"] = new SelectList(_context.parts, "PartsId", "Part_Name", supplierPart.PartsId);
            ViewData["SupplierId"] = new SelectList(_context.suppliers, "SupplierId", "Supplier_Name", supplierPart.SupplierId);
            return View(supplierPart);
        }

        // POST: SupplierParts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplierPartId,PartsId,SupplierId,PartSupplied_Date,PartSupplied_Quantity")] SupplierPart supplierPart)
        {
            if (id != supplierPart.SupplierPartId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplierPart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierPartExists(supplierPart.SupplierPartId))
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
            ViewData["PartsId"] = new SelectList(_context.parts, "PartsId", "Part_Name", supplierPart.PartsId);
            ViewData["SupplierId"] = new SelectList(_context.suppliers, "SupplierId", "Supplier_Name", supplierPart.SupplierId);
            return View(supplierPart);
        }

        // GET: SupplierParts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierPart = await _context.supplierParts
                .Include(s => s.Parts)
                .Include(s => s.Supplier)
                .FirstOrDefaultAsync(m => m.SupplierPartId == id);
            if (supplierPart == null)
            {
                return NotFound();
            }

            return View(supplierPart);
        }

        // POST: SupplierParts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supplierPart = await _context.supplierParts.FindAsync(id);
            _context.supplierParts.Remove(supplierPart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplierPartExists(int id)
        {
            return _context.supplierParts.Any(e => e.SupplierPartId == id);
        }
    }
}
