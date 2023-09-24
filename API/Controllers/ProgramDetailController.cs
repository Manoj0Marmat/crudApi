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
        public async Task<ActionResult<IReadOnlyList<ProgramDetail>>> GetProgramDetails()
        {
            return Ok(await _programDetailRepository.GetAllProgramDetailsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IReadOnlyList<ProgramDetail>> GetProgramDetail(int id)
        {

        }

        [HttpPost]
        public async Task<ProgramDetail> AddProgramDetails(ProgramDetail programDetail)
        {
            await _programDetailRepository.CreateProgramDetailAsync(programDetail);
            return programDetail;
        }

        [HttpDelete]
        public async Task DeleteProgramDetails(int id)
        {
            await _programDetailRepository.DeleteProgramDetailAsync(id);
        }
    }
}