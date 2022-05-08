using Hair_Salon_API.DAL.Models;

namespace Hair_Salon_API.DAL.Repositories.Interfaces
{
    public interface IReviewRepository : IBaseRepository<Review>
    {
        Task<IEnumerable<Review>> GetReviewsWithDetails();
    }
}
