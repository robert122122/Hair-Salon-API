using AutoMapper;
using Hair_Salon_API.DAL.Models;
using Hair_Salon_API.DAL.UnitOfWork;
using Hair_Salon_API.Services.Interfaces;
using Hair_Salon_API.Services.Models;

namespace Hair_Review_API.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReviewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ReviewModel> AddReviewAsync(ReviewModel reviewToAdd)
        {
            Review newReview = _mapper.Map<ReviewModel, Review>(reviewToAdd);

            newReview.DateAdded = DateTime.Now;
            newReview.DateUpdated = DateTime.Now;

            _unitOfWork.ReviewRepository.Add(newReview);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Review, ReviewModel>(newReview);
        }

        public async Task<ReviewModel> DeleteReviewAsync(int reviewId)
        {
            Review existingReview = await _unitOfWork.ReviewRepository.FindByIdAsync(reviewId);

            if (existingReview == null)
            {
                throw new Exception("Review does not exist");
            }

            _unitOfWork.ReviewRepository.Remove(existingReview);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Review, ReviewModel>(existingReview);
        }

        public async Task<ReviewModel> GetReviewAsync(int reviewId)
        {
            Review existingReview = await _unitOfWork.ReviewRepository.FindByIdAsync(reviewId);

            if (existingReview == null)
            {
                throw new Exception("Review does not exist");
            }

            return _mapper.Map<ReviewModel>(existingReview);
        }

        public async Task<IEnumerable<ReviewModel>> GetReviewsAsync()
        {
            return _mapper.Map<IEnumerable<ReviewModel>>(await _unitOfWork.ReviewRepository.FindAllAsync());
        }

        public async Task<IEnumerable<ReviewGetModel>> GetReviewsBySalonAsync(int salonId)
        {
            Salon existingSalon = await _unitOfWork.SalonRepository.FindByIdAsync(salonId);
            if (existingSalon == null)
            {
                throw new Exception("Salon does not exists!");
            }

            IEnumerable<ReviewGetModel> reviews = _mapper.Map<IEnumerable<ReviewGetModel>> (await _unitOfWork.ReviewRepository.FindAsync(review => review.SalonId == salonId));

            if (reviews == null)
            {
                throw new Exception("Reviews not found.");
            }

            foreach(ReviewGetModel review in reviews)
            {
                Review existingReview = await _unitOfWork.ReviewRepository.FindByIdAsync (review.Id);

                User user = await _unitOfWork.UserRepository.FindByIdAsync(existingReview.UserId);

                review.UserName = user.FirstName + " " + user.LastName;
            }

            return reviews;
        }

        public async Task<IEnumerable<ReviewModel>> GetReviewsByUserAsync(int userId)
        {
            User existingUser = await _unitOfWork.UserRepository.FindByIdAsync(userId);
            if (existingUser == null)
            {
                throw new Exception("User does not exists!");
            }

            IEnumerable<Review> reviews = await _unitOfWork.ReviewRepository.FindAsync(review => review.UserId == userId);

            if (reviews == null)
            {
                throw new Exception("Reviews not found.");
            }

            return _mapper.Map<IEnumerable<ReviewModel>>(reviews);
        }

        public async Task<ReviewModel> UpdateReviewAsync(int reviewId, ReviewModel reviewToUpdate)
        {
            Review existingReview = await _unitOfWork.ReviewRepository.FindByIdAsync(reviewId);

            if (existingReview == null)
            {
                throw new Exception("Review does not exist");
            }

            reviewToUpdate.Id = existingReview.Id;
            reviewToUpdate.DateAdded = existingReview.DateAdded;
            reviewToUpdate.DateUpdated = DateTime.Now;

            _mapper.Map(reviewToUpdate, existingReview);

            _unitOfWork.ReviewRepository.Update(existingReview);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Review, ReviewModel>(existingReview);
        }
    }
}
