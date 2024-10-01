using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using WebApplication1.Models;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class PassDataController : Controller
    {
        ITIEntity context =new ITIEntity();

        public IActionResult testViewData(int id)
        {
          Employee empModel=  context.Employees.FirstOrDefault(x=>x.Id == id);
            string msg = "Hello";
            List<string> branches = new List<string>();
            branches.Add("Assuit");
            branches.Add("Menia");
            branches.Add("Mansuora");
            branches.Add("Sohag");
            int Temp = 44;
            string Color = "red";


            //View Data
            //ViewData["msg"] = msg;
            //ViewData["brch"] =branches;
            //ViewData["temp"] = Temp;
            //ViewData["color"] =Color;  
            
            //ViewBag
            ViewBag.msg=msg;    
            ViewBag.brch=branches;  
            ViewBag.color=Color;
            ViewBag.temp=Temp;

           

            return View(empModel);
        }
        public IActionResult testViewModel(int id)
        {
            Employee empModel = context.Employees.FirstOrDefault(x => x.Id == id);
            string msg = "Hello";
            List<string> branches = new List<string>();
            branches.Add("Assuit");
            branches.Add("Menia");
            branches.Add("Mansuora");
            branches.Add("Sohag");
            int Temp = 44;
            string Color = "red";
            //Declare View Model
            EmployeeWithMessageAndBrancheListViewModel empViewModel
                = new EmployeeWithMessageAndBrancheListViewModel();
            empViewModel.Message = msg;
            empViewModel.Temp = Temp;   
            empViewModel.Color = Color;
            empViewModel.Branches = branches;

            return View(empViewModel);
            
        }
    }
}
