using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class RouteController : Controller
    {
        //Route/index/Rafek because we change the name of Parameter in Program.cs
        public IActionResult Index(string name)
        {
            return View();
        }
    }
}
