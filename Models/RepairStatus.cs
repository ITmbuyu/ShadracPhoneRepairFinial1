using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShadracPhoneRepairFinial1.Models
{
    public class RepairStatus
{
        public int RepairStatusId { get; set; }

        [Display(Name = "Enter Status message to update customer")]
        public string Status { get; set; }
    }
}
