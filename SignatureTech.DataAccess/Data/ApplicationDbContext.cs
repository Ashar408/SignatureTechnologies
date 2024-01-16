using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SignatureTech.Models;

namespace SignatureTech.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }  
        public DbSet<EmployeeDetail> EmployeeDetails { get; set; }  
        public DbSet<JobInformation> jobInformations { get; set; }  
        public DbSet<EmergencyContact> EmergencyContacts { get; set; }  
        public DbSet<ProjectManagement> ProjectManagements { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
