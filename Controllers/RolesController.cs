using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShadracPhoneRepairFinial1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShadracPhoneRepairFinial1.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Roles roles)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = roles.RoleName
                };

                IdentityResult result = await roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }

           
            return View(roles);
        }

        [HttpGet]
        public IActionResult Index()
        {
            //var roles = roleManager.Roles;
            //return View(roles.ToList());


            List<Roles> list = new List<Roles>();
            foreach (var role in roleManager.Roles)
                list.Add(new Roles(role));
            return View(list);
        }


        public async Task<ActionResult> Edit(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            return View(new Roles(role));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Roles model)
        {
            var role = new IdentityRole() { Id = model.RolesId, Name = model.RoleName };
            await roleManager.UpdateAsync(role);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            return View(new Roles(role));
        }

        public async Task<ActionResult> Delete(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            return View(new Roles(role));
        }

        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            await roleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }


    }
}