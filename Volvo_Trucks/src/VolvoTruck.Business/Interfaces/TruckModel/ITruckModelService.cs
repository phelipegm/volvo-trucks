using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolvoTruck.Domain.Entities;

namespace VolvoTruck.Business.Interfaces.TruckModelService
{
    public interface ITruckModelService
    {
        void SaveCategories();
        List<TruckModel> GetAll();
        TruckModel GetByName(string model);
    }
}
