using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Business.Logic
{
    public class ProjectModuleLogic:ControllerBase
    {
        private readonly projectModuleRepo _projectModuleRepo;

        public ProjectModuleLogic(projectModuleRepo projectModuleRepo)
        {
            _projectModuleRepo = projectModuleRepo;


        }
        public async Task<dynamic> GetDetailsLogic111()
        {
            var ProjectDetails = await _projectModuleRepo.GetDetailsRepo434();
            if (ProjectDetails == null)
            {
                return NotFound();
            }
            return Ok(ProjectDetails);

        }
        public async Task<IActionResult> GetDetailsLog2(string flag, string para1, string para2,string para3,string para4)
        {
            var ProjectDetails = await _projectModuleRepo.GetDetailsPro(flag, para1, para2,para3,para4);
            if (ProjectDetails == null || !ProjectDetails.Any())
            {


                return NotFound();
            }
            return Ok(ProjectDetails);

        }
        public async Task<IActionResult> PostDetailsProjectser1(string flag, string para1, string para2, string para3,
           string para4, string para5)
        {
            var ProjectDetails = await _projectModuleRepo.PostDetailsProjectRepo1(flag, para1, para2, para3, para4,para5);
            if (ProjectDetails == null)
            {


                return NotFound();
            }
            return Ok(ProjectDetails);

        }
        public async Task<IActionResult> PostDetailsProjectserM2(DocReqdto postreqDoc)

        {
            var ProjectDetails = await _projectModuleRepo.PostDocrepo(postreqDoc);
            if (ProjectDetails == null)
            {


                return NotFound();
            }
            return Ok(ProjectDetails);

        }
        public async Task<IActionResult> PostDetailsProjectserM2(ProjectReqDto Opostdto)

        {
            var ProjectDetails = await _projectModuleRepo.PostDetailsProjectRepoM2(Opostdto);
            if (ProjectDetails == null)
            {


                return NotFound();
            }
            return Ok(ProjectDetails);

        }
        public async Task<IActionResult> PostDetailsProjectUpdate(ImageReqDto postreqImage)

        {
            var ProjectDetails = await _projectModuleRepo.PostImageRepo(postreqImage);
            if (ProjectDetails == null)
            {


                return NotFound();
            }
            return Ok(ProjectDetails);
        }
        public async Task<IActionResult> DeleteDetailsproser(string flag,string para1)
        {
            var ProjectDetails = await _projectModuleRepo.DeleteDetailsProject(flag,para1);
            if (ProjectDetails == null)
            {


                return NotFound();
            }
            return Ok(ProjectDetails);

        }
        public async Task<IActionResult> DeleteDetailsProDocSer(DocReqdto deldocdto)
        {
            var ProjectDetails = await _projectModuleRepo.DeleteDetailsProDoc(deldocdto);
            if (ProjectDetails == null)
            {


                return NotFound();
            }
            return Ok(ProjectDetails);

        }
        public async Task<IActionResult> PutDetailsProjDto(ProjectReqDto putprojdto)
        {
            var ProjectDetails = await _projectModuleRepo.PutDetailsProjDto(putprojdto);
            if (ProjectDetails == null)
            {


                return NotFound();
            }
            return Ok(ProjectDetails);

        }
        public async Task<IActionResult> UpdateDocSer(DocReqdto putDocdto)
        {
            var ProjectDetails = await _projectModuleRepo.UpdateDetailsProDoc(putDocdto);
            if (ProjectDetails == null)
            {


                return NotFound();
            }
            return Ok(ProjectDetails);

        }
    }
    }
