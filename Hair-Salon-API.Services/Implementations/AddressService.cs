using Hair_Salon_API.Services.Interfaces;
using Hair_Salon_API.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hair_Salon_API.DAL.UnitOfWork;
using AutoMapper;
using Hair_Salon_API.Services.Models;

namespace Hair_Salon_API.Services.Implementations
{
    public class AddressService:IAddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddressService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AddressModel> AddAddressAsync(AddressModel addressToAdd)
        {

            Address newAddress = _mapper.Map<Address>(addressToAdd);
            newAddress.DateAdded = DateTime.Now;
            newAddress.DateUpdated = DateTime.Now;

            _unitOfWork.AddressRepository.Add(newAddress);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Address, AddressModel>(newAddress);
        }

        public async Task<AddressModel> DeleteAddressAsync(int addressIdToDelete)
        {
            Address addressToDelete = await _unitOfWork.AddressRepository.FindByIdAsync(addressIdToDelete);

            if (addressToDelete == null)
            {
                throw new Exception("Address does not exist.");
            }

            _unitOfWork.AddressRepository.Remove(addressToDelete);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<AddressModel>(addressToDelete);
        }

        public async Task<AddressModel> GetAddressAsync(int addressId)
        {
            Address addressToFind = await _unitOfWork.AddressRepository.FindByIdAsync(addressId);

            if (addressToFind == null)
            {
                throw new Exception("Address not found.");
            }

            return _mapper.Map<AddressModel>(addressToFind);
        }

        public async Task<AddressModel> UpdateAddressAsync(int addressIdToUpdate, AddressModel updatedAddress)
        {
            Address existingAddress = await _unitOfWork.AddressRepository.FindByIdAsync(addressIdToUpdate);

            if (existingAddress == null)
            {
                throw new Exception("Address does not exist.");
            }

            updatedAddress.Id = existingAddress.Id;
            updatedAddress.DateAdded = existingAddress.DateAdded;
            updatedAddress.DateUpdated = DateTime.Now;

            _mapper.Map(updatedAddress, existingAddress);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<AddressModel>(existingAddress);
        }

/*        public async Task<IEnumerable<AddressModel>> GetAddressesBySalonId(int salonId)
        {
            IEnumerable<SalonModel> userAliases = _mapper.Map<IEnumerable<SalonModel>>(await _unitOfWork.SalonRepository.FindAsync(salon => salon.Id == salonId));
            return _mapper.Map<IEnumerable<AddressModel>>(await _unitOfWork.AddressRepository.FindAllAsync())
                                                                            .Where((address => salons.SingleOrDefault(salon => salon.id == address.salonId) != null));
        }*/
    }
}
