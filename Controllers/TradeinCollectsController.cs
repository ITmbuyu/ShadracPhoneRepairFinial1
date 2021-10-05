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
    public class TradeinCollectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TradeinCollectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TradeinCollects
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TradeinCollect.Include(t => t.ApprovalMessages).Include(t => t.CApprovalMessages).Include(t => t.Colour).Include(t => t.DeviceDescription).Include(t => t.Storage);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TradeinCollects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tradeinCollect = await _context.TradeinCollect
                .Include(t => t.ApprovalMessages)
                .Include(t => t.CApprovalMessages)
                .Include(t => t.Colour)
                .Include(t => t.DeviceDescription)
                .Include(t => t.Storage)
                .FirstOrDefaultAsync(m => m.TradeinCollectId == id);
            if (tradeinCollect == null)
            {
                return NotFound();
            }

            return View(tradeinCollect);
        }

        // GET: TradeinCollects/Create
        public IActionResult Create()
        {
            ViewData["ApprovalMessagesId"] = new SelectList(_context.ApprovalMessages, "ApprovalMessagesId", "AMessages");
            ViewData["CApprovalMessagesId"] = new SelectList(_context.CApprovalMessages, "CApprovalMessagesId", "CMessages");
            ViewData["ColourId"] = new SelectList(_context.Colours, "ColourId", "Name");
            ViewData["DeviceDescriptionId"] = new SelectList(_context.DeviceDescriptions, "DeviceDescriptionId", "DeviceName");
            ViewData["StorageId"] = new SelectList(_context.Storage, "StorageId", "StorageCapacity");
            return View();
        }

        // POST: TradeinCollects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TradeinCollectId,TradeinNumber,Brand,DeviceDescriptionId,StorageId,ColourId,IMEI,DeviceCondition,DevicePicture,RequestDateTime,UserId,CApprovalMessagesId,ApprovalMessagesId")] TradeinCollect tradeinCollect)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tradeinCollect);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApprovalMessagesId"] = new SelectList(_context.ApprovalMessages, "ApprovalMessagesId", "AMessages", tradeinCollect.ApprovalMessagesId);
            ViewData["CApprovalMessagesId"] = new SelectList(_context.CApprovalMessages, "CApprovalMessagesId", "CMessages", tradeinCollect.CApprovalMessagesId);
            ViewData["ColourId"] = new SelectList(_context.Colours, "ColourId", "Name", tradeinCollect.ColourId);
            ViewData["DeviceDescriptionId"] = new SelectList(_context.DeviceDescriptions, "DeviceDescriptionId", "DeviceName", tradeinCollect.DeviceDescriptionId);
            ViewData["StorageId"] = new SelectList(_context.Storage, "StorageId", "StorageCapacity", tradeinCollect.StorageId);
            return View(tradeinCollect);
        }

        // GET: TradeinCollects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tradeinCollect = await _context.TradeinCollect.FindAsync(id);
            if (tradeinCollect == null)
            {
                return NotFound();
            }
            ViewData["ApprovalMessagesId"] = new SelectList(_context.ApprovalMessages, "ApprovalMessagesId", "AMessages", tradeinCollect.ApprovalMessagesId);
            ViewData["CApprovalMessagesId"] = new SelectList(_context.CApprovalMessages, "CApprovalMessagesId", "CMessages", tradeinCollect.CApprovalMessagesId);
            ViewData["ColourId"] = new SelectList(_context.Colours, "ColourId", "Name", tradeinCollect.ColourId);
            ViewData["DeviceDescriptionId"] = new SelectList(_context.DeviceDescriptions, "DeviceDescriptionId", "DeviceName", tradeinCollect.DeviceDescriptionId);
            ViewData["StorageId"] = new SelectList(_context.Storage, "StorageId", "StorageCapacity", tradeinCollect.StorageId);
            return View(tradeinCollect);
        }

        // POST: TradeinCollects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TradeinCollectId,TradeinNumber,Brand,DeviceDescriptionId,StorageId,ColourId,IMEI,DeviceCondition,DevicePicture,RequestDateTime,UserId,CApprovalMessagesId,ApprovalMessagesId")] TradeinCollect tradeinCollect)
        {
            if (id != tradeinCollect.TradeinCollectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tradeinCollect);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TradeinCollectExists(tradeinCollect.TradeinCollectId))
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
            ViewData["ApprovalMessagesId"] = new SelectList(_context.ApprovalMessages, "ApprovalMessagesId", "AMessages", tradeinCollect.ApprovalMessagesId);
            ViewData["CApprovalMessagesId"] = new SelectList(_context.CApprovalMessages, "CApprovalMessagesId", "CMessages", tradeinCollect.CApprovalMessagesId);
            ViewData["ColourId"] = new SelectList(_context.Colours, "ColourId", "Name", tradeinCollect.ColourId);
            ViewData["DeviceDescriptionId"] = new SelectList(_context.DeviceDescriptions, "DeviceDescriptionId", "DeviceName", tradeinCollect.DeviceDescriptionId);
            ViewData["StorageId"] = new SelectList(_context.Storage, "StorageId", "StorageCapacity", tradeinCollect.StorageId);
            return View(tradeinCollect);
        }

        // GET: TradeinCollects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tradeinCollect = await _context.TradeinCollect
                .Include(t => t.ApprovalMessages)
                .Include(t => t.CApprovalMessages)
                .Include(t => t.Colour)
                .Include(t => t.DeviceDescription)
                .Include(t => t.Storage)
                .FirstOrDefaultAsync(m => m.TradeinCollectId == id);
            if (tradeinCollect == null)
            {
                return NotFound();
            }

            return View(tradeinCollect);
        }

        // POST: TradeinCollects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tradeinCollect = await _context.TradeinCollect.FindAsync(id);
            _context.TradeinCollect.Remove(tradeinCollect);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TradeinCollectExists(int id)
        {
            return _context.TradeinCollect.Any(e => e.TradeinCollectId == id);
        }
    }
}
