using Microsoft.Extensions.DependencyInjection;
using VolvoTruck.Data.Interfaces.TruckData;
using VolvoTruck.Data.Interfaces.TruckModelData;
using VolvoTruck.Data.Repositories.TruckData;
using VolvoTruck.Data.Repositories.TruckModelData;

namespace VolvoTruck.DI.Registers
{
    public class RepositoriesRegister
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<ITruckDataRepository, TruckDataRepository>();
            services.AddScoped<ITruckModelRepository, TruckModelRepository>();
        }
    }
}
