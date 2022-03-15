using Hair_Salon_API.DAL.Models;
using Hair_Salon_API.DAL.Repositories.Interfaces;

namespace Hair_Salon_API.DAL.Repositories.Implementations
{
    public class UserRepository:BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppointmentsContext dbContext) : base(dbContext) { }
    }
}
