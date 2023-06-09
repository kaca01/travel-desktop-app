﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Model;
using TravelApp.DesktopHost.ViewModel;

namespace TravelApp.Core.Repository
{
    public interface ITripRepository
    {
        public List<Trip> GetAll();

        public Trip Get(int id);

        public bool Delete(int id);

        public List<TripListItemViewModel> GetAllReturnListItem();
    }
}
