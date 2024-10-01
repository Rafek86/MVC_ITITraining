using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication1.Models;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager ,SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        { 
            return View();
        }

        [HttpGet]
        public IActionResult Login() { 
        return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel newUser)
        {
            if (ModelState.IsValid)
            {
                //check Db
           var userModel = await userManager.FindByNameAsync(newUser.Username);
                if (userModel != null) 
                { 
                bool found = await userManager.CheckPasswordAsync(userModel,newUser.Password);
                    if (found)
                    {
                        //Create Cookie
                        await signInManager.SignInAsync(userModel, newUser.RememberMe);
                        return RedirectToAction("Index","Employee");
                    }
                }
                ModelState.AddModelError("Wrong", "username or psw Wrong");
            }
            return View(newUser);
          
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel newUservm)
        {
            if (ModelState.IsValid) {
                //Mapping From vm to model
                ApplicationUser usermodel =new ApplicationUser();  
                usermodel.UserName = newUservm.UserName;
                usermodel.Address = newUservm.Address;
                usermodel.PasswordHash = newUservm.Password;
                //save Db
                IdentityResult result = await userManager.CreateAsync(usermodel,newUservm.Password);
                if (result.Succeeded)
                {
                    //Create Cookie 
                    //await userManager.AddToRoleAsync(usermodel, "Student");
                    //signInManager.SignInAsync();ID Name Roles
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim("color", "red"));
                    await signInManager.SignInWithClaimsAsync(usermodel, isPersistent: true, claims); 
                    return RedirectToAction("Index", "Employee");
                }
                else 
                {    
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("password", item.Description);
                    }
                }
            }
            return View(newUservm);
        }

        public IActionResult Logout() {
            signInManager.SignOutAsync();
            return RedirectToAction("Register");
        }
        [HttpGet]
        public IActionResult AddAdmin() { 
        return View();  
        }

        [HttpPost]
        public async Task<IActionResult> AddAdmin(RegisterUserViewModel UserVm ) {
            if (ModelState.IsValid)
            {
                //Mapping From vm to model
                ApplicationUser usermodel = new ApplicationUser();
                usermodel.UserName = UserVm.UserName;
                usermodel.Address = UserVm.Address;
                usermodel.PasswordHash = UserVm.Password;
                //save Db
                IdentityResult result = await userManager.CreateAsync(usermodel, UserVm.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(usermodel, "Admin");
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim("color", "red"));
                    await signInManager.SignInWithClaimsAsync(usermodel, isPersistent: true, claims);
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("password", item.Description);
                    }
                }
            }
            return View(UserVm);
        }
    }
}
