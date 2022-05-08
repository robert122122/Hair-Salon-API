using Hair_Salon_API.DAL.Models;
using Hair_Salon_API.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hair_Salon_API.DAL.Repositories.Implementations
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(AppointmentsContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Review>> GetReviewsWithDetails()
        {
            return await _dbContext.Set<Review>()
                                   .Include(user => user.UserId)
                                   .ToListAsync();
        }
    }
}
