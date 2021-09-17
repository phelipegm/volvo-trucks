using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolvoTruck.Domain.Dtos
{
    public class TruckDto
    {
        public int Id { get; private set; }
        public string Model { get; private set; }
        public int ManufactureYear { get; private set; }
        public int ModelYear { get; private set; }
    }
}
