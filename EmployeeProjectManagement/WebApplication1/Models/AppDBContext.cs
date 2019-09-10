using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace EmployeeProjectManagement.Models
{
    #region "AppDBContext Class "
    //AppDBContext Class 
    public class AppDBContext : DbContext
    {
        //AppDBContext Constructor using DbContextOptions
        public AppDBContext (DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        //DbSet of Employee table
        public DbSet<Employee> Employee { get; set; }

        //DbSet of Project table
        public DbSet<Project> Project { get; set; }
    }
    #endregion
}