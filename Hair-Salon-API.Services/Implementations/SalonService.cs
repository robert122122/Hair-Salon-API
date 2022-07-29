using AutoMapper;
using Hair_Salon_API.Common.Interfaces;
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
        private readonly IEncryptService _encryptService;

        public SalonService(IUnitOfWork unitOfWork, IMapper mapper, IReviewService reviewService, IEncryptService encryptService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _reviewService = reviewService;
            _encryptService = encryptService;
        }

        public async Task<SalonModel> AddSalonAsync(SalonModel salonToAdd)
        {
            Salon newSalon = _mapper.Map<SalonModel, Salon>(salonToAdd);

            newSalon.DateAdded = DateTime.Now;
            newSalon.DateUpdated = DateTime.Now;
            newSalon.Password = _encryptService.Encrypt(salonToAdd.Password);

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

        public async Task<SalonModel> GetSalonAsync(int salonId)
        {
            Salon existingSalon = await _unitOfWork.SalonRepository.FindByIdAsync(salonId);

            if (existingSalon == null)
            {
                throw new Exception("Salon does not exist");
            }

            IEnumerable<ReviewGetModel> salonReviews = await _reviewService.GetReviewsBySalonAsync(salonId);

            SalonModel salon = _mapper.Map<SalonModel>(existingSalon);

            if (salonReviews.Count() < 1)
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
                salon.Rating = Math.Round(totalRating / salonReviews.Count(), 2);
            }

            return salon;
        }

        public async Task<IEnumerable<SalonGetModel>> GetSalonsAsync()
        {

            IEnumerable<SalonGetModel> salons = _mapper.Map<IEnumerable<SalonGetModel>>(await _unitOfWork.SalonRepository.GetSalonsWithAddress());

            foreach(SalonGetModel salon in salons)
            {
                IEnumerable<ReviewGetModel> salonReviews = await _reviewService.GetReviewsBySalonAsync(salon.Id);

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
                    salon.Rating = Math.Round(totalRating / salonReviews.Count(), 2);
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
            salonToUpdate.Password = existingSalon.Password;
            salonToUpdate.AddressId = existingSalon.AddressId;

            _mapper.Map(salonToUpdate, existingSalon);

            _unitOfWork.SalonRepository.Update(existingSalon);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Salon, SalonModel>(existingSalon);
        }

        public async Task<SalonModel> AddAddressToSalonAsync(int addressId, int salonId)
        {
            Salon existingSalon = await _unitOfWork.SalonRepository.FindByIdAsync(salonId);

            if (existingSalon == null)
            {
                throw new Exception("Salon does not exist");
            }

            Address existingAddress = await _unitOfWork.AddressRepository.FindByIdAsync(addressId);

            if (existingAddress == null)
            {
                throw new Exception("Address does not exist");
            }

            existingSalon.AddressId = addressId;

            _unitOfWork.SalonRepository.Update(existingSalon);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Salon, SalonModel>(existingSalon);
        }

        public async Task<SalonModel> Authenticate(AuthenticateRequest model)
        {
            Salon existingSalon = (await _unitOfWork.SalonRepository.FindAsync(x => x.Email == model.Email)).FirstOrDefault();
            string encryptedPassword = _encryptService.Encrypt(model.Password);

            if (existingSalon == null || existingSalon.Password != encryptedPassword)
            {
                return null;
            }

            SalonModel mappedExistingSalon = _mapper.Map<SalonModel>(existingSalon);

            return mappedExistingSalon;
        }
    }
}
