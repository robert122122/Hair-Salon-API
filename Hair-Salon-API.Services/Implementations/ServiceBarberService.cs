using AutoMapper;
using Hair_Salon_API.DAL.Models;
using Hair_Salon_API.DAL.UnitOfWork;
using Hair_Salon_API.Services.Interfaces;
using Hair_Salon_API.Services.Models;
namespace Hair_Salon_API.Services.Implementations
{
    public class ServiceBarberService : IServiceBarberService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServiceBarberService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceBarberModel> AddServiceBarberAsync(ServiceBarberModel serviceBarberToAdd)
        {
            Service existingService = await _unitOfWork.ServiceRepository.FindByIdAsync(serviceBarberToAdd.ServiceId);
            if (existingService == null)
            {
                throw new Exception("Service doesnt exists!");
            }

            Barber existingBarber = await _unitOfWork.BarberRepository.FindByIdAsync(serviceBarberToAdd.BarberId);
            if (existingBarber == null)
            {
                throw new Exception("Barber doesnt exists!");
            }

            ServiceBarber newServiceBarber = _mapper.Map<ServiceBarberModel, ServiceBarber>(serviceBarberToAdd);

            newServiceBarber.DateAdded = DateTime.Now;
            newServiceBarber.DateUpdated = DateTime.Now;

            _unitOfWork.ServiceBarberRepository.Add(newServiceBarber);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<ServiceBarber, ServiceBarberModel>(newServiceBarber);
        }

        public async Task<ServiceBarberModel> DeleteServiceBarberAsync(int serviceBarberId)
        {
            ServiceBarber existingServiceBarber = await _unitOfWork.ServiceBarberRepository.FindByIdAsync(serviceBarberId);

            if (existingServiceBarber == null)
            {
                throw new Exception("Service Barber does not exist");
            }

            _unitOfWork.ServiceBarberRepository.Remove(existingServiceBarber);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<ServiceBarber, ServiceBarberModel>(existingServiceBarber);
        }

        public async Task<ServiceBarberModel> GetServiceBarberAsync(int serviceBarberId)
        {
            ServiceBarber existingServiceBarber = await _unitOfWork.ServiceBarberRepository.FindByIdAsync(serviceBarberId);

            if (existingServiceBarber == null)
            {
                throw new Exception("Service Barber does not exist");
            }

            return _mapper.Map<ServiceBarberModel>(existingServiceBarber);
        }

        public async Task<IEnumerable<ServiceBarberModel>> GetServiceBarbersAsync()
        {
            return _mapper.Map<IEnumerable<ServiceBarberModel>>(await _unitOfWork.ServiceBarberRepository.FindAllAsync());
        }

        public async Task<IEnumerable<ServiceBarberModel>> GetServiceBarbersByServiceAsync(int serviceId)
        {
            Service existingService = await _unitOfWork.ServiceRepository.FindByIdAsync(serviceId);
            if (existingService == null)
            {
                throw new Exception("Service does not exists!");
            }

            IEnumerable<ServiceBarber> servicesBarbers = await _unitOfWork.ServiceBarberRepository.FindAsync(serviceBarber => serviceBarber.ServiceId == serviceId);

            if (servicesBarbers == null)
            {
                throw new Exception("Services not found.");
            }

            return _mapper.Map<IEnumerable<ServiceBarberModel>>(servicesBarbers);
        }

        public async Task<ServiceBarberModel> UpdateServiceBarberAsync(int serviceBarberId, ServiceBarberModel serviceBarberToUpdate)
        {
            ServiceBarber existingServiceBarber = await _unitOfWork.ServiceBarberRepository.FindByIdAsync(serviceBarberId);

            if (existingServiceBarber == null)
            {
                throw new Exception("Service Barber does not exist");
            }

            serviceBarberToUpdate.Id = existingServiceBarber.Id;
            serviceBarberToUpdate.DateAdded = existingServiceBarber.DateAdded;
            serviceBarberToUpdate.DateUpdated = DateTime.Now;

            _mapper.Map(serviceBarberToUpdate, existingServiceBarber);

            _unitOfWork.ServiceBarberRepository.Update(existingServiceBarber);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<ServiceBarber, ServiceBarberModel>(existingServiceBarber);
        }
    }
}
