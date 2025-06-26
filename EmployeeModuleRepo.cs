using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Oracle;
using DataAccess.Context;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Types;
using Oracle.ManagedDataAccess;
using Microsoft.Exchange.WebServices.Data;

namespace DataAccess.Repository
{
    public class EmployeeModuleRepo: ControllerBase
    {
        //constructor injection
        private readonly DataContext _context;
        private readonly EmployeeModel _employeemodel;

        public EmployeeModuleRepo(DataContext context, EmployeeModel employeemodel)
        {
            {
                _context = context;
                _employeemodel = employeemodel;
            }
        }
        public string GetNameRepo(string name)
        {
            string res = "My name is " + name;
        return res;
        }

        public async Task<bool> TestConnection()
        {
            try
            {
                using var connection = _context.CreateConnection();
                
                return true; // Connection successful
            }
            catch
            {
                return false; // Connection failed
            }
        }
        [HttpGet("GetQuery1",Name="GetQuery1")]
        public async Task<IActionResult> GetQuery1()
        {
            try
            {
                using var connection = _context.CreateConnection();
                //using var connection = _context.CreateConnection();
                
                string query = "select * from EMPLOYEE_434794";
                var res = await connection.QueryAsync<EmployeeModel>(query);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server error:" + ex.Message);
            }
        }
        // query execution
        //[HttpGet("GetRepoQuery1", Name = "GetRepoQuery1")]
        //public async Task<IActionResult> GetRepoQuery1()
        //{
        //    try
        //    {
        //        using var connection = _context.CreateConnection();
        //        string query = "SELECT * FROM EMPLOYEE_434794";
        //        var res = await connection.QueryAsync<EmployeeModel>(query); // Assuming Employee is a model class
        //        return Ok(res);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception (consider using a logging framework)
        //        return StatusCode(500, "Internal server error: " + ex.Message);
        //    }
        //}
        // execution of procedure without flag
        
        public async Task<IActionResult> GetDetailsRepo1()
        {
            OracleRefCursor result = null;
            var procedureName = "proc_viewempWithOut_May31";
            var parameters = new OracleDynamicParameters();

            parameters.Add("emp_refcur", result, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.BindByName = true;

            using var connection = _context.CreateConnection();
            var response = await connection.QueryAsync<EmployeeModel>(
                procedureName,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            if (response == null || !response.Any())
            {
                return NotFound(); // Return 404 if no data is found
            }

            return Ok(response); // Return 200 OK with the student details
        }
        public async Task<IEnumerable<EmployeeModel>> GetDetailsRepo2(string flag, string para1, string para2)
        {
            OracleRefCursor result = null;
            var procedureName = "proc_viewempwithflag_May31";
            var parameters = new OracleDynamicParameters();

            parameters.Add("flag", flag, OracleMappingType.NVarchar2, ParameterDirection.Input);

            parameters.Add("paravalue1", para1, OracleMappingType.NVarchar2,
            ParameterDirection.Input);

            parameters.Add("paravalue2", para2, OracleMappingType.NVarchar2,
            ParameterDirection.Input);

            parameters.Add("emp_refcur", result, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.BindByName = true;

            using var connection = _context.CreateConnection();
            var response = await connection.QueryAsync<EmployeeModel>(
                procedureName,
                parameters,
                commandType: CommandType.StoredProcedure
                );
            return response;

        }


    }
}
