using Hair_Salon_API.DAL.Models;
using Hair_Salon_API.DAL.Repositories.Interfaces;

namespace Hair_Salon_API.DAL.Repositories.Implementations
{
    public class ServiceRepository:BaseRepository<Service>, IServiceRepository
    {
        public ServiceRepository(AppointmentsContext dbContext) : base(dbContext) { }
    }
}
