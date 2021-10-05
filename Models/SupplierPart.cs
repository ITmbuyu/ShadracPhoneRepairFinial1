using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShadracPhoneRepairFinial1.Models
{
    public class SupplierPart
    {
//Foreign Key - Brand
        public int SupplierPartId { get; set; }

        [Display(Name = "Select Part Needed")]
        public int PartsId { get; set; }
        public virtual Parts Parts { get; set; }

        [Display(Name = "Select supplier company")]
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        public string PartSupplied_Date { get; set; }

        [Display(Name = "Enter quantity ")]
        public int PartSupplied_Quantity { get; set; }
    }
}
