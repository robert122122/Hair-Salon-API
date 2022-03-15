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

        public SalonService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

            Address address = await _unitOfWork.AddressRepository.FindByIdAsync(existingSalon.AddressId);

            SalonGetModel salon = _mapper.Map<SalonGetModel>(existingSalon);
            salon.Address = address.City;

            return salon;
        }

        public async Task<IEnumerable<SalonGetModel>> GetSalonsAsync()
        {
            return _mapper.Map<IEnumerable<SalonGetModel>>(await _unitOfWork.SalonRepository.GetSalonsWithAddress());
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
