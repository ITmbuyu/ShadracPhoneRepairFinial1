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
    public class DeviceStatusWalkInsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeviceStatusWalkInsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DeviceStatusWalkIns
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DeviceStatusesWalkIns.Include(d => d.RepairStatus);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DeviceStatusWalkIns/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceStatusWalkIns = await _context.DeviceStatusesWalkIns
                .Include(d => d.RepairStatus)
                .FirstOrDefaultAsync(m => m.TrackingNumber == id);
            if (deviceStatusWalkIns == null)
            {
                return NotFound();
            }

            return View(deviceStatusWalkIns);
        }

        // GET: DeviceStatusWalkIns/Create
        public IActionResult Create()
        {
            ViewData["RepairStatusId"] = new SelectList(_context.RepairStatuses, "RepairStatusId", "Status");
            return View();
        }

        // POST: DeviceStatusWalkIns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrackingNumber,Brand,DeviceProblem,DeviceName,Capacity,Colour,IMEI,WalkInDate,WalkInTime,Price,WalkInStatus,RepairStatusId,PaymentStatus,RequestDateTime,UserId,TechnicianId,ApprovalOfCharge")] DeviceStatusWalkIns deviceStatusWalkIns)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deviceStatusWalkIns);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RepairStatusId"] = new SelectList(_context.RepairStatuses, "RepairStatusId", "Status", deviceStatusWalkIns.RepairStatusId);
            return View(deviceStatusWalkIns);
        }

        // GET: DeviceStatusWalkIns/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceStatusWalkIns = await _context.DeviceStatusesWalkIns.FindAsync(id);
            if (deviceStatusWalkIns == null)
            {
                return NotFound();
            }
            ViewData["RepairStatusId"] = new SelectList(_context.RepairStatuses, "RepairStatusId", "Status", deviceStatusWalkIns.RepairStatusId);
            return View(deviceStatusWalkIns);
        }

        // POST: DeviceStatusWalkIns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TrackingNumber,Brand,DeviceProblem,DeviceName,Capacity,Colour,IMEI,WalkInDate,WalkInTime,Price,WalkInStatus,RepairStatusId,PaymentStatus,RequestDateTime,UserId,TechnicianId,ApprovalOfCharge")] DeviceStatusWalkIns deviceStatusWalkIns)
        {
            if (id != deviceStatusWalkIns.TrackingNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deviceStatusWalkIns);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeviceStatusWalkInsExists(deviceStatusWalkIns.TrackingNumber))
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
            ViewData["RepairStatusId"] = new SelectList(_context.RepairStatuses, "RepairStatusId", "Status", deviceStatusWalkIns.RepairStatusId);
            return View(deviceStatusWalkIns);
        }

        // GET: DeviceStatusWalkIns/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceStatusWalkIns = await _context.DeviceStatusesWalkIns
                .Include(d => d.RepairStatus)
                .FirstOrDefaultAsync(m => m.TrackingNumber == id);
            if (deviceStatusWalkIns == null)
            {
                return NotFound();
            }

            return View(deviceStatusWalkIns);
        }

        // POST: DeviceStatusWalkIns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var deviceStatusWalkIns = await _context.DeviceStatusesWalkIns.FindAsync(id);
            _context.DeviceStatusesWalkIns.Remove(deviceStatusWalkIns);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceStatusWalkInsExists(string id)
        {
            return _context.DeviceStatusesWalkIns.Any(e => e.TrackingNumber == id);
        }
    }
}
