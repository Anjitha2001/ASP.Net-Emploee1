using Business.Logic;
using DataAccess.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiExample1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectModuleController : ControllerBase
    {
        private readonly ProjectModuleLogic _projectModuleLogic;

        public ProjectModuleController(ProjectModuleLogic projectModuleLogic)
        {
            _projectModuleLogic = projectModuleLogic;
        }
        [HttpGet("GetDetailsproject")]
        public async Task<IActionResult> GetDetailsproject(string flag, string para1, string para2,string para3,string para4)
        {
            var projectDetailsResult = await _projectModuleLogic.GetDetailsLog2(flag, para1, para2,para3,para4);
            if ((projectDetailsResult is IActionResult actionResult))
            {
                return actionResult;
            }
            return BadRequest();
        }
        [HttpGet("GetDeatilsQuery")]
        public async Task<dynamic> GetDetails111()
        {
            var ProjectDetails = await _projectModuleLogic.GetDetailsLogic111();
            if (ProjectDetails == null)
            {
                return NotFound();
            }
            return Ok(ProjectDetails);

        }
        [HttpPost("PostDetailsProject")]
        public async Task<IActionResult> PostDetailsProject(string flag, string para1, string para2, string para3, string para4, string para5)
        {
            var ProjectDetailsResult = await _projectModuleLogic.PostDetailsProjectser1(flag, para1, para2, para3, para4, para5);
            if (ProjectDetailsResult is IActionResult actionResult)
            {
                return actionResult;
            }
            return BadRequest();
        }
        [HttpPost("PostDetailsM2")]
        public async Task<IActionResult> PostDetailsM2([FromBody] ProjectReqDto Opostdto)
        {
            var ProjectDetailsResult = await _projectModuleLogic.PostDetailsProjectserM2(Opostdto);
            if ((ProjectDetailsResult is IActionResult actionResult))
            {
                return actionResult;
            }
            return BadRequest();
        }
        [HttpPost("PostDetailsDoc")]
        public async Task<IActionResult> PostDetailsDoc([FromBody] DocReqdto postreqDoc)
        {
            var ProjectDetailsResult = await _projectModuleLogic.PostDetailsProjectserM2(postreqDoc);
            if ((ProjectDetailsResult is IActionResult actionResult))
            {
                return actionResult;
            }
            return BadRequest();
        }
        [HttpPut("PutDetailsImageproupdate")]
        public async Task<IActionResult> PutDetailsImageproupdate(ImageReqDto postreqImage)
        {
            var ProjectDetailsResult = await _projectModuleLogic.PostDetailsProjectUpdate(postreqImage);
            if ((ProjectDetailsResult is IActionResult actionResult))
            {
                return actionResult;
            }
            return BadRequest();
        }
        [HttpDelete("DeleteDetailsprojectCon")]
        public async Task<IActionResult> DeleteDetailsprojectCon(string flag,string para1)
        {
            var projectDetailsResult = await _projectModuleLogic.DeleteDetailsproser(flag,para1);
            if ((projectDetailsResult is IActionResult actionResult))
            {
                return actionResult;
            }
            return BadRequest();
        }
        [HttpDelete("DeleteDetailsDocProj")]
        public async Task<IActionResult> DeleteDetailsDocProj(DocReqdto deldocdto)
        {
            var ProjectDetailsResult = await _projectModuleLogic.DeleteDetailsProDocSer(deldocdto);
            if ((ProjectDetailsResult is IActionResult actionResult))
            {
                return actionResult;
            }
            return BadRequest();
        }
        [HttpPut("PutDetailsupdateProject")]
        public async Task<IActionResult> PutDetailsupdateProject(ProjectReqDto putprojdto)
        {
            var ProjectDetailsResult = await _projectModuleLogic.PutDetailsProjDto(putprojdto);
            if ((ProjectDetailsResult is IActionResult actionResult))
            {
                return actionResult;
            }
            return BadRequest();
        }

        [HttpPut("updateDetailsProjectDocument")]
        public async Task<IActionResult> updateDetailsProject(DocReqdto putDocdto)
        {
            var ProjectDetailsResult = await _projectModuleLogic.UpdateDocSer(putDocdto);
            if ((ProjectDetailsResult is IActionResult actionResult))
            {
                return actionResult;
            }
            return BadRequest();
        }
    }
}
