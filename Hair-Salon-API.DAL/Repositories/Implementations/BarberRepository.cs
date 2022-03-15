using Hair_Salon_API.DAL.Models;
using Hair_Salon_API.DAL.Repositories.Interfaces;

namespace Hair_Salon_API.DAL.Repositories.Implementations
{
    public class BarberRepository: BaseRepository<Barber>, IBarberRepository
    {
        public BarberRepository(AppointmentsContext dbContext) : base(dbContext) { }
    }
}
