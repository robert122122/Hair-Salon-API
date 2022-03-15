using Hair_Salon_API.DAL.Models;
using Hair_Salon_API.DAL.Repositories.Interfaces;

namespace Hair_Salon_API.DAL.Repositories.Implementations
{
    public class ServiceBarberRepository: BaseRepository<ServiceBarber>, IServiceBarberRepository
    {
        public ServiceBarberRepository(AppointmentsContext dbContext) : base(dbContext) { }
    }
}
