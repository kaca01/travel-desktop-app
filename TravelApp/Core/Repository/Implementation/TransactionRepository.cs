﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Model;
using TravelApp.Core.Repository.Interface;
using TravelApp.Core.Service;
using TravelApp.DesktopHost.ViewModel.Component.ListItem;

namespace TravelApp.Core.Repository.Implementation
{
    public class TransactionRepository : ITransactionRepository
    {
        TravelContext context = TravelContext.Instance;

        ITripRepository tripRepository = new TripRepository();

        public List<TransactionListItemViewModel> GetReservations()
        {
            return context.Transactions.Select(t => new TransactionListItemViewModel
            {
                Id = t.Id,
                TripId = t.Trip.Id,
                User = t.User,
                Passenger = t.User.Name + " " + t.User.Surname,
                Trip = t.Trip.Name,
                Price = t.Trip.Price.ToString(),
                StartDate = t.Trip.StartDate,
                EndDate = t.Trip.EndDate,
                Type = t.Type.ToString(),
                TransactionDate = t.TransactionDate,
                IsDeleted = t.IsDeleted
            }).Where(t => !t.IsDeleted && t.Type.Equals("RESERVATION")).ToList();

        }

        public List<TransactionListItemViewModel> GetReservationsForCurrentUser(string currentUser)
        {
            return context.Transactions.Select(t => new TransactionListItemViewModel
            {
                Id = t.Id,
                TripId = t.Trip.Id,
                User = t.User,
                Passenger = t.User.Name + " " + t.User.Surname,
                Trip = t.Trip.Name,
                Price = t.Trip.Price.ToString(),
                StartDate = t.Trip.StartDate,
                EndDate = t.Trip.EndDate,
                Type = t.Type.ToString(),
                TransactionDate = t.TransactionDate,
                IsDeleted = t.IsDeleted
            }).Where(t => !t.IsDeleted && t.Type.Equals("RESERVATION") && t.User.Email.Equals(currentUser)).ToList();

        }

        public List<TransactionListItemViewModel> GetTrips()
        {

            return context.Transactions.Select(t => new TransactionListItemViewModel
            {
                Id = t.Id,
                TripId = t.Trip.Id,
                User = t.User,
                Passenger = t.User.Name + " " + t.User.Surname,
                Trip = t.Trip.Name,
                Price = t.Trip.Price.ToString(),
                StartDate = t.Trip.StartDate,
                EndDate = t.Trip.EndDate,
                Type = t.Type.ToString(),
                TransactionDate = t.TransactionDate,
                IsDeleted = t.IsDeleted
            }).Where(t => !t.IsDeleted && t.Type.Equals("PURCHASE")).ToList();

        }

        public List<TransactionListItemViewModel> GetTripsForCurrentUser(string currentUser)
        {
            return context.Transactions.Select(t => new TransactionListItemViewModel
            {
                Id = t.Id,
                TripId = t.Trip.Id,
                User = t.User,
                Passenger = t.User.Name + " " + t.User.Surname,
                Trip = t.Trip.Name,
                Price = t.Trip.Price.ToString(),
                StartDate = t.Trip.StartDate,
                EndDate = t.Trip.EndDate,
                Type = t.Type.ToString(),
                TransactionDate = t.TransactionDate,
                IsDeleted = t.IsDeleted
            }).Where(t => !t.IsDeleted && t.Type.Equals("PURCHASE") && t.User.Email.Equals(currentUser)).ToList();

        }

        public Transaction GetById(int id)
        {

            return context.Transactions.Where(u => u.Id == id).ToList()[0];

        }

        public void BuyTrip(int id)
        {
            Transaction transaction = GetById(id);

            if (transaction != null)
            {
                transaction.Type = TransactionType.PURCHASE;
                //todo check if this works
            }

        }

        public void CallOffReservation(int id)
        {
            Transaction transaction = GetById(id);

            if (transaction != null)
            {
                transaction.IsDeleted = true;
                //todo check if this works
            }
        }

        public void TripBooking(int id)
        {
            User user = UserService.CurrentUser;
            Trip trip = tripRepository.Get(id);

            Transaction transaction = new Transaction();
            transaction.IsDeleted = false;
            transaction.User = user;
            transaction.Trip = trip;
            transaction.Type = TransactionType.RESERVATION;
            transaction.Id = generateId();
            context.Transactions.Add(transaction);
        }

        private int generateId()
        {
            int max = 0;
            foreach (Transaction transaction in context.Transactions)
                if (transaction.Id > max) max = transaction.Id;

            return max + 1;
        }
    }
}
