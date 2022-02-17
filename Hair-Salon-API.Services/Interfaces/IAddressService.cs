using Hair_Salon_API.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair_Salon_API.Services.Interfaces
{
    public interface IAddressService
    {
        Task<AddressModel> AddAddressAsync(AddressModel addressToAdd);

        Task<AddressModel> DeleteAddressAsync(int addressIdToDelete);

        Task<AddressModel> GetAddressAsync(int addressId);

/*        Task<IEnumerable<AddressModel>> GetAddressesBySalonId(int userId);*/

        Task<AddressModel> UpdateAddressAsync(int addressIdToUpdate, AddressModel newAddress);
    }
}
