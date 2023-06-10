using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Model;
using TravelApp.Core.Repository;
using TravelApp.DesktopHost.ViewModel;
using TravelApp.DesktopHost.ViewModel.ItemViewModel;

namespace TravelApp.Core.Service
{
    public class AttractionService
    {
        private IAttractionRepository attractionRepository;

        public AttractionService()
        {
            this.attractionRepository = new AttractionRepository();
        }

        public List<ItemModel> GetItemModel()
        {
            List<Attraction> attractions = this.attractionRepository.GetAll();
            return attractions.Select(a => new ItemModel
            {
                Id = a.Id,
                Name = a.Name,
                IsSelected = false
            }).ToList();
        }
    }
}
