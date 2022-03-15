using AutoMapper;
using Hair_Salon_API.DAL.Models;
using Hair_Salon_API.DAL.UnitOfWork;
using Hair_Salon_API.Services.Interfaces;
using Hair_Salon_API.Services.Models;

namespace Hair_Salon_API.Services.Implementations
{
    public class BarberService : IBarberService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BarberService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BarberModel> AddBarberAsync(BarberModel barberToAdd)
        {
            Salon existingSalon = await _unitOfWork.SalonRepository.FindByIdAsync(barberToAdd.SalonId);
            if(existingSalon == null)
            {
                throw new Exception("Salon doesnt exists!");
            }

            Barber newBarber = _mapper.Map<BarberModel, Barber>(barberToAdd);

            newBarber.DateAdded = DateTime.Now;
            newBarber.DateUpdated = DateTime.Now;

            _unitOfWork.BarberRepository.Add(newBarber);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Barber, BarberModel>(newBarber);
        }

        public async Task<BarberModel> DeleteBarberAsync(int barberId)
        {
            Barber existingBarber = await _unitOfWork.BarberRepository.FindByIdAsync(barberId);

            if (existingBarber == null)
            {
                throw new Exception("Barber does not exist");
            }

            _unitOfWork.BarberRepository.Remove(existingBarber);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Barber, BarberModel>(existingBarber);
        }

        public async Task<BarberModel> GetBarberAsync(int barberId)
        {
            Barber existingBarber = await _unitOfWork.BarberRepository.FindByIdAsync(barberId);

            if (existingBarber == null)
            {
                throw new Exception("Barber does not exist");
            }

            return _mapper.Map<BarberModel>(existingBarber);
        }

        public async Task<IEnumerable<BarberModel>> GetBarbersAsync()
        {
            return _mapper.Map<IEnumerable<BarberModel>>(await _unitOfWork.BarberRepository.FindAllAsync());
        }

        public async Task<IEnumerable<BarberModel>> GetBarbersBySalonAsync(int salonId)
        {
            Salon existingSalon = await _unitOfWork.SalonRepository.FindByIdAsync(salonId);
            if (existingSalon == null)
            {
                throw new Exception("Salon does not exists!");
            }

            IEnumerable<Barber> barbers = await _unitOfWork.BarberRepository.FindAsync(barber => barber.SalonId == salonId);

            if (barbers == null)
            {
                throw new Exception("Barbers not found.");
            }

            return _mapper.Map<IEnumerable<BarberModel>>(barbers);
        }

        public async Task<BarberModel> UpdateBarberAsync(int barberId, BarberModel barberToUpdate)
        {
            Barber existingBarber = await _unitOfWork.BarberRepository.FindByIdAsync(barberId);

            if (existingBarber == null)
            {
                throw new Exception("Barber does not exist");
            }

            barberToUpdate.Id = existingBarber.Id;
            barberToUpdate.DateAdded = existingBarber.DateAdded;
            barberToUpdate.DateUpdated = DateTime.Now;
            barberToUpdate.SalonId = existingBarber.SalonId;

            _mapper.Map(barberToUpdate, existingBarber);

            _unitOfWork.BarberRepository.Update(existingBarber);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Barber, BarberModel>(existingBarber);
        }
    }
}
