using Microsoft.Extensions.DependencyInjection;
using VolvoTruck.Business.Interfaces.TruckModelService;
using VolvoTruck.Business.Interfaces.TruckService;
using VolvoTruck.Business.Services.TruckModelService;
using VolvoTruck.Business.Services.TruckService;

namespace VolvoTruck.DI.Registers
{
    public class ServicesRegister
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<ITruckService, TruckService>();
            services.AddScoped<ITruckModelService, TruckModelService>();
        }
    }
}
