using Hair_Salon_API.DAL.Models;
using Hair_Salon_API.DAL.Repositories.Interfaces;

namespace Hair_Salon_API.DAL.Repositories.Implementations
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(AppointmentsContext dbContext) : base(dbContext) { }
    }
}
