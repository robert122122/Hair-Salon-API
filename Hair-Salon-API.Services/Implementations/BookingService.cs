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

        public async Task<BookingGetModel> GetBookingAsync(int bookingId)
        {
            Booking existingBooking = await _unitOfWork.BookingRepository.FindByIdAsync(bookingId);

            if (existingBooking == null)
            {
                throw new Exception("Booking does not exist");
            }

            Salon salon = await _unitOfWork.SalonRepository.FindByIdAsync(existingBooking.SalonId);
            Service service = await _unitOfWork.ServiceRepository.FindByIdAsync(existingBooking.ServiceId);
            Barber barber = await _unitOfWork.BarberRepository.FindByIdAsync(existingBooking.BarberId);

            BookingGetModel booking = _mapper.Map<BookingGetModel>(existingBooking);
            booking.Salon = salon.Name;
            booking.Service = service.ServiceName;
            booking.Barber = barber.FirstName + barber.LastName;

            return booking;
        }

        public async Task<IEnumerable<BookingGetModel>> GetBookingsAsync()
        {
            return _mapper.Map<IEnumerable<BookingGetModel>>(await _unitOfWork.BookingRepository.GetBookingsWithDetails());
        }

        public async Task<IEnumerable<BookingGetModel>> GetBookingsByUserAsync(int userId)
        {
            User existingUser = await _unitOfWork.UserRepository.FindByIdAsync(userId);
            if (existingUser == null)
            {
                throw new Exception("User does not exists!");
            }

            IEnumerable<BookingGetModel> bookings = _mapper.Map<IEnumerable<BookingGetModel>>(await _unitOfWork.BookingRepository.FindAsync(booking => booking.UserId == userId));

            if (bookings == null)
            {
                throw new Exception("Bookings not found.");
            }

            foreach (BookingGetModel booking in bookings)
            {
                Booking existingBooking = await _unitOfWork.BookingRepository.FindByIdAsync(booking.Id);

                Salon salon = await _unitOfWork.SalonRepository.FindByIdAsync(existingBooking.SalonId);
                Service service = await _unitOfWork.ServiceRepository.FindByIdAsync(existingBooking.ServiceId);
                Barber barber = await _unitOfWork.BarberRepository.FindByIdAsync(existingBooking.BarberId);

                booking.Salon = salon.Name;
                booking.Service = service.ServiceName;
                booking.Barber = barber.FirstName + " " + barber.LastName;
            }

            return bookings;
        }

        public async Task<IEnumerable<BookingGetModel>> GetBookingsBySalonAsync(int salonId)
        {
            Salon existingSalon = await _unitOfWork.SalonRepository.FindByIdAsync(salonId);
            if (existingSalon == null)
            {
                throw new Exception("Salon does not exists!");
            }

            IEnumerable<BookingGetModel> bookings = _mapper.Map<IEnumerable<BookingGetModel>>(await _unitOfWork.BookingRepository.FindAsync(booking => booking.SalonId == salonId));

            if (bookings == null)
            {
                throw new Exception("Bookings not found.");
            }

            foreach (BookingGetModel booking in bookings)
            {
                Booking existingBooking = await _unitOfWork.BookingRepository.FindByIdAsync(booking.Id);

                User user = await _unitOfWork.UserRepository.FindByIdAsync(existingBooking.UserId);

                Salon salon = await _unitOfWork.SalonRepository.FindByIdAsync(existingBooking.SalonId);
                Service service = await _unitOfWork.ServiceRepository.FindByIdAsync(existingBooking.ServiceId);
                Barber barber = await _unitOfWork.BarberRepository.FindByIdAsync(existingBooking.BarberId);

                booking.User = user.FirstName + " " + user.LastName;
                booking.Salon = salon.Name;
                booking.Service = service.ServiceName;
                booking.Barber = barber.FirstName + " " + barber.LastName;
            }

            bookings = bookings.OrderBy(booking => booking.BookingDate).ToList();


            return bookings;
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
