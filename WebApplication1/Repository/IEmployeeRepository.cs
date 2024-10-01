using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetAll();

        public List<Employee> GetByDeptId(int id);

        public Employee GetById(int id);

        public void Insert(Employee emp);

        public void Update(int id, Employee emp);

        public void DeleteById(int id);
    }
}
