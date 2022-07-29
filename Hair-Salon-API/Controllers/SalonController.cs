using AutoMapper;
using Hair_Salon_API.Models;
using Hair_Salon_API.Services.Interfaces;
using Hair_Salon_API.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hair_Salon_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalonController:ControllerBase
    {
        private readonly ISalonService _salonService;
        private readonly IMapper _mapper;

        public SalonController(ISalonService salonService, IMapper mapper)
        {
            _salonService = salonService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SalonGetDTO>> Get()
        {
            return _mapper.Map<IEnumerable<SalonGetDTO>>(await _salonService.GetSalonsAsync());
        }

        [HttpGet("{salonId}")]
        public async Task<SalonDTO> Get(int salonId)
        {
            return _mapper.Map<SalonDTO>(await _salonService.GetSalonAsync(salonId));
        }

        [HttpPost]
        public async Task<SalonDTO> Post(SalonPostDTO salonToAdd)
        {
            return _mapper.Map<SalonDTO>(await _salonService.AddSalonAsync(_mapper.Map<SalonModel>(salonToAdd)));
        }

        [HttpPut("{salonId}")]
        public async Task<SalonDTO> Put(int salonId, SalonPutDTO salonToUpdate)
        {
            return _mapper.Map<SalonDTO>(await _salonService.UpdateSalonAsync(salonId, _mapper.Map<SalonModel>(salonToUpdate)));
        }

        [HttpPut("{addressId}/{salonId}")]
        public async Task<SalonDTO> Put(int addressId, int salonId)
        {
            return _mapper.Map<SalonDTO>(await _salonService.AddAddressToSalonAsync(addressId, salonId));
        }

        [HttpDelete("{salonId}")]
        public async Task<SalonDTO> Delete(int salonId)
        {
            return _mapper.Map<SalonDTO>(await _salonService.DeleteSalonAsync(salonId));
        }
    }
}
