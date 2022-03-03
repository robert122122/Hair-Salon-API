using AutoMapper;
using Hair_Salon_API.Models;
using Hair_Salon_API.Services.Interfaces;
using Hair_Salon_API.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hair_Salon_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController:ControllerBase
    {
        private readonly IServiceService _serviceService;
        private readonly IMapper _mapper;

        public ServiceController(IServiceService serviceService, IMapper mapper)
        {
            _serviceService = serviceService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ServiceDTO>> Get()
        {
            return _mapper.Map<IEnumerable<ServiceDTO>>(await _serviceService.GetServicesAsync());
        }

        [HttpGet("Salon/{salonId}")]
        public async Task<IEnumerable<ServiceDTO>> GetServicesBySalon(int salonId)
        {
            return _mapper.Map<IEnumerable<ServiceDTO>>(await _serviceService.GetServicesBySalonAsync(salonId));
        }

        [HttpGet("{serviceId}")]
        public async Task<ServiceDTO> Get(int serviceId)
        {
            return _mapper.Map<ServiceDTO>(await _serviceService.GetServiceAsync(serviceId));
        }

        [HttpPost]
        public async Task<ServiceDTO> Post(ServicePostDTO serviceToAdd)
        {
            return _mapper.Map<ServiceDTO>(await _serviceService.AddServiceAsync(_mapper.Map<ServiceModel>(serviceToAdd)));
        }

        [HttpPut("{serviceId}")]
        public async Task<ServiceDTO> Put(int serviceId, ServicePutDTO serviceToUpdate)
        {
            return _mapper.Map<ServiceDTO>(await _serviceService.UpdateServiceAsync(serviceId, _mapper.Map<ServiceModel>(serviceToUpdate)));
        }

        [HttpDelete("{serviceId}")]
        public async Task<ServiceDTO> Delete(int serviceId)
        {
            return _mapper.Map<ServiceDTO>(await _serviceService.DeleteServiceAsync(serviceId));
        }
    }
}
