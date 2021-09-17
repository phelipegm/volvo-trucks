using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VolvoTruck.Data;

namespace VolvoTruck.DI.Registers
{
    public class ContextRegister
    {
        public static void Configure(IServiceCollection services, string conection)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(conection));
        }
    }
}