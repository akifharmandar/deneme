using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAPersonelTakibi.Models.Entities
{
    public class Employee
    {
        public Employee()
        {
            this.ID = Guid.NewGuid();
            this.HireDate = DateTime.Now;
        }
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Mail { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string ImageUrl { get; set; }
        public Guid DepartmentID { get; set; }
        public DateTime HireDate { get; set; }
        
        public virtual Department Department { get; set; }

        [NotMapped]
        public bool HasImage { get; set; }
    }
}
