using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EmployeeSalary.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSalary.Controllers
{
    [Route("api/departments")]
    [ApiController]
    public class DepartmentController:ControllerBase
    {
        DAL dal = new DAL();
        public DepartmentController()
        {                                  
        }
        [HttpPost]
        public ActionResult Create([FromBody] Department dpmt)
        {
            var parameters = new List<SqlParameter>
            {
               new SqlParameter("@Department_Name", dpmt.Name)               
            };
            var reader = dal.GetDataReader("Department_Insert", parameters);
            return NoContent();
        }
    }
}
