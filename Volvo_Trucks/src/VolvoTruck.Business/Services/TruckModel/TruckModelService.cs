using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolvoTruck.Business.Interfaces.TruckModelService;
using VolvoTruck.Data.Interfaces.TruckModelData;
using VolvoTruck.Domain;
using VolvoTruck.Domain.Entities;
using VolvoTruck.Domain.Entities.Utils.Enums;

namespace VolvoTruck.Business.Services.TruckModelService
{
    public class TruckModelService : ITruckModelService
    {
        private readonly ITruckModelRepository _truckModelRepository;
        public TruckModelService(ITruckModelRepository truckModelRepository)
        {
            _truckModelRepository = truckModelRepository;
        }

        public List<TruckModel> GetAll()
        {
            return _truckModelRepository.SelectAll();
        }

        public void SaveCategories()
        {
            var truckModels = new List<TruckModel>();
            foreach(var item in Enum.GetNames(typeof(TruckModelEnum)))
            {
                ValidateValues(0, item);
                var truckModel = new TruckModel(0, item);
                truckModels.Add(truckModel);
            }
            _truckModelRepository.SaveMany(truckModels);
        }

        private void ValidateValues(int id, string name)
        {
            var truckModelNames = _truckModelRepository.SelectAll().Select(x => x.Name);
            DomainException.When(id < 0, "Id should be higher or equal zero.");
            DomainException.When(string.IsNullOrEmpty(name), "Model is required.");
            DomainException.When(!truckModelNames.Contains(name),
                String.Format("Models allowed are {0} and {1}", TruckModelEnum.FH, TruckModelEnum.FM));
        }

        public TruckModel GetByName(string model)
        {
            var truckModel = _truckModelRepository.GetByName(model);
            ValidateValues(truckModel.Id, truckModel.Name);
            return truckModel;
        }
    }
}
