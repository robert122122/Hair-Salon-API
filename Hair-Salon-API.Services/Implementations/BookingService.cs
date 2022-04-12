using AutoMapper;
using Hair_Salon_API.DAL.Models;
using Hair_Salon_API.DAL.UnitOfWork;
using Hair_Salon_API.Services.Interfaces;
using Hair_Salon_API.Services.Models;

namespace Hair_Salon_API.Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BookingModel> AddBookingAsync(BookingModel bookingToAdd)
        {
            Salon existingSalon = await _unitOfWork.SalonRepository.FindByIdAsync(bookingToAdd.SalonId);
            if (existingSalon == null)
            {
                throw new Exception("Salon doesnt exists!");
            }

            Service existingService = await _unitOfWork.ServiceRepository.FindByIdAsync(bookingToAdd.ServiceId);
            if (existingService == null)
            {
                throw new Exception("Service doesnt exists!");
            }

            Barber existingBarber = await _unitOfWork.BarberRepository.FindByIdAsync(bookingToAdd.BarberId);
            if (existingBarber == null)
            {
                throw new Exception("Barber doesnt exists!");
            }

            Booking newBooking = _mapper.Map<BookingModel, Booking>(bookingToAdd);

            newBooking.BookingChanged = DateTime.Now;
            newBooking.Paid = false;

            _unitOfWork.BookingRepository.Add(newBooking);


            await _unitOfWork.CommitAsync();

            return _mapper.Map<Booking, BookingModel>(newBooking);
        }

        public async Task<BookingModel> DeleteBookingAsync(int bookingId)
        {
            Booking existingBooking = await _unitOfWork.BookingRepository.FindByIdAsync(bookingId);

            if (existingBooking == null)
            {
                throw new Exception("Booking does not exist");
            }

            _unitOfWork.BookingRepository.Remove(existingBooking);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Booking, BookingModel>(existingBooking);
        }

        public async Task<BookingModel> GetBookingAsync(int bookingId)
        {
            Booking existingBooking = await _unitOfWork.BookingRepository.FindByIdAsync(bookingId);

            if (existingBooking == null)
            {
                throw new Exception("Booking does not exist");
            }

            return _mapper.Map<BookingModel>(existingBooking);
        }

        public async Task<IEnumerable<BookingModel>> GetBookingsAsync()
        {
            return _mapper.Map<IEnumerable<BookingModel>>(await _unitOfWork.BookingRepository.FindAllAsync());
        }

        public async Task<IEnumerable<BookingModel>> GetBookingsByUserAsync(int userId)
        {
            User existingUser = await _unitOfWork.UserRepository.FindByIdAsync(userId);
            if (existingUser == null)
            {
                throw new Exception("User does not exists!");
            }

            IEnumerable<Booking> bookings = await _unitOfWork.BookingRepository.FindAsync(booking => booking.UserId == userId);

            if (bookings == null)
            {
                throw new Exception("Bookings not found.");
            }

            return _mapper.Map<IEnumerable<BookingModel>>(bookings);
        }

        public async Task<BookingModel> UpdateBookingAsync(int bookingId, BookingModel bookingToUpdate)
        {
            Booking existingBooking = await _unitOfWork.BookingRepository.FindByIdAsync(bookingId);

            if (existingBooking == null)
            {
                throw new Exception("Booking does not exist");
            }

            bookingToUpdate.Id = existingBooking.Id;
            bookingToUpdate.UserId = existingBooking.UserId;
            bookingToUpdate.BookingChanged = DateTime.Now;

            _mapper.Map(bookingToUpdate, existingBooking);

            _unitOfWork.BookingRepository.Update(existingBooking);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Booking, BookingModel>(existingBooking);
        }
    }
}
