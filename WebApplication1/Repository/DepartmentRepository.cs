using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        //CRUD=> Create , Read , Updete , Delete 
        ITIEntity context;/*=new ITIEntity();*/
        public DepartmentRepository(ITIEntity Context)
        {
            context = Context;
        }
        public List<Department> GetAll()
            {

                return context.Departments.ToList();

            }

            public Department GetById(int id)
            {
                return context.Departments.FirstOrDefault(x => x.Id == id);
            }

            public List<Department> GetAllWithEmployeeName() {
           return context.Departments.Include(x => x.Employees).ToList();
        }
         
            public void Insert(Department dept)
            {
                context.Departments.Add(dept);
                context.SaveChanges();
            }

            public void Update(int id, Department dept)
            {
                Department old = context.Departments.FirstOrDefault(x => x.Id == id);
                old.Id = id;
                context.Departments.Update(dept);
                context.SaveChanges();
            }

            public void DeleteById(int id)
            {

                Department emp = GetById(id);
                context.Departments.Remove(emp);
                context.SaveChanges();
            }
        }
    }

