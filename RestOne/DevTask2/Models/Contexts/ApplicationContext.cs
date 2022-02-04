using System;
using Microsoft.EntityFrameworkCore;

namespace DevTask2.Models.Contexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Application> applications { get; set; }
        public DbSet<Applicant> applicants { get; set; }
        public DbSet<Credit> credits { get; set; }
        public UsersContext(DbContextOptions<UsersContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
