using Hair_Salon_API.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair_Salon_API.Services.Interfaces
{
    public interface IServiceBarberService
    {
        Task<ServiceBarberModel> AddServiceBarberAsync(ServiceBarberModel serviceBarberToAdd);

        Task<ServiceBarberModel> DeleteServiceBarberAsync(int serviceBarberId);

        Task<ServiceBarberModel> GetServiceBarberAsync(int serviceBarberId);

        Task<IEnumerable<ServiceBarberModel>> GetServiceBarbersAsync();
        Task<IEnumerable<ServiceBarberModel>> GetServiceBarbersByServiceAsync(int serviceId);

        Task<ServiceBarberModel> UpdateServiceBarberAsync(int serviceBarberId, ServiceBarberModel serviceBarberToUpdate);
    }
}
