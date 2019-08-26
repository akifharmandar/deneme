namespace WFAPersonelTakibi.Models.Context
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Entities;

    public class MyContext : DbContext
    {
      
        public MyContext()
            : base("name=MyContext")
        {
            //Database.Connection.ConnectionString = "server=.;database=EmployeeDB;uid=sa;pwd=123";
        }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
       
    }

    
}