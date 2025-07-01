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
    public class EmployeeModuleRepo : ControllerBase
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
        //[HttpGet("GetQuery1",Name="GetQuery1")]
        //public async Task<IActionResult> GetQuery1()
        //{
        //    try
        //    {
        //        using var connection = _context.CreateConnection();
        //        //using var connection = _context.CreateConnection();

        //        string query = "select * from EMPLOYEE_434794";
        //        var res = await connection.QueryAsync<EmployeeModel>(query);
        //        return Ok(res);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "Internal Server error:" + ex.Message);
        //    }
        //}
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
        public async Task<IActionResult> PostDetailsEmpRepo1(string flag, string para1, string para2, string para3, string para4)
        {
            OracleRefCursor result = null;
            var procedureName = "proc_insertempWithflag_May31";
            var parameters = new OracleDynamicParameters();

            parameters.Add("flag", flag, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue1", para1, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue2", para2, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue3", para3, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue4", para4, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("emp_refcur", result, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.BindByName = true;

            using var connection = _context.CreateConnection();
            var response = await connection.QueryAsync<EmployeeModel>(
                procedureName,
                parameters,
                commandType: CommandType.StoredProcedure);

            return Ok(response);
        }
        //method 2:Post

        public async Task<IActionResult> PostDetailsEmpRepoM2(EmployeeReqDto postreq)
        {
            OracleRefCursor result = null;
            var procedureName = "proc_insertempWithflag_May31";
            var parameters = new OracleDynamicParameters();

            parameters.Add("flag", postreq.flag, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue1", postreq.p1, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue2", postreq.p2, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue3", postreq.p3, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue4", postreq.p4, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("emp_refcur", result, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.BindByName = true;

            using var connection = _context.CreateConnection();
            var response = await connection.QueryAsync<EmployeeModel>(
                procedureName,
                parameters,
                commandType: CommandType.StoredProcedure);

            return Ok(response);
        }
        //public async Task<IActionResult> PutDetailsEmpRepo11(string flag, string para1, string para2, string para3, string para4)
        //{
        //    OracleRefCursor result = null;
        //    var procedureName = "proc_updateempWithflag_May31";
        //    var parameters = new OracleDynamicParameters();

        //    parameters.Add("flag", flag, OracleMappingType.NVarchar2, ParameterDirection.Input);
        //    parameters.Add("paravalue1", para1, OracleMappingType.NVarchar2, ParameterDirection.Input);
        //    parameters.Add("paravalue2", para2, OracleMappingType.NVarchar2, ParameterDirection.Input);
        //    parameters.Add("paravalue3", para3, OracleMappingType.NVarchar2, ParameterDirection.Input);
        //    parameters.Add("paravalue4", para4, OracleMappingType.NVarchar2, ParameterDirection.Input);
        //    parameters.Add("emp_refcur", result, OracleMappingType.RefCursor, ParameterDirection.Output);
        //    parameters.BindByName = true;

        //    using var connection = _context.CreateConnection();
        //    var response = await connection.QueryAsync<EmployeeModel>(
        //        procedureName,
        //        parameters,
        //        commandType: CommandType.StoredProcedure);

        //    return Ok(response);
        //}


        public async Task<IActionResult> PostImageRepo(ImageReqDto postreq1)
        {
            OracleRefCursor result = null;
            var procedureName = "proc_insertimage_420681";
            var parameters = new OracleDynamicParameters();

            parameters.Add("flag", postreq1.flag, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue1", postreq1.id.ToString(), OracleMappingType.NVarchar2, ParameterDirection.Input);

            byte[] imageData;
            try
            {
                string filePath = postreq1.image.Replace("file:///", "");
                imageData = System.IO.File.ReadAllBytes(filePath);
                if (imageData.Length < 20 * 1024 || imageData.Length > 100 * 1024)
                {
                    return BadRequest("image size must be btw 20kb and 100kb");
                }
                string fileExtension = Path.GetExtension(filePath).ToLower();
                if (fileExtension != ".jpg")
                {
                    return BadRequest("image type must be .jpg");
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Error reading image file:{ex.Message}");

            }
            parameters.Add("paravalue2", imageData, OracleMappingType.Blob, ParameterDirection.Input);
            parameters.Add("emp_refcur", result, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.BindByName = true;

            using var connection = _context.CreateConnection();
            try
            {
                var response = await connection.QueryAsync<dynamic>(
                               procedureName,
                               parameters,
                               commandType: CommandType.StoredProcedure);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error:{ex.Message}");
            }
        }


        public async Task<IActionResult> PutDetailsEmpRepoup(EmployeeReqDto putdto)
        {
            OracleRefCursor result = null;
            var procedureName = "proc_updateempWithflag_May31";
            var parameters = new OracleDynamicParameters();

            parameters.Add("flag", putdto.flag, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue1", putdto.p1, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue2", putdto.p2, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue3", putdto.p3, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue4", putdto.p4, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("emp_refcur", result, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.BindByName = true;

            using var connection = _context.CreateConnection();
            var response = await connection.QueryAsync<EmployeeModel>(
                procedureName,
                parameters,
                commandType: CommandType.StoredProcedure);

            return Ok(response);
        }
        public async Task<IActionResult> DeleteDetailsEmpRepo11(string flag, string para1)
        {
            OracleRefCursor result = null;
            var procedureName = "proc_deleteempWithflag_May31";
            var parameters = new OracleDynamicParameters();

            parameters.Add("flag", flag, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue1", para1, OracleMappingType.NVarchar2, ParameterDirection.Input);
            //parameters.Add("paravalue2", para2, OracleMappingType.NVarchar2, ParameterDirection.Input);
            //parameters.Add("paravalue3", para3, OracleMappingType.NVarchar2, ParameterDirection.Input);
            //parameters.Add("paravalue4", para4, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("emp_refcur", result, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.BindByName = true;

            using var connection = _context.CreateConnection();
            var response = await connection.QueryAsync<EmployeeModel>(
                procedureName,
                parameters,
                commandType: CommandType.StoredProcedure);

            return Ok(response);
        }
        //[HttpDelete("DeleteDetailsEmpRepoDto")]
        public async Task<IActionResult> DeleteDetailsEmpRepoDto(ImageReqDto deldto)
        {
            OracleRefCursor result = null;
            var procedureName = "proc_deleteproject_434794";
            var parameters = new OracleDynamicParameters();

            parameters.Add("flag", deldto.flag, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue1", deldto.id.ToString(), OracleMappingType.NVarchar2, ParameterDirection.Input);
            //parameters.Add("paravalue2", putdto.p2, OracleMappingType.NVarchar2, ParameterDirection.Input);
            //parameters.Add("paravalue3", putdto.p3, OracleMappingType.NVarchar2, ParameterDirection.Input);
            //parameters.Add("paravalue4", putdto.p4, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("emp_refcur", result, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.BindByName = true;

            using var connection = _context.CreateConnection();
            var response = await connection.QueryAsync<dynamic>(
                procedureName,
                parameters,
                commandType: CommandType.StoredProcedure);

            return Ok(response);
        }

    }
}


            
            
        
    
