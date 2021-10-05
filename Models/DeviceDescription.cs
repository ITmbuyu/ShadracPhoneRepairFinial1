using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShadracPhoneRepairFinial1.Models
{
    public class DeviceDescription
    {
        public int DeviceDescriptionId { get; set; }

        //Foreign Key - Brand
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        [Display(Prompt = " Enter Name of device")]
        public string DeviceName { get; set; }
    }
}
