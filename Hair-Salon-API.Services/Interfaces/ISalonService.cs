﻿using Hair_Salon_API.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair_Salon_API.Services.Interfaces
{
    public interface ISalonService
    {
        Task<SalonModel> AddSalonAsync(SalonModel salonToAdd);

        Task<SalonModel> DeleteSalonAsync(int salonId);

        Task<SalonModel> GetSalonAsync(int salonId);

        Task<IEnumerable<SalonModel>> GetSalonsAsync();

        Task<SalonModel> UpdateSalonAsync(int salonId, SalonModel salonToUpdate);
    }
}