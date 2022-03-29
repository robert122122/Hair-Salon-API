﻿using Hair_Salon_API.DAL.Models;
using Hair_Salon_API.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Hair_Salon_API.Services.Implementations;
using Hair_Salon_API.Services.Interfaces;
using System.Reflection;
using Microsoft.OpenApi.Models;
using Hair_Salon_API.Services.Models;
using Hair_Review_API.Services.Implementations;
using Hair_Salon_API.Middleware;
using Hair_Salon_API.Services.Helpers;
using Hair_Salon_API.Common.Implementations;
using Hair_Salon_API.Common.Interfaces;

namespace Hair_Salon_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("AppointmentsConnectionString");

            services.AddDbContext<AppointmentsContext>(
                options =>
                    options.UseSqlServer(connectionString));


            Assembly[] assemblies = new Assembly[]
            {
                Assembly.Load("Hair-Salon-API.Services"),
                Assembly.Load("Hair-Salon-API")
            };

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<ISalonService, SalonService>();
            services.AddScoped<IBarberService, BarberService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IServiceBarberService, ServiceBarberService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IMailService, MailService>();

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddTransient<Services.Interfaces.IMailService, Services.Implementations.MailService>();

            services.AddScoped<IEncryptService, EncryptService>();

            services.AddAutoMapper(assemblies);

            services.AddCors();

            services.AddControllers().AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cinema", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \n 
                      Enter 'Bearer' [space] and then your token in the text input below. \n
                      Example: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cinema v1"));
            }

            app.UseCors(options => options.AllowAnyMethod()
                                          .AllowAnyHeader()
                                          .AllowCredentials()
                                          .SetIsOriginAllowed(origin => true));

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseMiddleware<JwtMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
