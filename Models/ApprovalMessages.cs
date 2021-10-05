using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShadracPhoneRepairFinial1.Models
{
    public class ApprovalMessages
    {
        
        public int ApprovalMessagesId { get; set; }

        [Display(Prompt = " Enter Approval Message")]
        public string AMessages { get; set; }
    }
}
