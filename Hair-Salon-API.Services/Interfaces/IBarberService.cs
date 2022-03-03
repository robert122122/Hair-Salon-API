using Hair_Salon_API.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair_Salon_API.Services.Interfaces
{
    public interface IBarberService
    {
        Task<BarberModel> AddBarberAsync(BarberModel barberToAdd);

        Task<BarberModel> DeleteBarberAsync(int barberId);

        Task<BarberModel> GetBarberAsync(int barberId);

        Task<IEnumerable<BarberModel>> GetBarbersAsync();
        Task<IEnumerable<BarberModel>> GetBarbersBySalonAsync(int salonId);

        Task<BarberModel> UpdateBarberAsync(int barberId, BarberModel barberToUpdate);
    }
}
