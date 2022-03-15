using Hair_Salon_API.DAL.Models;

namespace Hair_Salon_API.DAL.Repositories.Interfaces
{
    public interface ISalonRepository : IBaseRepository<Salon>
    {
        Task<IEnumerable<Salon>> GetSalonsWithAddress();
    }
}
