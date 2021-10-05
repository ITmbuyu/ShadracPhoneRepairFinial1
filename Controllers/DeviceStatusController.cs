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
    public class DeviceStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeviceStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DeviceStatus
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DeviceStatuses.Include(d => d.RepairStatus);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DeviceStatus/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceStatus = await _context.DeviceStatuses
                .Include(d => d.RepairStatus)
                .FirstOrDefaultAsync(m => m.TrackingNumber == id);
            if (deviceStatus == null)
            {
                return NotFound();
            }

            return View(deviceStatus);
        }

        // GET: DeviceStatus/Create
        public IActionResult Create()
        {
            ViewData["RepairStatusId"] = new SelectList(_context.RepairStatuses, "RepairStatusId", "Status");
            return View();
        }

        // POST: DeviceStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrackingNumber,Brand,DeviceProblem,DeviceName,Capacity,Colour,IMEI,Price,RepairStatusId,PaymentStatus,RequestDateTime,UserId,TechnicianId,ApprovalOfRequest,ApprovalOfCharge")] DeviceStatus deviceStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deviceStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RepairStatusId"] = new SelectList(_context.RepairStatuses, "RepairStatusId", "Status", deviceStatus.RepairStatusId);
            return View(deviceStatus);
        }

        // GET: DeviceStatus/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceStatus = await _context.DeviceStatuses.FindAsync(id);
            if (deviceStatus == null)
            {
                return NotFound();
            }
            ViewData["RepairStatusId"] = new SelectList(_context.RepairStatuses, "RepairStatusId", "Status", deviceStatus.RepairStatusId);
            return View(deviceStatus);
        }

        // POST: DeviceStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TrackingNumber,Brand,DeviceProblem,DeviceName,Capacity,Colour,IMEI,Price,RepairStatusId,PaymentStatus,RequestDateTime,UserId,TechnicianId,ApprovalOfRequest,ApprovalOfCharge")] DeviceStatus deviceStatus)
        {
            if (id != deviceStatus.TrackingNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deviceStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeviceStatusExists(deviceStatus.TrackingNumber))
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
            ViewData["RepairStatusId"] = new SelectList(_context.RepairStatuses, "RepairStatusId", "Status", deviceStatus.RepairStatusId);
            return View(deviceStatus);
        }

        // GET: DeviceStatus/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceStatus = await _context.DeviceStatuses
                .Include(d => d.RepairStatus)
                .FirstOrDefaultAsync(m => m.TrackingNumber == id);
            if (deviceStatus == null)
            {
                return NotFound();
            }

            return View(deviceStatus);
        }

        // POST: DeviceStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var deviceStatus = await _context.DeviceStatuses.FindAsync(id);
            _context.DeviceStatuses.Remove(deviceStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceStatusExists(string id)
        {
            return _context.DeviceStatuses.Any(e => e.TrackingNumber == id);
        }
    }
}
