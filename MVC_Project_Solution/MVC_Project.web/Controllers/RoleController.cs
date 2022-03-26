using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.Core.Models;
using System;
using System.Threading.Tasks;

namespace MVC_Project.web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> RoleManager;

        public RoleController(RoleManager<IdentityRole> _RoleManager)
        {
            RoleManager = _RoleManager;
        }

        public IActionResult AddRole()
        {
            return View("AddRole");
        }


        [HttpPost]
        public async Task<IActionResult> AddRole(RoleVM newRole)
        {
            if (ModelState.IsValid == true)
            {
                IdentityRole role = new IdentityRole()
                {
                    Name = newRole.RoleName
                };

                IdentityResult result = await RoleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    return View();
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return View(newRole);
        }

    }
}
