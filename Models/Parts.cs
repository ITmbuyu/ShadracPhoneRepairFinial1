using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShadracPhoneRepairFinial1.Models
{
    public class Parts
{
        public int PartsId { get; set; }

        [Display(Name = "Enter Part name for device")]
        public string Part_Name { get; set; }

        [Display(Name = "Enter Cost of part")]
        public double  Part_Cost { get; set; }
    }
}
