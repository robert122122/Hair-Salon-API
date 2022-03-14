﻿using AutoMapper;
using Hair_Salon_API.DAL.Models;
using Hair_Salon_API.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair_Salon_API.Services.Profiles
{
    public class ServiceBarberProfile:Profile
    {
        public ServiceBarberProfile()
        {
            CreateMap<ServiceBarber, ServiceBarberModel>().ReverseMap();
        }
    }
}