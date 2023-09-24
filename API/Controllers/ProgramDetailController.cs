using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgramDetailController : ControllerBase
    {
        private readonly IProgramDetailRepository _programDetailRepository;
        public ProgramDetailController(IProgramDetailRepository programDetailRepository)
        {
            _programDetailRepository = programDetailRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProgramDetail>>> GetAllProgramDetail()
        {
            return Ok(await _programDetailRepository.GetAllProgramDetailsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProgramDetail>> GetProgramDetail(int id)
        {
            return Ok(await _programDetailRepository.GetProgramDetailByIdAsync(id));
        }

        [HttpPost]
        public async Task<ProgramDetail> AddProgramDetail(ProgramDetail programDetail)
        {
            await _programDetailRepository.CreateProgramDetailAsync(programDetail);
            return programDetail;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProgramDetail>> UpdateProgramDetail(int id, ProgramDetail programDetail)
        {
            var existingProgramDetail = await _programDetailRepository.GetProgramDetailByIdAsync(id);
            
            if (existingProgramDetail == null)
            {
                return NotFound();
            }

            existingProgramDetail.ProgramTitle = programDetail.ProgramTitle;
            existingProgramDetail.Summary = programDetail.Summary;
            existingProgramDetail.Description = programDetail.Description;
            existingProgramDetail.KeySkills = programDetail.KeySkills;
            existingProgramDetail.Benefits = programDetail.Benefits;
            existingProgramDetail.ApplicationCriteria = programDetail.ApplicationCriteria;

            var updatedProgramDetail = await _programDetailRepository.UpdateProgramDetailAsync(existingProgramDetail);
            
            return Ok(updatedProgramDetail);
        }


        [HttpDelete]
        public async Task DeleteProgramDetail(int id)
        {
            await _programDetailRepository.DeleteProgramDetailAsync(id);
        }
    }
}