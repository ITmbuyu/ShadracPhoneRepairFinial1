using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShadracPhoneRepairFinial1.Models
{
    public class CApprovalMessages
    {
        public int CApprovalMessagesId { get; set; }

        [Display(Prompt = " Enter Message for approval")]
        public string CMessages { get; set; }
    }
}
