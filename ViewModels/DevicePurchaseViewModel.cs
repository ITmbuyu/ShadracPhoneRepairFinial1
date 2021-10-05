using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShadracPhoneRepairFinial1.ViewModels
{
    public class DevicePurchaseViewModel
    {
        
        public IFormFile DevicePicture { get; set; }

        public string DeviceName { get; set; }

        public string DeviceBrand { get; set; }

        public string DeviceColor { get; set; }

        public string DeviceRAM { get; set; }
        public string DeviceROM { get; set; }

        public string Devicestorage { get; set; }

        public string DeviceCamera { get; set; }

        public string DeviceBattery { get; set; }

        public string DeviceProcesser { get; set; }

        public double DevicePrice { get; set; }
    }
}
