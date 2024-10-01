using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class UniqueNameAttribute : ValidationAttribute
    {

        public string Message { get; set; } 
        protected override ValidationResult? 
            IsValid(object? value , ValidationContext validationContext)
        {
            ITIEntity context =new ITIEntity();
            string name = value.ToString();
            Employee emp= context.Employees.FirstOrDefault(x => x.Name==name);
            if (emp == null) { 
            return ValidationResult.Success;
            }
            return new ValidationResult("Name already Found");
          //  return base.IsValid(value, validationContext);
        }
    }
}
