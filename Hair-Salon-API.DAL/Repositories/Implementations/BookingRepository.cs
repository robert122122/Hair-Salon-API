using Hair_Salon_API.DAL.Models;
using Hair_Salon_API.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hair_Salon_API.DAL.Repositories.Implementations
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(AppointmentsContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<Booking>> GetBookingsWithDetails()
        {
            return await _dbContext.Set<Booking>()
                                   .Include(salon => salon.Salon)
                                   .Include(service => service.Service)
                                   .Include(barber => barber.Barber)
                                   .ToListAsync();
        }
    }
}
