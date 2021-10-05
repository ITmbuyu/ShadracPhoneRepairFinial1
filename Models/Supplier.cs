using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShadracPhoneRepairFinial1.Models
{
    public class Supplier
{
        public int SupplierId { get; set; }

        [Display(Name = "Enter supplier company")]
        public string Supplier_Name { get; set; }
        [Display(Name = "Enter Address of supplier company")]
        public string Supplier_Address { get; set; }
        [Display(Name = "Enter supplier cell number")]
        public string Supplier_CellNumber { get; set; }
    }
}
