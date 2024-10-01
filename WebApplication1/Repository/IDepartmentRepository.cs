using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IDepartmentRepository
    {
        public List<Department> GetAll();

        public Department GetById(int id);

        public List<Department> GetAllWithEmployeeName();

        public void Insert(Department dept);

        public void Update(int id, Department dept);

        public void DeleteById(int id);
    }
}

