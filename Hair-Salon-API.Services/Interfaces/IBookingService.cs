using Hair_Salon_API.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair_Salon_API.Services.Interfaces
{
    public interface IBookingService
    {
        Task<BookingModel> AddBookingAsync(BookingModel bookingToAdd);

        Task<BookingModel> DeleteBookingAsync(int bookingId);

        Task<BookingModel> GetBookingAsync(int bookingId);

        Task<IEnumerable<BookingModel>> GetBookingsAsync();
        Task<IEnumerable<BookingModel>> GetBookingsByUserAsync(int userId);

        Task<BookingModel> UpdateBookingAsync(int bookingId, BookingModel bookingToUpdate);
    }
}
