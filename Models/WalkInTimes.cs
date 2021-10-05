using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShadracPhoneRepairFinial1.Models
{
    public class WalkInTimes
{
        public int WalkInTimesId { get; set; }
        [Display(Name = "Enter Time slots for walkins")]
        public string WalkInTime { get; set; }
    }
}
