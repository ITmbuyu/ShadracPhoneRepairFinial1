using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShadracPhoneRepairFinial1.Models
{
    public class Storage
{
        public int StorageId { get; set; }

        [Display(Name = "Enter storage capicity for device")]
        public string StorageCapacity { get; set; }
    }
}
