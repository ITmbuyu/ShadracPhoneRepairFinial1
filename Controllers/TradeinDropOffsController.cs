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
    public class TradeinDropOffsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TradeinDropOffsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TradeinDropOffs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TradeinDropOff.Include(t => t.ApprovalMessages).Include(t => t.CApprovalMessages).Include(t => t.Colour).Include(t => t.DeviceDescription).Include(t => t.Storage).Include(t => t.WalkInTimes);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TradeinDropOffs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tradeinDropOff = await _context.TradeinDropOff
                .Include(t => t.ApprovalMessages)
                .Include(t => t.CApprovalMessages)
                .Include(t => t.Colour)
                .Include(t => t.DeviceDescription)
                .Include(t => t.Storage)
                .Include(t => t.WalkInTimes)
                .FirstOrDefaultAsync(m => m.TradeinDropOffId == id);
            if (tradeinDropOff == null)
            {
                return NotFound();
            }

            return View(tradeinDropOff);
        }

        // GET: TradeinDropOffs/Create
        public IActionResult Create()
        {
            ViewData["ApprovalMessagesId"] = new SelectList(_context.ApprovalMessages, "ApprovalMessagesId", "AMessages");
            ViewData["CApprovalMessagesId"] = new SelectList(_context.CApprovalMessages, "CApprovalMessagesId", "CMessages");
            ViewData["ColourId"] = new SelectList(_context.Colours, "ColourId", "Name");
            ViewData["DeviceDescriptionId"] = new SelectList(_context.DeviceDescriptions, "DeviceDescriptionId", "DeviceName");
            ViewData["StorageId"] = new SelectList(_context.Storage, "StorageId", "StorageCapacity");
            ViewData["WalkInTimesId"] = new SelectList(_context.WalkInTimes, "WalkInTimesId", "WalkInTime");
            return View();
        }

        // POST: TradeinDropOffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TradeinDropOffId,TradeinNumber,Brand,DeviceDescriptionId,StorageId,ColourId,IMEI,DeviceCondition,RequestDateTime,WalkInDate,WalkInTimesId,UserId,CApprovalMessagesId,ApprovalMessagesId")] TradeinDropOff tradeinDropOff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tradeinDropOff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApprovalMessagesId"] = new SelectList(_context.ApprovalMessages, "ApprovalMessagesId", "AMessages", tradeinDropOff.ApprovalMessagesId);
            ViewData["CApprovalMessagesId"] = new SelectList(_context.CApprovalMessages, "CApprovalMessagesId", "CApprovalMessages", tradeinDropOff.CApprovalMessagesId);
            ViewData["ColourId"] = new SelectList(_context.Colours, "ColourId", "Name", tradeinDropOff.ColourId);
            ViewData["DeviceDescriptionId"] = new SelectList(_context.DeviceDescriptions, "DeviceProblemId", "Description", tradeinDropOff.DeviceDescriptionId);
            ViewData["StorageId"] = new SelectList(_context.Storage, "StorageId", "StorageCapacity", tradeinDropOff.StorageId);
            ViewData["WalkInTimesId"] = new SelectList(_context.WalkInTimes, "WalkInTimesId", "WalkInTime", tradeinDropOff.WalkInTimesId);
            return View(tradeinDropOff);
        }

        // GET: TradeinDropOffs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tradeinDropOff = await _context.TradeinDropOff.FindAsync(id);
            if (tradeinDropOff == null)
            {
                return NotFound();
            }
            ViewData["ApprovalMessagesId"] = new SelectList(_context.ApprovalMessages, "ApprovalMessagesId", "AMessages", tradeinDropOff.ApprovalMessagesId);
            ViewData["CApprovalMessagesId"] = new SelectList(_context.CApprovalMessages, "CApprovalMessagesId", "CApprovalMessages", tradeinDropOff.CApprovalMessagesId);
            ViewData["ColourId"] = new SelectList(_context.Colours, "ColourId", "Name", tradeinDropOff.ColourId);
            ViewData["DeviceDescriptionId"] = new SelectList(_context.DeviceDescriptions, "DeviceProblemId", "Description", tradeinDropOff.DeviceDescriptionId);
            ViewData["StorageId"] = new SelectList(_context.Storage, "StorageId", "StorageCapacity", tradeinDropOff.StorageId);
            ViewData["WalkInTimesId"] = new SelectList(_context.WalkInTimes, "WalkInTimesId", "WalkInTime", tradeinDropOff.WalkInTimesId);
            return View(tradeinDropOff);
        }

        // POST: TradeinDropOffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TradeinDropOffId,TradeinNumber,Brand,DeviceDescriptionId,StorageId,ColourId,IMEI,DeviceCondition,RequestDateTime,WalkInDate,WalkInTimesId,UserId,CApprovalMessagesId,ApprovalMessagesId")] TradeinDropOff tradeinDropOff)
        {
            if (id != tradeinDropOff.TradeinDropOffId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tradeinDropOff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TradeinDropOffExists(tradeinDropOff.TradeinDropOffId))
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
            ViewData["ApprovalMessagesId"] = new SelectList(_context.ApprovalMessages, "ApprovalMessagesId", "AMessages", tradeinDropOff.ApprovalMessagesId);
            ViewData["CApprovalMessagesId"] = new SelectList(_context.CApprovalMessages, "CApprovalMessagesId", "CApprovalMessages", tradeinDropOff.CApprovalMessagesId);
            ViewData["ColourId"] = new SelectList(_context.Colours, "ColourId", "Name", tradeinDropOff.ColourId);
            ViewData["DeviceDescriptionId"] = new SelectList(_context.DeviceDescriptions, "DeviceProblemId", "Description", tradeinDropOff.DeviceDescriptionId);
            ViewData["StorageId"] = new SelectList(_context.Storage, "StorageId", "StorageCapacity", tradeinDropOff.StorageId);
            ViewData["WalkInTimesId"] = new SelectList(_context.WalkInTimes, "WalkInTimesId", "WalkInTime", tradeinDropOff.WalkInTimesId);
            return View(tradeinDropOff);
        }

        // GET: TradeinDropOffs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tradeinDropOff = await _context.TradeinDropOff
                .Include(t => t.ApprovalMessages)
                .Include(t => t.CApprovalMessages)
                .Include(t => t.Colour)
                .Include(t => t.DeviceDescription)
                .Include(t => t.Storage)
                .Include(t => t.WalkInTimes)
                .FirstOrDefaultAsync(m => m.TradeinDropOffId == id);
            if (tradeinDropOff == null)
            {
                return NotFound();
            }

            return View(tradeinDropOff);
        }

        // POST: TradeinDropOffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tradeinDropOff = await _context.TradeinDropOff.FindAsync(id);
            _context.TradeinDropOff.Remove(tradeinDropOff);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TradeinDropOffExists(int id)
        {
            return _context.TradeinDropOff.Any(e => e.TradeinDropOffId == id);
        }
    }
}
