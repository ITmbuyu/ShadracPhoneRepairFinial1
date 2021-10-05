using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShadracPhoneRepairFinial1.Models
{
    public class DeviceProblem
    {
        public int DeviceProblemId { get; set; }

        [Display(Name = "Enter Problem Description")]
        public string Description { get; set; }

        [Display(Name = "Enter Charge to fix Problem ")]
        public double CostOfP { get; set; }
    }
}
