using Hair_Salon_API.Services.Models;

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
