using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RSS.Business.DataServices;
using RSS.Business.Interfaces;
using RSS.Data;
using RSS.Data.Interfaces;

namespace RSS.Infrastructure
{
    public static class DependencyInjection
    {
        public static void SetupDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RideSharingDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DbConnection")));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie((CookieOptions)=>
                {
                    CookieOptions.ExpireTimeSpan = TimeSpan.FromMinutes(5 * 1);
                    CookieOptions.LoginPath = "/Account/LogIn";
                    CookieOptions.AccessDeniedPath = "/Account/LogIn";
                });
            services.AddSession (options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(5 * 1);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(typeof(BusinessEntityMappings));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOfferRepository, OfferRepository>();
            services.AddScoped<IRequestRepository, RequestRepository>();

            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<IOfferService, OfferService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}