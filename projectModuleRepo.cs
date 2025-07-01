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
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Types;

namespace DataAccess.Repository
{
    public class projectModuleRepo : ControllerBase
    {
        //constructor injection
        private readonly DataContext _context;
        private readonly ProjectModel _projectmodel;

        public projectModuleRepo(DataContext context, ProjectModel projectmodel)
        {
            {
                _context = context;
                _projectmodel = projectmodel;
            }
        }


        public async Task<IActionResult> GetDetailsRepo434()
        {
            OracleRefCursor result = null;
            var procedureName = "PROC_PROJECT434";
            var parameters = new OracleDynamicParameters();

            parameters.Add("PRO_CUR", result, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.BindByName = true;

            using var connection = _context.CreateConnection();
            var response = await connection.QueryAsync<ProjectModel>(
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
        public async Task<IEnumerable<ProjectModel>> GetDetailsPro(string flag, string para1, string para2, string para3, string para4)
        {
            OracleRefCursor result = null;
            var procedureName = "proc_434794";
            var parameters = new OracleDynamicParameters();

            parameters.Add("flag", flag, OracleMappingType.NVarchar2, ParameterDirection.Input);

            parameters.Add("paravalue1", para1, OracleMappingType.NVarchar2,
            ParameterDirection.Input);

            parameters.Add("paravalue2", para2, OracleMappingType.NVarchar2,
            ParameterDirection.Input);

            parameters.Add("paravalue3", para3, OracleMappingType.NVarchar2,
           ParameterDirection.Input);

            parameters.Add("paravalue4", para4, OracleMappingType.NVarchar2,
          ParameterDirection.Input);

            parameters.Add("PRO_CUR", result, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.BindByName = true;

            using var connection = _context.CreateConnection();
            var response = await connection.QueryAsync<ProjectModel>(
                procedureName,
                parameters,
                commandType: CommandType.StoredProcedure
                );
            return response;

        }
        public async Task<IActionResult> PostDetailsProjectRepo1(string flag, string para1, string para2, string para3, string para4, string para5)
        {
            OracleRefCursor result = null;
            var procedureName = "proc_insertProject";
            var parameters = new OracleDynamicParameters();

            parameters.Add("flag", flag, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue1", para1, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue2", para2, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue3", para3, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue4", para4, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue5", para5, OracleMappingType.NVarchar2, ParameterDirection.Input);

            parameters.Add(" Proj_refcur", result, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.BindByName = true;

            using var connection = _context.CreateConnection();
            var response = await connection.QueryAsync<ProjectModel>(
                procedureName,
                parameters,
                commandType: CommandType.StoredProcedure);

            return Ok(response);
        }
        public async Task<IActionResult> PostDetailsProjectRepoM2(ProjectReqDto Opostreq)
        {
            OracleRefCursor result = null;
            var procedureName = "proc_insertProject";
            var parameters = new OracleDynamicParameters();

            parameters.Add("flag", Opostreq.flag, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue1", Opostreq.p1, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue2", Opostreq.p2, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue3", Opostreq.p3, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue4", Opostreq.p4, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue5", Opostreq.p5, OracleMappingType.NVarchar2, ParameterDirection.Input);

            parameters.Add("Proj_refcur", result, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.BindByName = true;

            using var connection = _context.CreateConnection();
            var response = await connection.QueryAsync<ProjectModel>(
                procedureName,
                parameters,
                commandType: CommandType.StoredProcedure);

            return Ok(response);
        }


        public async Task<IActionResult> PostDocrepo(DocReqdto postreqDoc)
        {
            OracleRefCursor result = null;
            var procedureName = "proc_proj_doc_434794";
            var parameters = new OracleDynamicParameters();

            parameters.Add("flag", postreqDoc.flag, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue1", postreqDoc.Doc_id.ToString(), OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue2", postreqDoc.Proj_id.ToString(), OracleMappingType.NVarchar2, ParameterDirection.Input);

            byte[] imageData;
            try
            {
                imageData = System.IO.File.ReadAllBytes(postreqDoc.Document);

            }
            catch (Exception ex)
            {
                return BadRequest($"Error reading image file:{ex.Message}");

            }
            parameters.Add("paravalue3", imageData, OracleMappingType.Blob, ParameterDirection.Input);
            parameters.Add("Pimg_refcur", result, OracleMappingType.RefCursor, ParameterDirection.Output);
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

        public async Task<IActionResult> PostImageRepo(ImageReqDto postreqImage)
        {
            OracleRefCursor result = null;
            var procedureName = "proc_updateproject_434794";
            var parameters = new OracleDynamicParameters();

            parameters.Add("flag", postreqImage.flag, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue1", postreqImage.id.ToString(), OracleMappingType.NVarchar2, ParameterDirection.Input);
            //parameters.Add("paravalue2", postreqImage.Proj_id.ToString(), OracleMappingType.NVarchar2, ParameterDirection.Input);

            byte[] imageData;
            try
            {
                string filePath = postreqImage.image.Replace("file:///", "");
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
        //[HttpDelete("DeleteDetailsProject")]

        public async Task<IActionResult> DeleteDetailsProject(string flag, string para1)
        {
            OracleRefCursor result = null;
            var procedureName = "proc_deleteproject_434794";
            var parameters = new OracleDynamicParameters();

            parameters.Add("flag", flag, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue1", para1, OracleMappingType.NVarchar2, ParameterDirection.Input);
            //parameters.Add("paravalue2", para2, OracleMappingType.NVarchar2, ParameterDirection.Input);
            //parameters.Add("paravalue3", para3, OracleMappingType.NVarchar2, ParameterDirection.Input);
            //parameters.Add("paravalue4", para4, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("pro_refcur", result, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.BindByName = true;

            using var connection = _context.CreateConnection();
            var response = await connection.QueryAsync<ProjectModel>(
                procedureName,
                parameters,
                commandType: CommandType.StoredProcedure);

            return Ok(response);
        }
        public async Task<IActionResult> DeleteDetailsProDoc(DocReqdto deldocdto)
        {
            OracleRefCursor result = null;
            var procedureName = "proc_proj_doc_434794";
            var parameters = new OracleDynamicParameters();

            parameters.Add("flag", deldocdto.flag, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue1", deldocdto.Doc_id.ToString(), OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue2", deldocdto.Proj_id.ToString(), OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue3", deldocdto.Document.ToString(), OracleMappingType.NVarchar2, ParameterDirection.Input);
            //parameters.Add("paravalue4", para4, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("pro_refcur", result, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.BindByName = true;

            using var connection = _context.CreateConnection();
            var response = await connection.QueryAsync<dynamic>(
                procedureName,
                parameters,
                commandType: CommandType.StoredProcedure);

            return Ok(response);
        }


        //[HttpPut("PutDetailsProjDto")]
        public async Task<IActionResult> PutDetailsProjDto(ProjectReqDto putprojdto)
        {
            OracleRefCursor result = null;
            var procedureName = "proc_updateProject1_434794";
            var parameters = new OracleDynamicParameters();

            parameters.Add("flag", putprojdto.flag, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue1", putprojdto.p1, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue2", putprojdto.p2, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue3", putprojdto.p3, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue4", putprojdto.p4, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue5", putprojdto.p4, OracleMappingType.NVarchar2, ParameterDirection.Input);

            parameters.Add("proj_refcur", result, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.BindByName = true;

            using var connection = _context.CreateConnection();
            var response = await connection.QueryAsync<ProjectModel>(
                procedureName,
                parameters,
                commandType: CommandType.StoredProcedure);

            return Ok(response);
        }
        
        //[HttpPut("UpdateDetailsProDoc")]
        public async Task<IActionResult> UpdateDetailsProDoc(DocReqdto putDocdto)
        {
            OracleRefCursor result = null;
            var procedureName = "proc_proj_doc_434794";
            var parameters = new OracleDynamicParameters();

            parameters.Add("flag", putDocdto.flag, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue1", putDocdto.Doc_id.ToString(), OracleMappingType.NVarchar2, ParameterDirection.Input);
            byte[] Document;
            try
            {
                Document = System.IO.File.ReadAllBytes(putDocdto.Document);
            }
            catch(Exception ex)
            {
                return BadRequest($"error Reading image file;{ex.Message}");
            }
            
            parameters.Add("paravalue2", putDocdto.Proj_id.ToString(), OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue3", Document, OracleMappingType.Blob, ParameterDirection.Input);
           

            parameters.Add("Pimg_refcur", result, OracleMappingType.RefCursor, ParameterDirection.Output);
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
