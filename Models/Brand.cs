using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShadracPhoneRepairFinial1.Models
{
    public class Brand
    {

        public int BrandId { get; set; }

        [Display(Prompt = " Brand Name")]
        public string BrandName { get; set; }

        [Display(Prompt = " Brand Rate")]
        public double BrandRate { get; set; }
    }
}
