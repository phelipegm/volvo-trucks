using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolvoTruck.Domain.Entities;

namespace VolvoTruck.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<TruckModel> TruckModels { get; set; }
        public DbSet<Truck> Trucks { get; set; }
    }
}
