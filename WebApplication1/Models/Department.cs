using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Display(Name ="Department Name")]
        public string Name { get; set; }
        public string ManagerName { get; set; }

        public virtual List<Employee>? Employees { get; set; }   
    }
}
