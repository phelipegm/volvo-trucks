using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolvoTruck.Data.Interfaces.Base;
using VolvoTruck.Domain.Dtos;
using VolvoTruck.Domain.Entities;

namespace VolvoTruck.Data.Interfaces.TruckData
{
    public interface ITruckDataRepository : IRepository<Truck>
    {
        void SaveTruck(Truck truckDto);
        void UpdateTruck(Truck truckDto);
    }
}
