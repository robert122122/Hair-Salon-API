using Hair_Salon_API.DAL.Models;
using Hair_Salon_API.DAL.Repositories.Implementations;
using Hair_Salon_API.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair_Salon_API.DAL.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly AppointmentsContext _dbContext;

        private IUserRepository _userRepository;
        private ISalonRepository _salonRepository;
        private IServiceRepository _serviceRepository;
        private IAddressRepository _addressRepository;
        private IBarberRepository _barberRepository;
        private IBookingRepository _bookingRepository;
        private IServiceBarberRepository _serviceBarberRepository;
        private IReviewRepository _reviewRepository;

        public UnitOfWork(AppointmentsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUserRepository UserRepository => _userRepository ??=new UserRepository(_dbContext);
        public ISalonRepository SalonRepository => _salonRepository ??=new SalonRepository(_dbContext);
        public IServiceRepository ServiceRepository => _serviceRepository ??=new ServiceRepository(_dbContext);
        public IAddressRepository AddressRepository => _addressRepository ??=new AddressRepository(_dbContext);
        public IBarberRepository BarberRepository => _barberRepository ??=new BarberRepository(_dbContext);
        public IBookingRepository BookingRepository => _bookingRepository ??=new BookingRepository(_dbContext);
        public IServiceBarberRepository ServiceBarberRepository => _serviceBarberRepository ??= new ServiceBarberRepository(_dbContext);
        public IReviewRepository ReviewRepository => _reviewRepository ??= new ReviewRepository(_dbContext);
        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async void RollBackAsync()
        {
            await _dbContext.Database.RollbackTransactionAsync();
        }
    }
}
