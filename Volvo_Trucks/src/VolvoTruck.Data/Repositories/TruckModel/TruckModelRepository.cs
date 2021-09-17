using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolvoTruck.Data.Interfaces.TruckModelData;
using VolvoTruck.Data.Repositories.Base;
using VolvoTruck.Domain.Entities;

namespace VolvoTruck.Data.Repositories.TruckModelData
{
    public class TruckModelRepository : Repository<TruckModel>, ITruckModelRepository
    {
        public TruckModelRepository(ApplicationDbContext options) : base(options)
        {

        }

        public TruckModel GetByName(string model)
        {
            return Select(x => x.Name.Equals(model)).FirstOrDefault();
        }
    }
}
