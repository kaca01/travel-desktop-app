﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Model;
using TravelApp.Core.Repository;
using TravelApp.DesktopHost.ViewModel;
using TravelApp.DesktopHost.ViewModel.Component.Agent.Form;
using TravelApp.DesktopHost.ViewModel.Component.ComboBox;

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
        public Attraction Create(NewAttractionViewModel vm)
        {
            return this.attractionRepository.Create(vm.Name, vm.Address, vm.Description, vm.ImageSource);
        }

        public List<Attraction> GetAll()
        {
            return attractionRepository.GetAll();
        }

        public Attraction Get(int id)
        {
            return attractionRepository.Get(id);
        }

        public bool Delete(int id)
        {
            return attractionRepository.Delete(id);
        }
    }
}
