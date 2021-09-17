using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolvoTruck.Domain.Entities.Utils;
using VolvoTruck.Domain.Entities.Utils.Enums;

namespace VolvoTruck.Domain.Entities
{
    public class TruckModel : EntityBase
    {
        public string Name { get; private set; }

        public TruckModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
