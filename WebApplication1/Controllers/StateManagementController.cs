using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class StateManagementController : Controller
    {
        public IActionResult setTempData()
        {
            TempData["msg"] = "Message Set Hello Ya #m El-Naas";
            return Content("Data Saved");
        }

        public IActionResult get1()
        {
            //Read Form TempData
            string mes = (string)TempData["msg"];
            return Content("get1"+mes);
        }  
        public IActionResult get2()
        {
            //Read Form TempData
            string mes = (string)TempData["msg"];
            return Content("get2" + mes);

        }


        public IActionResult setSession() {

            HttpContext.Session.SetString("name", "Ahmed");
            HttpContext.Session.SetInt32("Age", 20);
            return Content("session Data Saved");
        }

        public IActionResult getSession() {
         string name = HttpContext.Session.GetString("name");
         int? age= HttpContext.Session.GetInt32("Age");
            return Content($"name {name} age {age}");

        }
    }
}
