﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.DesktopHost.ViewModel.Navigation;

namespace TravelApp.DesktopHost.Command.Navigation.Agent
{
    class AgentReservationsCommand : BaseCommand
    {
        private readonly NavigationStore _navigation;

        public AgentReservationsCommand()
        {
            _navigation = NavigationStore.Instance();
        }
        public override void Execute(object parameter)
        {
            // TODO : add here _navigation.CurrentViewModel = new ReservationsViewModel()
            // or whatever the class is called
            throw new NotImplementedException();
        }
    }
}
