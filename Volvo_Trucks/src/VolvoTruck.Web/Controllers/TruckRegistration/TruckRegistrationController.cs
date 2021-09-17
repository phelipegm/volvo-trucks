using Microsoft.AspNetCore.Mvc;
using System;
using VolvoTruck.Business.Interfaces.TruckService;

namespace VolvoTruck.Web.Controllers.TruckRegistration
{
    [Route("api/[Controller]")]
    public class TruckRegistrationController : Controller
    {
        private readonly ITruckService _truckService;
        public TruckRegistrationController(ITruckService truckService)
        {
            _truckService = truckService;
        }

        [HttpPost]
        public IActionResult SaveOrUpdateTruck(int id, string model, int manufactureYear, int modelYear)
        {
            try
            {
                _truckService.SaveOrUpdateTruck(id, model, manufactureYear, modelYear);
                return Ok(true);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
