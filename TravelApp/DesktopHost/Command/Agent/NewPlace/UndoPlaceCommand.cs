using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TravelApp.Core.Service;
using TravelApp.DesktopHost.ViewModel;

namespace TravelApp.DesktopHost.Command.Agent.NewPlace
{
    public class UndoPlaceCommand : BaseCommand
    {
        private AgentStayEatViewModel _model;
        private TouristFacilityService _service;

        public UndoPlaceCommand(AgentStayEatViewModel model)
        {
            _model = model;
            _service = new TouristFacilityService();
        }

        public override void Execute(object parameter)
        {
            if (_model.DeletedFacility != null)
            {   
                _service.FacilityRepository.UndoItem(_model.DeletedFacility.Id);
                TouristFacilityListItemViewModel item = new TouristFacilityListItemViewModel();
                item.Id = _model.DeletedFacility.Id;
                item.Name = _model.DeletedFacility.Name;
                item.Address = _model.DeletedFacility.Address;
                item.Link = _model.DeletedFacility.Link;
                item.Type = _model.DeletedFacility.Type.ToString();
                item.IsDeleted = _model.DeletedFacility.IsDeleted;
                _model.FilteredItems.Add(item);
                MessageBox.Show("Undo " + item.Name, "Successfully undo", MessageBoxButton.OK, MessageBoxImage.Information);
                _model.DeletedFacility = null;               
            }
            else
                MessageBox.Show("there is no object to undo", "Undo", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

    }
}
