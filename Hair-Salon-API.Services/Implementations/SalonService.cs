using AutoMapper;
using Hair_Salon_API.DAL.Models;
using Hair_Salon_API.DAL.UnitOfWork;
using Hair_Salon_API.Services.Interfaces;
using Hair_Salon_API.Services.Models;

namespace Hair_Salon_API.Services.Implementations
{
    public class SalonService : ISalonService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IReviewService _reviewService;

        public SalonService(IUnitOfWork unitOfWork, IMapper mapper, IReviewService reviewService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _reviewService = reviewService;
        }

        public async Task<SalonModel> AddSalonAsync(SalonModel salonToAdd)
        {
            Salon newSalon = _mapper.Map<SalonModel, Salon>(salonToAdd);

            newSalon.DateAdded = DateTime.Now;
            newSalon.DateUpdated = DateTime.Now;

            _unitOfWork.SalonRepository.Add(newSalon);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Salon, SalonModel>(newSalon);
        }

        public async Task<SalonModel> DeleteSalonAsync(int salonId)
        {
            Salon existingSalon = await _unitOfWork.SalonRepository.FindByIdAsync(salonId);

            if (existingSalon == null)
            {
                throw new Exception("Salon does not exist");
            }

            _unitOfWork.SalonRepository.Remove(existingSalon);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Salon, SalonModel>(existingSalon);
        }

        public async Task<SalonGetModel> GetSalonAsync(int salonId)
        {
            Salon existingSalon = await _unitOfWork.SalonRepository.FindByIdAsync(salonId);

            if (existingSalon == null)
            {
                throw new Exception("Salon does not exist");
            }

            IEnumerable<ReviewModel> salonReviews = await _reviewService.GetReviewsBySalonAsync(salonId);

            Address address = await _unitOfWork.AddressRepository.FindByIdAsync(existingSalon.AddressId);

            SalonGetModel salon = _mapper.Map<SalonGetModel>(existingSalon);

            if (salonReviews == null)
            {
                salon.Rating = 0;
            }

            else
            {
                decimal totalRating = 0;
                foreach(var review in salonReviews)
                {
                    totalRating += review.Rating;
                }
                salon.Rating = totalRating/salonReviews.Count();
            }


            return salon;
        }

        public async Task<IEnumerable<SalonGetModel>> GetSalonsAsync()
        {

            IEnumerable<SalonGetModel> salons = _mapper.Map<IEnumerable<SalonGetModel>>(await _unitOfWork.SalonRepository.GetSalonsWithAddress());

            foreach(SalonGetModel salon in salons)
            {
                IEnumerable<ReviewModel> salonReviews = await _reviewService.GetReviewsBySalonAsync(salon.Id);

                if (salonReviews.Count() < 1)
                {
                    salon.Rating = 0;
                }

                else
                {
                    decimal totalRating = 0;
                    foreach (var review in salonReviews)
                    {
                        totalRating += review.Rating;
                    }
                    salon.Rating = totalRating / salonReviews.Count();
                }
            }

            return salons;
        }

        public async Task<SalonModel> UpdateSalonAsync(int salonId, SalonModel salonToUpdate)
        {
            Salon existingSalon = await _unitOfWork.SalonRepository.FindByIdAsync(salonId);

            if (existingSalon == null)
            {
                throw new Exception("Salon does not exist");
            }

            salonToUpdate.Id = existingSalon.Id;
            salonToUpdate.DateAdded = existingSalon.DateAdded;
            salonToUpdate.DateUpdated = DateTime.Now;

            _mapper.Map(salonToUpdate, existingSalon);

            _unitOfWork.SalonRepository.Update(existingSalon);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Salon, SalonModel>(existingSalon);
        }
    }
}
