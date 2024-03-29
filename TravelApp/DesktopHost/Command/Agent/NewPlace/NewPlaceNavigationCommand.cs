﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.DesktopHost.ViewModel.Navigation;
using TravelApp.DesktopHost.ViewModel;
using TravelApp.DesktopHost.ViewModel.Component.Agent;
using TravelApp.DesktopHost.ViewModel.Component.Agent.Form;

namespace TravelApp.DesktopHost.Command.Agent.NewPlace
{
    public class NewPlaceNavigationCommand : BaseCommand
    {
        private readonly NavigationStore _navigation;

        public NewPlaceNavigationCommand()
        {
            _navigation = NavigationStore.Instance();
        }
        public override void Execute(object parameter)
        {
            _navigation.CurrentViewModel = new NewPlaceViewModel();
        }
    }
}
