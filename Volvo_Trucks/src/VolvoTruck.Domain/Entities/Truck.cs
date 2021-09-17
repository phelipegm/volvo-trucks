using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolvoTruck.Domain.Entities
{
    public class Truck : EntityBase
    {
        public int TruckModelId { get; set; }
        public TruckModel TruckModel { get; private set; }
        public int ManufactureYear { get; private set; }
        public int ModelYear { get; private set; }

        public Truck(int id, int truckModelId, int manufactureYear, int modelYear)
        {
            Id = id;
            TruckModelId = truckModelId;
            ManufactureYear = manufactureYear;
            ModelYear = modelYear;
        }
    }
}
