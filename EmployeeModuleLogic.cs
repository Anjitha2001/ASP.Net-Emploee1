using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Business.Logic
{
    public class EmployeeModuleLogic : ControllerBase
    {
        private readonly EmployeeModuleRepo _employeeModuleRepo;

        public EmployeeModuleLogic(EmployeeModuleRepo employeeModuleRepo)
        {
            _employeeModuleRepo = employeeModuleRepo;


        }
        public string GetNameLogic(string name)
        {
            return _employeeModuleRepo.GetNameRepo(name);
        }
        public async Task<dynamic> GetDetailsSer()
        {
            var EmployeeDetails = await _employeeModuleRepo.GetDetailsRepo1();
            if (EmployeeDetails == null)
            {

                return NotFound();
            }
            return Ok(EmployeeDetails);
        }
        public async Task<IActionResult> GetDetailsSer2(string flag,string para1,string para2)
        {
            var EmployeeDetails=await _employeeModuleRepo.GetDetailsRepo2(flag, para1, para2);  
            if (EmployeeDetails == null || !EmployeeDetails.Any()){


                return NotFound();
            }
            return Ok(EmployeeDetails);
            
        }
        public async Task<IActionResult> PostDetailsempser1(string flag, string para1, string para2, string para3,
            string para4)
        {
            var EmployeeDetails= await _employeeModuleRepo.PostDetailsEmpRepo1(flag, para1, para2,para3,para4);
            if (EmployeeDetails == null)
            {


                return NotFound();
            }
            return Ok(EmployeeDetails);

        }
        public async Task<IActionResult> PostDetailsempserM2(EmployeeReqDto postdto)
           
        {
            var EmployeeDetails = await _employeeModuleRepo.PostDetailsEmpRepoM2(postdto);
            if (EmployeeDetails == null)
            {


                return NotFound();
            }
            return Ok(EmployeeDetails);

        }
        //public async Task<IActionResult> PutDetailsempser11(string flag, string para1, string para2, string para3,
        //    string para4)
        //{
        //    var EmployeeDetails = await _employeeModuleRepo.PutDetailsEmpRepo11(flag, para1, para2, para3, para4);
        //    if (EmployeeDetails == null)
        //    {


        //        return NotFound();
        //    }
        //    return Ok(EmployeeDetails);

        //}
        public async Task<IActionResult> PostDetailsDocser11(ImageReqDto postreq1)
        {
            var EmployeeDetails = await _employeeModuleRepo.PostImageRepo(postreq1);
            if (EmployeeDetails == null)
            {


                return NotFound();
            }
            return Ok(EmployeeDetails);

        }
        public async Task<IActionResult> PutDetailsempserup(EmployeeReqDto putdto)
        {
            var EmployeeDetails = await _employeeModuleRepo.PutDetailsEmpRepoup(putdto);
            if (EmployeeDetails == null)
            {


                return NotFound();
            }
            return Ok(EmployeeDetails);

        }
        public async Task<IActionResult> PutDetailsempserup2(EmployeeReqDto putdto)
        {
            var EmployeeDetails = await _employeeModuleRepo.PutDetailsEmpRepoup(putdto);
            if (EmployeeDetails == null)
            {


                return NotFound();
            }
            return Ok(EmployeeDetails);

        }
        public async Task<IActionResult> DeleteDetailsempserup2(string flag, string para1)
        {
            var EmployeeDetails = await _employeeModuleRepo.DeleteDetailsEmpRepo11(flag,para1);
            if (EmployeeDetails == null)
            {


                return NotFound();
            }
            return Ok(EmployeeDetails);

        }
        public async Task<IActionResult> DeleteDetailsDocser11(ImageReqDto deldto)
        {
            var EmployeeDetails = await _employeeModuleRepo.DeleteDetailsEmpRepoDto(deldto);
            if (EmployeeDetails == null)
            {


                return NotFound();
            }
            return Ok(EmployeeDetails);

        }

    }
}
