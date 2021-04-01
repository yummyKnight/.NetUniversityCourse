using System.Data.Entity;

namespace WebApp.DAL
{
    public class Context : DbContext
    {
        public Context() : base("ExampleContextConnectionString")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<Context>());
        }
        
        // public DbSet<EmployeeEntity> Employees { get; set; }
        // public DbSet<DepartmentEntity> Departments { get; set; }

    }
}