using Business.Logic;
using DataAccess.Models;
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
        public string getName([FromRoute] string name)
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
        public async Task<IActionResult> GetDetails2([FromRoute] string flag,string para1,string para2)
        {
            var employeeDetailsResult = await _employeeModuleLogic.GetDetailsSer2(flag,para1,para2);
            if ((employeeDetailsResult is IActionResult actionResult))
            {
                return actionResult;
            }
            return BadRequest();
        }
        [HttpPost("PostDetailsemp")]
        public async Task<IActionResult> PostDetailsemp(string flag, string para1, string para2,string para3,string para4)
        {
            var employeeDetailsResult = await _employeeModuleLogic.PostDetailsempser1(flag, para1, para2,para3,para4);
            if ((employeeDetailsResult is IActionResult actionResult))
            {
                return actionResult;
            }
            return BadRequest();
        }
        //[HttpPost("PostDetails2")]
        //public async Task<IActionResult> PostDetails2([FromBody]EmployeeReqDto postdto)
        //{
        //    var employeeDetailsResult = await _employeeModuleLogic.PostDetailsempserM2(postdto);
        //    if ((employeeDetailsResult is IActionResult actionResult))
        //    {
        //        return actionResult;
        //    }
        //    return BadRequest();
        //}
        [HttpPost("PostDetails2")]
        public async Task<IActionResult> PostDetails2([FromBody] EmployeeReqDto postdto)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            if(!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .Select(e => new
                    {
                        Field = e.Key,
                        Messages = e.Value.Errors.Select(err => err.ErrorMessage).ToArray()
                    });
                return BadRequest(new
                {
                    Message = "validation failed",
                    Errors = errors
                });
            }
            else
            { 
                  var employeeDetailsResult = await _employeeModuleLogic.PostDetailsempserM2(postdto);
            if ((employeeDetailsResult is IActionResult actionResult))
            {
                return actionResult;
            }
            return BadRequest();
        }

                return BadRequest();
        }
        

        //[HttpPut("PutDetailsemp")]
        //public async Task<IActionResult> PutDetailsemp(string flag, string para1, string para2, string para3, string para4)
        //{
        //    var employeeDetailsResult = await _employeeModuleLogic.PutDetailsempser11(flag, para1, para2, para3, para4);
        //    if ((employeeDetailsResult is IActionResult actionResult))
        //    {
        //        return actionResult;
        //    }
        //    return BadRequest();
        //}
        [HttpPost("PostDetailsDocImg")]
        public async Task<IActionResult> PostDetailsDocImg(ImageReqDto postreq1 )
        {
            var employeeDetailsResult = await _employeeModuleLogic.PostDetailsDocser11(postreq1);
            if ((employeeDetailsResult is IActionResult actionResult))
            {
                return actionResult;
            }
            return BadRequest();
        }

        [HttpPut("PutDetailsupdate")]
        public async Task<IActionResult> PutDetailsupdate(EmployeeReqDto putdto)
        {
            var employeeDetailsResult = await _employeeModuleLogic.PutDetailsempserup2(putdto);
            if ((employeeDetailsResult is IActionResult actionResult))
            {
                return actionResult;
            }
            return BadRequest();
        }
        [HttpDelete("DeleteDetailsEmp")]
        public async Task<IActionResult> DeleteDetailsEmp(string flag,string para1)
        {
            var employeeDetailsResult = await _employeeModuleLogic.DeleteDetailsempserup2(flag,para1);
            if ((employeeDetailsResult is IActionResult actionResult))
            {
                return actionResult;
            }
            return BadRequest();
        }
        [HttpDelete("DeleteDetailsDocImg")]
        public async Task<IActionResult> DeleteDetailsDocImg(ImageReqDto deldto)
        {
            var employeeDetailsResult = await _employeeModuleLogic.DeleteDetailsDocser11(deldto);
            if ((employeeDetailsResult is IActionResult actionResult))
            {
                return actionResult;
            }
            return BadRequest();
        }

       

    }
}
