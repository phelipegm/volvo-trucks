using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolvoTruck.Data.Interfaces.Base;
using VolvoTruck.Domain.Entities;

namespace VolvoTruck.Data.Interfaces.TruckModelData
{
    public interface ITruckModelRepository : IRepository<TruckModel>
    {
        TruckModel GetByName(string model);
    }
}
