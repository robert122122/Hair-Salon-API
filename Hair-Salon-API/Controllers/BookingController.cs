using AutoMapper;
using Hair_Salon_API.Models;
using Hair_Salon_API.Services.Interfaces;
using Hair_Salon_API.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hair_Salon_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController:ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<BookingDTO>> Get()
        {
            return _mapper.Map<IEnumerable<BookingDTO>>(await _bookingService.GetBookingsAsync());
        }

        [HttpGet("User/{userId}")]
        public async Task<IEnumerable<BookingDTO>> GetBookingsByUser(int userId)
        {
            return _mapper.Map<IEnumerable<BookingDTO>>(await _bookingService.GetBookingsByUserAsync(userId));
        }

        [HttpGet("{bookingId}")]
        public async Task<BookingDTO> Get(int bookingId)
        {
            return _mapper.Map<BookingDTO>(await _bookingService.GetBookingAsync(bookingId));
        }

        [HttpPost]
        public async Task<BookingDTO> Post(BookingPostDTO bookingToAdd)
        {
            return _mapper.Map<BookingDTO>(await _bookingService.AddBookingAsync(_mapper.Map<BookingModel>(bookingToAdd)));
        }

        [HttpPut("{bookingId}")]
        public async Task<BookingDTO> Put(int bookingId, BookingPutDTO bookingToUpdate)
        {
            return _mapper.Map<BookingDTO>(await _bookingService.UpdateBookingAsync(bookingId, _mapper.Map<BookingModel>(bookingToUpdate)));
        }

        [HttpDelete("{bookingId}")]
        public async Task<BookingDTO> Delete(int bookingId)
        {
            return _mapper.Map<BookingDTO>(await _bookingService.DeleteBookingAsync(bookingId));
        }
    }
}
