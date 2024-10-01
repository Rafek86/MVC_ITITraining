using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class ITIEntity :IdentityDbContext<ApplicationUser>
    {
        public ITIEntity() :base(){
        }

        public ITIEntity(DbContextOptions options) : base(options) { 
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=ITI_MVC;Integrated Security=SSPI;TrustServerCertificate=true;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
