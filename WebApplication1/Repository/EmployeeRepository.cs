using WebApplication1.Models;

namespace WebApplication1.Repository
{
    //CRUD=> Create , Read , Updete , Delete 
    public class EmployeeRepository : IEmployeeRepository
    {
        ITIEntity context;/*=new ITIEntity();*/
        public EmployeeRepository(ITIEntity Context) { 
        context=Context;
        }

        public List<Employee> GetAll() { 

        return context.Employees.ToList();  
        
        }

        public List<Employee> GetByDeptId(int id) { 
        return context.Employees.Where(x=>x.Dept_Id == id).ToList();    
        }

        public Employee GetById(int id) {
            return context.Employees.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Employee emp) { 
            context.Employees.Add(emp);
            context.SaveChanges();  
        }

        public void Update(int id , Employee emp) {
            Employee old = context.Employees.FirstOrDefault(x => x.Id == id);
            old.Name = emp.Name;
            old.Address = emp.Address;
            old.Dept_Id = emp.Dept_Id;
            old.Salary = emp.Salary;
            old.Image = emp.Image;
            context.SaveChanges();
        }    

        public void DeleteById(int id) { 
        
            Employee emp = GetById(id);
            context.Employees.Remove(emp);
            context.SaveChanges();
        }  
    }
}
