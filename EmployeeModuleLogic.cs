using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
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
    }
}
