using Microsoft.EntityFrameworkCore;
using ResidentApi.Logic.Database;
using ResidentApi.Logic.Domain;

namespace ResidentApi.Logic.Repositories
{
    public class ResidentRepository : IResidentRepository
    {
        private readonly ResidentDbContext _dbContext;

        public ResidentRepository(ResidentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateResidentAsync(Resident resident)
        {
            await _dbContext.Residents.AddAsync(resident);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteResidentAsync(Guid residentId)
        {
            var resident = await GetResidentByIdAsync(residentId);

            if(resident is not null)
            {
                _dbContext.Residents.Remove(resident);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Resident>> GetAllResidentsAsync()
        {
            return await _dbContext.Residents.AsNoTracking().ToListAsync();
        }

        public async Task<Resident?> GetResidentByIdAsync(Guid residentId)
        {
            return await _dbContext.Residents.FirstOrDefaultAsync(r => r.Id == residentId);
        }

        public async Task UpdateResidentAsync(Resident resident)
        {
            throw new NotImplementedException();
        }
    }
}
