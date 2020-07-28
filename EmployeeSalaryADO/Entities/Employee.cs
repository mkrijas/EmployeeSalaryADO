using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSalary.Entities
{
    public class Employee
    {
        [Key]
        public int Employee_Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual Salary Salary { get; set; }
    }
}
