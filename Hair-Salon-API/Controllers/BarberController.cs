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
    public class BarberController:ControllerBase
    {
        private readonly IBarberService _barberService;
        private readonly IMapper _mapper;

        public BarberController(IBarberService barberService, IMapper mapper)
        {
            _barberService = barberService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<BarberDTO>> Get()
        {
            return _mapper.Map<IEnumerable<BarberDTO>>(await _barberService.GetBarbersAsync());
        }

        [HttpGet("Salon/{salonId}")]
        public async Task<IEnumerable<BarberDTO>> GetBarbersBySalon(int salonId)
        {
            return _mapper.Map<IEnumerable<BarberDTO>>(await _barberService.GetBarbersBySalonAsync(salonId));
        }

        [HttpGet("{barberId}")]
        public async Task<BarberDTO> Get(int barberId)
        {
            return _mapper.Map<BarberDTO>(await _barberService.GetBarberAsync(barberId));
        }

        [HttpPost]
        public async Task<BarberDTO> Post(BarberPostDTO barberToAdd)
        {
            return _mapper.Map<BarberDTO>(await _barberService.AddBarberAsync(_mapper.Map<BarberModel>(barberToAdd)));
        }

        [HttpPut("{barberId}")]
        public async Task<BarberDTO> Put(int barberId, BarberPutDTO barberToUpdate)
        {
            return _mapper.Map<BarberDTO>(await _barberService.UpdateBarberAsync(barberId, _mapper.Map<BarberModel>(barberToUpdate)));
        }

        [HttpDelete("{barberId}")]
        public async Task<BarberDTO> Delete(int barberId)
        {
            return _mapper.Map<BarberDTO>(await _barberService.DeleteBarberAsync(barberId));
        }
    }
}
