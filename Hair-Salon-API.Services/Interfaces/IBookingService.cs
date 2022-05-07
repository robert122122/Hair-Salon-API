using Hair_Salon_API.Services.Models;

namespace Hair_Salon_API.Services.Interfaces
{
    public interface IBookingService
    {
        Task<BookingModel> AddBookingAsync(BookingModel bookingToAdd);

        Task<BookingModel> DeleteBookingAsync(int bookingId);

        Task<BookingGetModel> GetBookingAsync(int bookingId);

        Task<IEnumerable<BookingGetModel>> GetBookingsAsync();
        Task<IEnumerable<BookingGetModel>> GetBookingsByUserAsync(int userId);

        Task<BookingModel> UpdateBookingAsync(int bookingId, BookingModel bookingToUpdate);
    }
}
