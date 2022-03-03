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
    public class ServiceBarberController:ControllerBase
    {
        private readonly IServiceBarberService _serviceBarberService;
        private readonly IMapper _mapper;

        public ServiceBarberController(IServiceBarberService serviceBarberService, IMapper mapper)
        {
            _serviceBarberService = serviceBarberService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ServiceBarberDTO>> Get()
        {
            return _mapper.Map<IEnumerable<ServiceBarberDTO>>(await _serviceBarberService.GetServiceBarbersAsync());
        }

        [HttpGet("Service/{serviceId}")]
        public async Task<IEnumerable<ServiceBarberDTO>> GetServiceBarbersByService(int serviceId)
        {
            return _mapper.Map<IEnumerable<ServiceBarberDTO>>(await _serviceBarberService.GetServiceBarbersByServiceAsync(serviceId));
        }

        [HttpGet("{serviceBarberId}")]
        public async Task<ServiceBarberDTO> Get(int serviceBarberId)
        {
            return _mapper.Map<ServiceBarberDTO>(await _serviceBarberService.GetServiceBarberAsync(serviceBarberId));
        }

        [HttpPost]
        public async Task<ServiceBarberDTO> Post(ServiceBarberDTO serviceBarberToAdd)
        {
            return _mapper.Map<ServiceBarberDTO>(await _serviceBarberService.AddServiceBarberAsync(_mapper.Map<ServiceBarberModel>(serviceBarberToAdd)));
        }

        [HttpPut("{serviceBarberId}")]
        public async Task<ServiceBarberDTO> Put(int serviceBarberId, ServiceBarberDTO serviceBarberToUpdate)
        {
            return _mapper.Map<ServiceBarberDTO>(await _serviceBarberService.UpdateServiceBarberAsync(serviceBarberId, _mapper.Map<ServiceBarberModel>(serviceBarberToUpdate)));
        }

        [HttpDelete("{serviceBarberId}")]
        public async Task<ServiceBarberDTO> Delete(int serviceBarberId)
        {
            return _mapper.Map<ServiceBarberDTO>(await _serviceBarberService.DeleteServiceBarberAsync(serviceBarberId));
        }
    }
}
