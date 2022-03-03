using Hair_Salon_API.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair_Salon_API.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IAddressRepository AddressRepository { get; }
        IBarberRepository BarberRepository { get; }
        IBookingRepository BookingRepository { get; }
        IServiceRepository ServiceRepository { get; }
        ISalonRepository SalonRepository { get; }
        IServiceBarberRepository ServiceBarberRepository { get; }

        void Commit();
        Task CommitAsync();
        void RollBackAsync();
    }
}
