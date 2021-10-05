using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShadracPhoneRepairFinial1.Models
{
    public class DevicePurchase
{
        public int DevicePurchaseId { get; set; }

        [Display(Name = "Picture of Device")]
        public string DevicePicture { get; set; }

        [Display(Name = "Name of Device")]
        public string DeviceName { get; set; }

        [Display(Name = "Enter Brand of Device")]
        public string DeviceBrand { get; set; }

        [Display(Name = "Enter Color of device")]
        public string DeviceColor { get; set; }

        [Display(Name = "Enter RAM of Device")]
        public string DeviceRAM { get; set; }

        [Display(Name = "Enter ROM of Device")]
        public string DeviceROM { get; set; }

        [Display(Name = "Enter Storage Capicity of Device")]
        public string Devicestorage { get; set; }

        [Display(Name = "Enter Camera resolution of Device")]
        public string DeviceCamera { get; set; }

        [Display(Name = "Enter Battery Power of Device")]
        public string DeviceBattery { get; set; }

        [Display(Name = "Enter Processor Speed of Device")]
        public string DeviceProcesser { get; set; }

        [Display(Name = "Enter Price to sell Device")]
        public double DevicePrice { get; set; }
    }
}
