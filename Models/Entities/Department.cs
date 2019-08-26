using System;
using System.Collections.Generic;

namespace WFAPersonelTakibi.Models.Entities
{
    public class Department
    {
        public Department()
        {
            this.DepartmentID = Guid.NewGuid();
        }
        public Guid DepartmentID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Employee>Employees { get; set; }
    }
}
