using Hair_Salon_API.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair_Salon_API.Services.Interfaces
{
    public interface IReviewService
    {
        Task<ReviewModel> AddReviewAsync(ReviewModel reviewToAdd);

        Task<ReviewModel> DeleteReviewAsync(int reviewId);

        Task<ReviewModel> GetReviewAsync(int ReviewId);

        Task<IEnumerable<ReviewModel>> GetReviewsAsync();
        Task<IEnumerable<ReviewModel>> GetReviewsByUserAsync(int userId);

        Task<IEnumerable<ReviewModel>> GetReviewsBySalonAsync(int salonId);

        Task<ReviewModel> UpdateReviewAsync(int reviewId, ReviewModel reviewToUpdate);
    }
}
