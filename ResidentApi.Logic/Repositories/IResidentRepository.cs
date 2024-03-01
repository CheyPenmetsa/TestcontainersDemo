using ResidentApi.Logic.Domain;

namespace ResidentApi.Logic.Repositories
{
    public interface IResidentRepository
    {
        Task CreateResidentAsync(Resident resident);

        Task<Resident?> GetResidentByIdAsync(Guid residentId);

        Task DeleteResidentAsync(Guid residentId);

        Task UpdateResidentAsync(Resident resident);

        Task<IEnumerable<Resident>> GetAllResidentsAsync();
    }
}
