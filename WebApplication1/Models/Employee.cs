using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        [UniqueName(Message ="Hi There")]
        public string Name { get; set; }

        [RegularExpression(@"\d{5}" ,ErrorMessage ="Salary Must be 5 Numbers")]
        [Range(2000,60000)]
        [Required]
        [Remote("CheckSalary","Employee",ErrorMessage ="Salary Must Be More Than 2000$")]
        public int Salary { get; set; }

        [Required]
        [RegularExpression("(Alex|Mania|Sohag|Assuit)")]
        public string? Address { get; set; }

        [RegularExpression(@"[a-z]+\.(jpg|png)")]
        public string Image { get; set; }
        [ForeignKey("Department")]
        public int Dept_Id { get; set; } 

        public virtual Department? Department { get; set; }  
    }
}
