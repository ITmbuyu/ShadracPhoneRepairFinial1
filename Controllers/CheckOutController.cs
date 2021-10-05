using Microsoft.AspNetCore.Mvc;
using ShadracPhoneRepairFinial1.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShadracPhoneRepairFinial1.Data;
using ShadracPhoneRepairFinial1.Models;
using ShadracPhoneRepairFinial1.ViewModels;
using System.Xml.Linq;


namespace ShadracPhoneRepairFinial1.Controllers
{
    public class CheckOutController : Controller
    {
       
        private readonly IBraintreeService _braintreeService;
        private readonly ApplicationDbContext _context;

        public CheckOutController(ApplicationDbContext context, IBraintreeService braintreeService)
        {
            _braintreeService = braintreeService;
            _context = context;
        }

        

        public IActionResult CheckOut()
        {
            return View();
        }

        public IActionResult DevicePurchase(DevicePurchase devicePurchase)
        {
            int id = 4;
            if (TempData.ContainsKey("id"))
                id = (int)TempData["id"];
            var Device = id;
            if (id == null) return NotFound();

            var gateway = _braintreeService.GetGateway();
            var clientToken = gateway.ClientToken.Generate();
            ViewBag.ClientToken = clientToken;

            var data = new DevicePurchaseVM
            {
                DevicePurchaseId = Device,
                DeviceName = _context.DevicePurchase.Find(devicePurchase.DevicePurchaseId).DeviceName,
                DeviceBrand = _context.DevicePurchase.Find(devicePurchase.DevicePurchaseId).DeviceBrand,
                DeviceColor = _context.DevicePurchase.Find(devicePurchase.DevicePurchaseId).DeviceColor,
                DeviceRAM = _context.DevicePurchase.Find(devicePurchase.DevicePurchaseId).DeviceRAM,
                DeviceROM = _context.DevicePurchase.Find(devicePurchase.DevicePurchaseId).DeviceROM,
                Devicestorage = _context.DevicePurchase.Find(devicePurchase.DevicePurchaseId).Devicestorage,
                DeviceCamera = _context.DevicePurchase.Find(devicePurchase.DevicePurchaseId).DeviceCamera,
                DeviceBattery = _context.DevicePurchase.Find(devicePurchase.DevicePurchaseId).DeviceBattery,
                DeviceProcesser = _context.DevicePurchase.Find(devicePurchase.DevicePurchaseId).DeviceProcesser,
                DevicePrice = _context.DevicePurchase.Find(devicePurchase.DevicePurchaseId).DevicePrice,
                Nonce = ""
            };


            return View(data);
        }
    }
}
