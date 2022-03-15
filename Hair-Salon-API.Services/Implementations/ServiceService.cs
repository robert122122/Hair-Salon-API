using AutoMapper;
using Hair_Salon_API.DAL.Models;
using Hair_Salon_API.DAL.UnitOfWork;
using Hair_Salon_API.Services.Interfaces;
using Hair_Salon_API.Services.Models;

namespace Hair_Salon_API.Services.Implementations
{
    public class ServiceService : IServiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServiceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceModel> AddServiceAsync(ServiceModel serviceToAdd)
        {
            Salon existingSalon = await _unitOfWork.SalonRepository.FindByIdAsync(serviceToAdd.SalonId);
            if (existingSalon == null)
            {
                throw new Exception("Salon doesnt exists!");
            }

            Service newService = _mapper.Map<ServiceModel, Service>(serviceToAdd);

            newService.DateAdded = DateTime.Now;
            newService.DateUpdated = DateTime.Now;

            _unitOfWork.ServiceRepository.Add(newService);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Service, ServiceModel>(newService);
        }

        public async Task<ServiceModel> DeleteServiceAsync(int serviceId)
        {
            Service existingService = await _unitOfWork.ServiceRepository.FindByIdAsync(serviceId);

            if (existingService == null)
            {
                throw new Exception("Service does not exist");
            }

            _unitOfWork.ServiceRepository.Remove(existingService);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Service, ServiceModel>(existingService);
        }

        public async Task<ServiceModel> GetServiceAsync(int serviceId)
        {
            Service existingService = await _unitOfWork.ServiceRepository.FindByIdAsync(serviceId);

            if (existingService == null)
            {
                throw new Exception("Service does not exist");
            }

            return _mapper.Map<ServiceModel>(existingService);
        }

        public async Task<IEnumerable<ServiceModel>> GetServicesAsync()
        {
            return _mapper.Map<IEnumerable<ServiceModel>>(await _unitOfWork.ServiceRepository.FindAllAsync());
        }

        public async Task<IEnumerable<ServiceModel>> GetServicesBySalonAsync(int salonId)
        {
            Salon existingSalon = await _unitOfWork.SalonRepository.FindByIdAsync(salonId);
            if (existingSalon == null)
            {
                throw new Exception("Salon does not exists!");
            }

            IEnumerable<Service> services = await _unitOfWork.ServiceRepository.FindAsync(service => service.SalonId == salonId);

            if (services == null)
            {
                throw new Exception("Services not found.");
            }

            IEnumerable<Service> bla = services.OrderBy(x => x.Cost).ToList();

            return _mapper.Map<IEnumerable<ServiceModel>>(bla);
        }

        public async Task<ServiceModel> UpdateServiceAsync(int serviceId, ServiceModel serviceToUpdate)
        {
            Service existingService = await _unitOfWork.ServiceRepository.FindByIdAsync(serviceId);

            if (existingService == null)
            {
                throw new Exception("Service does not exist");
            }

            serviceToUpdate.Id = existingService.Id;
            serviceToUpdate.DateAdded = existingService.DateAdded;
            serviceToUpdate.DateUpdated = DateTime.Now;
            serviceToUpdate.SalonId = existingService.SalonId;

            _mapper.Map(serviceToUpdate, existingService);

            _unitOfWork.ServiceRepository.Update(existingService);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Service, ServiceModel>(existingService);
        }
    }
}
