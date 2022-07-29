using Hair_Salon_API.Services.Models;

namespace Hair_Salon_API.Services.Interfaces
{
    public interface ISalonService
    {
        Task<SalonModel> AddSalonAsync(SalonModel salonToAdd);

        Task<SalonModel> DeleteSalonAsync(int salonId);

        Task<SalonModel> GetSalonAsync(int salonId);

        Task<IEnumerable<SalonGetModel>> GetSalonsAsync();

        Task<SalonModel> UpdateSalonAsync(int salonId, SalonModel salonToUpdate);

        Task<SalonModel> AddAddressToSalonAsync(int addressId, int salonId);

        Task<SalonModel> Authenticate (AuthenticateRequest request);
    }
}
