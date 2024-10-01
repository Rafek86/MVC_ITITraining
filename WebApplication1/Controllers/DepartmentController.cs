using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    public class DepartmentController : Controller
    {
        //  ITIEntity Context = new ITIEntity();
        IDepartmentRepository deptRepo;//=new DepartmentRepository();
        IEmployeeRepository employeeRepo;//=new EmployeeRepository();   
        //implement DI
        public DepartmentController(IEmployeeRepository Emprepo,IDepartmentRepository DeptRepo) { 
            deptRepo=DeptRepo;
            employeeRepo = Emprepo;
        }
        //[Authorize]
        //[ResponseCache(Duration = 10)]
        public IActionResult ShowDepartmentEmployee() { 
        List<Department> department =deptRepo.GetAll(); 
        return View(department);
        }
        //Departmet /getEmpPerDept?dept_id=1
        public IActionResult GetEmployeePerDept(int dept_Id) { 
        List<Employee> emps =employeeRepo.GetByDeptId(dept_Id);   
            return Json(emps);
        }   

        public IActionResult Index() { 

            List<Department> Dept_list = deptRepo.GetAllWithEmployeeName(); 
            return View(Dept_list);//View =Index , Model =Dept_list
        } 
        [HttpGet]//anchor tag(get) || form method get
        public IActionResult New() { 
        return View(new Department());//Form 
        }
        //Submit btn
        //RequestType =get & type =Post 
        //department/saveNew(Post)
        //Department/saveNew?name=sa&managername=Ahmed (get)
        //[AcceptVerbs] the Defualt 
        [HttpPost] //only serving on Post 
        public IActionResult SaveNew(Department dept) {
            if (dept.Name != null)
            {
                //Context.Add(dept);
                //Context.SaveChanges();
                deptRepo.Insert(dept);
            return RedirectToAction("Index"); //with the same Controller if you want call action from another Controller add Parameter with the name of the Controller  
            } 
            else {

                return View("New",dept);

            }
        }
        public IActionResult Details(int deptid) { 
        return Content(deptid.ToString());
        }
    }
}
