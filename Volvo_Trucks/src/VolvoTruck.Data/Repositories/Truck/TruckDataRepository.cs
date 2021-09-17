using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolvoTruck.Data.Interfaces.TruckData;
using VolvoTruck.Data.Repositories.Base;
using VolvoTruck.Domain.Dtos;
using VolvoTruck.Domain.Entities;

namespace VolvoTruck.Data.Repositories.TruckData
{
    public class TruckDataRepository : Repository<Truck>, ITruckDataRepository
    {
        public TruckDataRepository(ApplicationDbContext options) : base(options)
        {

        }

        public void SaveTruck(Truck truck)
        {
            Save(truck);
        }

        public void UpdateTruck(Truck truck)
        {
            Update(truck);
        }
    }
}
