using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSalary.Entities
{
    public class Salary
    {
        [Key]
        public int Salary_Id { get; set; }       
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal basic_Pay { get; set; }
        [Column(TypeName = "decimal(18, 2)")]        
        public decimal HRA { get; set; }
        //[Column(TypeName = "decimal(18, 2)")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //public decimal Net_Pay {
        //    get
        //    {
        //        return basic_Pay + HRA;
        //    }
        //    private set { }
        // }

        public int Employee_Id { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
