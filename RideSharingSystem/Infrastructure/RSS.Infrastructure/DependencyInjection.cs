using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RSS.Business.DataServices;
using RSS.Business.Interfaces;
using RSS.Data;

namespace RSS.Infrastructure
{
    public static class DependencyInjection
    {
        public static void SetupDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RideSharingDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DbConnection")));
            

            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<IOfferService, OfferService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}