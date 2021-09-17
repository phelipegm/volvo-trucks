using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VolvoTruck.Business.Interfaces.TruckService;

namespace VolvoTruck.Web.Controllers
{
    [Route("api/[Controller]")]
    public class TruckExhibitionController : Controller
    {
        private readonly ITruckService _truckService;
        public TruckExhibitionController(ITruckService truckService)
        {
            _truckService = truckService;
        }

        [HttpGet]
        public IActionResult GetTrucks()
        {
            return Ok(_truckService.GetTrucks());
        }
    }
}
