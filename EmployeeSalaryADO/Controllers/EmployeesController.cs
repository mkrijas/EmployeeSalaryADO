using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeSalary.Entities;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeSalary.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController:ControllerBase
    {
        DAL dal = new DAL();

        public EmployeesController()
        {
                     
        }

        [HttpGet]        
        public ActionResult Get()
        {
            var reader = dal.GetDataReader("Employee_Select_All", null);

            DataTable dt = new DataTable();
            dt.Load(reader);
            return Ok(dt);
        }

        [HttpGet("{Id:int}", Name = "getEmployee")]
        public ActionResult GetDetail(int Id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
               new SqlParameter("@Employee_Id",Id)
            };
            var reader = dal.GetDataReader("Employee_Select", parameters);
            DataTable dt = new DataTable();
            dt.Load(reader);
            
            if (dt.Rows.Count == 0)
                return NotFound();
            return Ok(dt);
        }

        [HttpGet("{Id:int}/Salary")]
        public ActionResult GetSalary(int Id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
               new SqlParameter("@Employee_Id", Id)
            };
            var reader = dal.GetDataReader("Employee_Salary", parameters);
            DataTable dt = new DataTable();
            dt.Load(reader);

            if (dt.Rows.Count == 0)
                return NotFound();
            return Ok(dt);
        }

        [HttpPost]
        public ActionResult Create([FromBody] Employee emp)
        {
            var parameters = new List<SqlParameter>
            {
               new SqlParameter("@Employee_Id", emp.Employee_Id),
               new SqlParameter("@Employee_Name", emp.Name),
               new SqlParameter("@DepartmentId", emp.DepartmentId)
            };
            var reader = dal.GetDataReader("Employee_IU", parameters);
            return NoContent();
        }

        [HttpPut("{Id}")]
        public ActionResult Update(int Id,[FromBody] Employee emp)
        {
            var parameters = new List<SqlParameter>
            {
               new SqlParameter("@Employee_Id", Id),
               new SqlParameter("@Employee_Name", emp.Name),
               new SqlParameter("@DepartmentId", emp.DepartmentId)
            };
            var reader = dal.GetDataReader("Employee_IU", parameters);           
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public ActionResult Delete(int Id)
        {
            var parameters = new List<SqlParameter>
            {
               new SqlParameter("@Employee_Id", Id)
            };
            var reader = dal.GetDataReader("Employee_Delete", parameters);            
            return NoContent();
        }
    }
}
