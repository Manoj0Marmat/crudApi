using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data
{
    public class ProgramDetailRepository : IProgramDetailRepository
    {
        private static List<ProgramDetail> repo = new();

        public async Task<ProgramDetail> CreateProgramDetailAsync(ProgramDetail programDetail)
        {
            repo.Add(programDetail);
            return await Task.FromResult(programDetail);
        }

        public async Task DeleteProgramDetailAsync(int id)
        {
            var programToDelete = repo.FirstOrDefault(p => p.Id == id);
            if (programToDelete != null)
            {
                repo.Remove(programToDelete);
            }
            await Task.CompletedTask;
        }

        public async Task<IReadOnlyList<ProgramDetail>> GetAllProgramDetailsAsync()
        {
            return repo.ToList();
        }

        public async Task<ProgramDetail> GetProgramDetailByIdAsync(int id)
        {
            var program = repo.FirstOrDefault(p => p.Id == id);
            return await Task.FromResult(program);
        }

        public async Task<ProgramDetail> UpdateProgramDetailAsync(ProgramDetail programDetail)
        {
            var existingProgram = repo.FirstOrDefault(p => p.Id == programDetail.Id);
            if (existingProgram != null)
            {
                existingProgram.Description = programDetail.Description;
            }
            return await Task.FromResult(existingProgram);
        }
    }
}
