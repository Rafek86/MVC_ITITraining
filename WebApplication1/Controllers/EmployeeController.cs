using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        //  ITIEntity Context =new ITIEntity();
        IEmployeeRepository EmpRepo;// =new EmployeeRepository();
        IDepartmentRepository DeptRepo;// =new DepartmentRepository();

        public EmployeeController(IEmployeeRepository empRepo, IDepartmentRepository deptRepo) { 
            EmpRepo= empRepo;   
            DeptRepo= deptRepo;
        }

        public IActionResult CheckSalary(int Salary) {
            if (Salary > 2000) {
                return Json(true);
            }
            return Json(false); 
        }

        public IActionResult Details(int id)
        { 
        return View(EmpRepo.GetById(id));
        }

            public IActionResult DetailsUsingPartial(int id) { 
            Employee emp =EmpRepo.GetById(id);

            return PartialView("_EmployeeCardPartial", emp);
        }
        
        
        public IActionResult New() {
            ViewData["DeptDropDownList"] = DeptRepo.GetAll();
            return View(new Employee());  
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveNew(Employee employee) {
            if (ModelState.IsValid)
            {
                try
                {
                 EmpRepo.Insert(employee);  
                    return RedirectToAction("Index");
                }
                catch (Exception ex) { 
                
                ModelState.AddModelError(string.Empty, ex.Message.ToString());
                }
            }
            ViewData["DeptDropDownList"] = DeptRepo.GetAll();

            return View("New",employee);
        }

        [Authorize]//Chexk Cookie 
        public IActionResult Index()
        {
            return View(EmpRepo.GetAll());
        }

        //Achor Tag
        public IActionResult Edit(int id) {
            Employee empModel = EmpRepo.GetById(id);
            ViewData["deptList"] =DeptRepo.GetAll();
            return View(empModel);
        }

        //Sybmit Save Db
        [HttpPost]
        public IActionResult SaveEdit(int id ,Employee emp) {

            if (ModelState.IsValid)
            {
               Employee old = EmpRepo.GetById(id);
               EmpRepo.Update(id, emp);
               return RedirectToAction("Index");
            }
            ViewData["deptList"] = DeptRepo.GetAll() ; 
            return View("Edit", emp);
            
        }
    }
}
