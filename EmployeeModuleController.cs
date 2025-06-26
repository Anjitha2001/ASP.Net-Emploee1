using Business.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ApiExample1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeModuleController : ControllerBase
    {
        private readonly EmployeeModuleLogic _employeeModuleLogic;

        public EmployeeModuleController(EmployeeModuleLogic employeeModuleLogic)
        {
            _employeeModuleLogic = employeeModuleLogic;
        }
        [HttpGet("getName/{name}")]
        public string  getName([FromRoute] string name)
        {
            return _employeeModuleLogic.GetNameLogic(name);
        }
        [HttpGet("GetDetails")]
        public async Task<IActionResult> GetDetails()
        {
            var EmployeeDetails = await _employeeModuleLogic.GetDetailsSer();
            if (EmployeeDetails == null)
            {
                return NotFound();

            }
            return Ok(EmployeeDetails);
        }
        [HttpGet("GetDetails2")]
        public async Task<IActionResult> GetDetails2(string flag,string para1,string para2)
        {
            var employeeDetailsResult = await _employeeModuleLogic.GetDetailsSer2(flag,para1,para2);
            if ((employeeDetailsResult is IActionResult actionResult))
            {
                return actionResult;
            }
            return BadRequest();
        }

    }
}
