using AutoMapper;
using Hair_Salon_API.Models;
using Hair_Salon_API.Services.Interfaces;
using Hair_Salon_API.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair_Salon_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController:ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;

        public ReviewController(IReviewService reviewService, IMapper mapper)
        {
            _reviewService = reviewService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ReviewDTO>> Get()
        {
            return _mapper.Map<IEnumerable<ReviewDTO>>(await _reviewService.GetReviewsAsync());
        }

        [HttpGet("Salon/{salonId}")]
        public async Task<IEnumerable<ReviewDTO>> GetReviewsBySalon(int salonId)
        {
            return _mapper.Map<IEnumerable<ReviewDTO>>(await _reviewService.GetReviewsBySalonAsync(salonId));
        }

        [HttpGet("User/{userId}")]
        public async Task<IEnumerable<ReviewDTO>> GetReviewsByUser(int userId)
        {
            return _mapper.Map<IEnumerable<ReviewDTO>>(await _reviewService.GetReviewsByUserAsync(userId));
        }

        [HttpGet("{reviewId}")]
        public async Task<ReviewDTO> Get(int reviewId)
        {
            return _mapper.Map<ReviewDTO>(await _reviewService.GetReviewAsync(reviewId));
        }

        [HttpPost]
        public async Task<ReviewDTO> Post(ReviewPostDTO reviewToAdd)
        {
            return _mapper.Map<ReviewDTO>(await _reviewService.AddReviewAsync(_mapper.Map<ReviewModel>(reviewToAdd)));
        }

        [HttpPut("{reviewId}")]
        public async Task<ReviewDTO> Put(int reviewId, ReviewPostDTO reviewToUpdate)
        {
            return _mapper.Map<ReviewDTO>(await _reviewService.UpdateReviewAsync(reviewId, _mapper.Map<ReviewModel>(reviewToUpdate)));
        }

        [HttpDelete("{reviewId}")]
        public async Task<ReviewDTO> Delete(int reviewId)
        {
            return _mapper.Map<ReviewDTO>(await _reviewService.DeleteReviewAsync(reviewId));
        }
    }
}
