using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin")] //Cookie is found or Not => Claim type "Admin"
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> RoleManager) {
            roleManager = RoleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> New(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid) {
                IdentityRole roleModel = new IdentityRole();
                roleModel.Name=roleViewModel.RoleName;
                //Save DB
              IdentityResult result = await roleManager.CreateAsync(roleModel);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Employee");

                }
                else {
                    foreach (var i in result.Errors) {
                        ModelState.AddModelError("", i.Description);
                    }
                }
            }
            return View(roleViewModel);
        }

    }
}
