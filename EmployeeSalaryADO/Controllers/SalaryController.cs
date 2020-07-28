using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeSalary.Entities;
using System.Data.SqlClient;

namespace EmployeeSalary.Controllers
{
    [Route("api/salary")]
    [ApiController]
    public class SalaryController : ControllerBase
    {

        DAL dal = new DAL();
        public SalaryController()
        {            
        }
        [HttpPost]
        public ActionResult Create([FromBody] Salary sal)
        {
            var parameters = new List<SqlParameter>
            {
               new SqlParameter("@Employee_Id", sal.Employee_Id),
               new SqlParameter("@basic_pay", sal.basic_Pay),
               new SqlParameter("@HRA", sal.HRA)
            };
            var reader = dal.GetDataReader("Salary_IU", parameters);
            return NoContent();
        }

        [HttpPut("{Id}")]
        public ActionResult Update(int Id, [FromBody] Salary sal)
        {
            var parameters = new List<SqlParameter>
            {
               new SqlParameter("@Employee_Id", Id),
               new SqlParameter("@basic_pay", sal.basic_Pay),
               new SqlParameter("@HRA", sal.HRA)
            };
            var reader = dal.GetDataReader("Salary_IU", parameters);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public ActionResult Delete(int Id)
        {
            var parameters = new List<SqlParameter>
            {
               new SqlParameter("@Employee_Id", Id)
            };
            var reader = dal.GetDataReader("Salary_Delete", parameters);
            return NoContent();
        }



    }
}

