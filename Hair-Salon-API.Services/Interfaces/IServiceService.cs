using Hair_Salon_API.Services.Models;

namespace Hair_Salon_API.Services.Interfaces
{
    public interface IServiceService
    {
        Task<ServiceModel> AddServiceAsync(ServiceModel serviceToAdd);

        Task<ServiceModel> DeleteServiceAsync(int serviceId);

        Task<ServiceModel> GetServiceAsync(int serviceId);

        Task<IEnumerable<ServiceModel>> GetServicesAsync();
        Task<IEnumerable<ServiceModel>> GetServicesBySalonAsync(int salonId);

        Task<ServiceModel> UpdateServiceAsync(int serviceId, ServiceModel serviceToUpdate);
    }
}
