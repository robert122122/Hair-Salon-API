using Hair_Salon_API.DAL.Models;
using Hair_Salon_API.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair_Salon_API.DAL.Repositories.Implementations
{
    public class ServiceRepository:BaseRepository<Service>, IServiceRepository
    {
        public ServiceRepository(HairdresserContext dbContext) : base(dbContext) { }
    }
}
