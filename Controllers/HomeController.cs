using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShadracPhoneRepairFinial1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShadracPhoneRepairFinial1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Commerce()
        {
            return View();
        }

        public IActionResult SinglePage()
        {
            return View();
        }

        public IActionResult PaymentPage()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        // Admin Display Views
        public IActionResult AdminHumanResources()
        {
            return View();
        }

        public IActionResult AdminPurchase()
        {
            return View();
        }

        public IActionResult AdminRepairs()
        {
            return View();
        }

        // Technician Display Views
        public IActionResult TechnicianRepairs()
        {
            return View();
        }

        public IActionResult TechnicianDevices()
        {
            return View();
        }

        public IActionResult TechnicianPurchase()
        {
            return View();
        }

        public IActionResult TechnicianTradeIn()
        {
            return View();
        }

        // Customer Display Views
        public IActionResult CustomerPurchase()
        {
            return View();
        }

        public IActionResult CustomerRepairs()
        {
            return View();
        }

        public IActionResult CustomerTradeIn()
        {
            return View();
        }

        //Driver Dash
        public IActionResult DriverDash()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
