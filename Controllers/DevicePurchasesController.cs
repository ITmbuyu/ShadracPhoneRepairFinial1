using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShadracPhoneRepairFinial1.Data;
using ShadracPhoneRepairFinial1.Models;
using ShadracPhoneRepairFinial1.ViewModels;
using System.IO;

namespace ShadracPhoneRepairFinial1.Controllers
{
    public class DevicePurchasesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment hostingEnviroment;

        public DevicePurchasesController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            hostingEnviroment = hostingEnvironment;
        }


        // GET: DevicePurchases
        public async Task<IActionResult> Index(DevicePurchase devicePurchase)
        {
            
            return View(await _context.DevicePurchase.ToListAsync());
            
        }

        // GET: DevicePurchases/Details/5
        public async Task<IActionResult> Details(int? id, DevicePurchaseViewModel Model)
        {
            if (id == null)
            {
                return NotFound();
            }

            var devicePurchase = await _context.DevicePurchase
                .FirstOrDefaultAsync(m => m.DevicePurchaseId == id);
            if (devicePurchase == null)
            {
                return NotFound();
            }

            
            DevicePurchase rec = new DevicePurchase
            {
                DevicePurchaseId = _context.DevicePurchase.Find(devicePurchase.DevicePurchaseId).DevicePurchaseId,
                DevicePicture = "~/Commerce CSS/DevicePurchaseImages/" + _context.DevicePurchase.Find(devicePurchase.DevicePurchaseId).DevicePicture,
                DeviceName = _context.DevicePurchase.Find(devicePurchase.DevicePurchaseId).DeviceName,
                DeviceBrand= _context.DevicePurchase.Find(devicePurchase.DevicePurchaseId).DeviceBrand,
                DeviceColor= _context.DevicePurchase.Find(devicePurchase.DevicePurchaseId).DeviceColor,
                DeviceRAM= _context.DevicePurchase.Find(devicePurchase.DevicePurchaseId).DeviceRAM,
                DeviceROM = _context.DevicePurchase.Find(devicePurchase.DevicePurchaseId).DeviceROM,
                Devicestorage= _context.DevicePurchase.Find(devicePurchase.DevicePurchaseId).Devicestorage,
                DeviceCamera= _context.DevicePurchase.Find(devicePurchase.DevicePurchaseId).DeviceCamera,
                DeviceBattery= _context.DevicePurchase.Find(devicePurchase.DevicePurchaseId).DeviceBattery,
                DeviceProcesser= _context.DevicePurchase.Find(devicePurchase.DevicePurchaseId).DeviceProcesser,
                DevicePrice= _context.DevicePurchase.Find(devicePurchase.DevicePurchaseId).DevicePrice,

            };
            ViewBag.Message = rec;

            return View(devicePurchase);
        }

        // GET: DevicePurchases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DevicePurchases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( DevicePurchaseViewModel Model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (Model.DevicePicture != null)
                {
                   string uploadfolder =  Path.Combine(hostingEnviroment.WebRootPath, "Commerce CSS", "DevicePurchaseImages");
                  uniqueFileName= Guid.NewGuid().ToString() + "_" +Model.DevicePicture.FileName;
                 string filepath = Path.Combine(uploadfolder, uniqueFileName);
                    Model.DevicePicture.CopyTo(new FileStream(filepath, FileMode.Create));
                }

                DevicePurchase devicePurchase = new DevicePurchase
                {
                    DevicePicture = uniqueFileName,
                    DeviceName = Model.DeviceName,
                    DeviceBrand = Model.DeviceBrand,
                    DeviceColor = Model.DeviceColor,
                    DeviceRAM = Model.DeviceRAM,
                    DeviceROM = Model.DeviceROM,
                    Devicestorage = Model.Devicestorage,
                    DeviceCamera = Model.DeviceCamera,
                    DeviceBattery = Model.DeviceBattery,
                    DeviceProcesser = Model.DeviceProcesser,
                    DevicePrice = Model.DevicePrice,
                };
                ViewBag.Message = devicePurchase;
                _context.Add(devicePurchase);
                await _context.SaveChangesAsync();
                TempData["id"] = devicePurchase.DevicePurchaseId;
                //RedirectToAction("Purchase", "Checkout", new { id = devicePurchase.DevicePurchaseId });
                return RedirectToAction("details",new { id = devicePurchase.DevicePurchaseId });
            }
            return View();
        }

        // GET: DevicePurchases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var devicePurchase = await _context.DevicePurchase.FindAsync(id);
            if (devicePurchase == null)
            {
                return NotFound();
            }
            return View(devicePurchase);
        }

        // POST: DevicePurchases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DevicePurchaseId,DevicePicture,DeviceName,DeviceBrand,DeviceColor,DeviceRAM,DeviceROM,Devicestorage,DeviceCamera,DeviceBattery,DeviceProcesser,DevicePrice")] DevicePurchase devicePurchase)
        {
            if (id != devicePurchase.DevicePurchaseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(devicePurchase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DevicePurchaseExists(devicePurchase.DevicePurchaseId))
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
            return View(devicePurchase);
        }

        // GET: DevicePurchases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var devicePurchase = await _context.DevicePurchase
                .FirstOrDefaultAsync(m => m.DevicePurchaseId == id);
            if (devicePurchase == null)
            {
                return NotFound();
            }

            return View(devicePurchase);
        }

        // POST: DevicePurchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var devicePurchase = await _context.DevicePurchase.FindAsync(id);
            _context.DevicePurchase.Remove(devicePurchase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DevicePurchaseExists(int id)
        {
            return _context.DevicePurchase.Any(e => e.DevicePurchaseId == id);
        }
    }
}
