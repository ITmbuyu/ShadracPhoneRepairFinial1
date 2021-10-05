using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShadracPhoneRepairFinial1.Models
{
    public class Colour
    {
        public int ColourId { get; set; }

        [Display(Prompt = " Device Colour")]
        public string Name { get; set; }
    }
}
