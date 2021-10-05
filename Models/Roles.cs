using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShadracPhoneRepairFinial1.Models
{
    public class Roles
    {
        //private readonly RoleManager<IdentityRole> roleManager;
        //public Roles(RoleManager<IdentityRole> roleManager)
        //{
        //    this.roleManager = roleManager;
        //}
        public Roles() { }
        public Roles(IdentityRole role)
        {
            string Id = role.Id;
            string Name = role.Name;
        }
        public string RolesId { get; set; }
        public string RoleName { get; set; }
    }
}
