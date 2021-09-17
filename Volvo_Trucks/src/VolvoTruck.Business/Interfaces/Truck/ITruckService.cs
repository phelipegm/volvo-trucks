using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolvoTruck.Domain.Dtos;
using VolvoTruck.Domain.Entities;

namespace VolvoTruck.Business.Interfaces.TruckService
{
    public interface ITruckService
    {
        void SaveOrUpdateTruck(int id, string model, int manufactureYear, int modelYear);
        List<Truck> GetTrucks();
    }
}
