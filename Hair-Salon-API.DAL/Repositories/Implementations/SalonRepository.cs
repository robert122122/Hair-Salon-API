using Hair_Salon_API.DAL.Models;
using Hair_Salon_API.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hair_Salon_API.DAL.Repositories.Implementations
{
    public class SalonRepository:BaseRepository<Salon>,ISalonRepository
    {
        public SalonRepository(AppointmentsContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<Salon>> GetSalonsWithAddress()
        {
            return await _dbContext.Set<Salon>()
                                   .Include(address => address.Address)
                                   .ToListAsync();
        }
    }
}
