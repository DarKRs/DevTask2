using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DevTask2.Models.Contexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Application> applications { get; set; }
        public DbSet<Applicant> applicants { get; set; }
        public DbSet<Credit> credits { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            if (!applications.Any())
            {
                applications.Add(new Application() { AppNum = "Test123" });
                applications.Add(new Application());
                SaveChanges();
            }
            
        }
    }
}
