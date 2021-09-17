using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolvoTruck.Business.Interfaces.TruckService;
using VolvoTruck.Business.Interfaces.TruckModelService;
using VolvoTruck.Data.Interfaces.TruckData;
using VolvoTruck.Domain;
using VolvoTruck.Domain.Dtos;
using VolvoTruck.Domain.Entities;

namespace VolvoTruck.Business.Services.TruckService
{
    public class TruckService : ITruckService
    {
        private readonly ITruckDataRepository _truckDataRepository;
        private readonly ITruckModelService _truckModelService;
        public TruckService(ITruckDataRepository truckDataRepository, ITruckModelService truckModelService)
        {
            _truckDataRepository = truckDataRepository;
            _truckModelService = truckModelService;
        }
        public void SaveOrUpdateTruck(int id, string model, int manufactureYear, int modelYear)
        {
            var truckModel = _truckModelService.GetByName(model);
            ValidateValues(id, manufactureYear, modelYear);
            var truck = new Truck(id, truckModel.Id, manufactureYear, modelYear);
            if(truck.Id == 0)
            {
                _truckDataRepository.SaveTruck(truck);
            }
            _truckDataRepository.UpdateTruck(truck);
        }

        private static void ValidateValues(int id, int manufactureYear, int modelYear)
        {
            var lowestYear = 1960;
            var highestModelYear = DateTime.Now.Year;
            var highestManufactureYear = DateTime.Now.Year + 1;
            DomainException.When(id < 0, "Id should be higher or equal zero.");
            DomainException.When(manufactureYear.ToString().Length != 4 || modelYear.ToString().Length != 4,
                "Year fields must have four digits.");
            DomainException.When(manufactureYear < lowestYear || modelYear < lowestYear,
                String.Format("Year fields must be equal or higher than {0}", lowestYear));
            DomainException.When(manufactureYear > highestManufactureYear,
                String.Format("Manufacture Year must be at most equal to {0}", highestManufactureYear));
            DomainException.When(modelYear > highestModelYear,
                String.Format("Model Year must be at most equal to {0}", highestModelYear));
            DomainException.When(modelYear - manufactureYear > 1,
                String.Format("Model Year must be at most one year apart from Manufacture Year"));
        }

        public List<Truck> GetTrucks()
        {
            var truckModelsId = _truckModelService.GetAll().Select(x => x.Id);
            var currentYear = DateTime.Now.Year;
            return _truckDataRepository
                .Select(x => truckModelsId
                .Contains(x.TruckModelId) &&
                x.ManufactureYear == currentYear &&
                (x.ModelYear - currentYear) <= 1);
        }
    }
}
