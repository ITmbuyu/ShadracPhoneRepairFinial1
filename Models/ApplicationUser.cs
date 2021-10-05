using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShadracPhoneRepairFinial1.Models
{
    public class ApplicationUser : IdentityUser 
    {
        public string Aadress { get; set; }
    }
}
