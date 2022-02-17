using AutoMapper;
using Hair_Salon_API.Models;
using Hair_Salon_API.Services.Interfaces;
using Hair_Salon_API.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hair_Salon_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController:ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;

        public AddressController(IAddressService addressService, IMapper mapper)
        {
            _addressService = addressService;
            _mapper = mapper;
        }

        [HttpGet("{addressId}")]
        public async Task<AddressDTO> Get(int addressId)
        {
            return _mapper.Map<AddressDTO>(await _addressService.GetAddressAsync(addressId));
        }

        [HttpPost]
        public async Task<AddressDTO> Post(AddressPostDTO addressToAdd)
        {
            return _mapper.Map<AddressDTO>(await _addressService.AddAddressAsync(_mapper.Map<AddressModel>(addressToAdd)));
        }

        [HttpPut("{addressId}")]
        public async Task<AddressDTO> Put(int addressId, AddressPutDTO addressToUpdate)
        {
            return _mapper.Map<AddressDTO>(await _addressService.UpdateAddressAsync(addressId, _mapper.Map<AddressModel>(addressToUpdate)));
        }

        [HttpDelete("{addressId}")]
        public async Task<AddressDTO> Delete(int addressId)
        {
            return _mapper.Map<AddressDTO>(await _addressService.DeleteAddressAsync(addressId));
        }
    }
}
