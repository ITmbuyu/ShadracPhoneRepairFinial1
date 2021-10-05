using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShadracPhoneRepairFinial1.Controllers
{
    public class PartsPurchase : Controller
    {
        public IActionResult DevicesIndex()
        {
            return View();
        }

        public IActionResult DevicesApple()
        {
            return View();
        }
        public IActionResult DevicesApple_IphoneSE()
        {
            return View();
        }
    }
}
