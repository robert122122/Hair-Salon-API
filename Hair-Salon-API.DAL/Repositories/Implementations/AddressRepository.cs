using Hair_Salon_API.DAL.Models;
using Hair_Salon_API.DAL.Repositories.Interfaces;

namespace Hair_Salon_API.DAL.Repositories.Implementations
{
    public class AddressRepository: BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(AppointmentsContext dbContext) : base(dbContext) { }
    }
}
