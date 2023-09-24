using Core.Entities;

namespace Core.Interfaces
{
    public interface IProgramDetailRepository
    {
        Task<ProgramDetail> GetProgramDetailByIdAsync(int id);
        Task<IReadOnlyList<ProgramDetail>> GetAllProgramDetailsAsync();
        Task<ProgramDetail> CreateProgramDetailAsync(ProgramDetail programDetail);
        Task<ProgramDetail> UpdateProgramDetailAsync(ProgramDetail programDetail);
        Task DeleteProgramDetailAsync(int id);
    }

}