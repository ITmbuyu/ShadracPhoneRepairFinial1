using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShadracPhoneRepairFinial1.Models
{
    public class PaymentStatus
{
        public int PaymentStatusId { get; set; }

        [Display(Name = "Enter Status message for payment")]
        public string Status { get; set; }
    }
}
