using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Repository;
using TravelApp.DesktopHost.ViewModel;

namespace TravelApp.Core.Service
{
    public class TransactionService
    {
        private ITransactionRepository _transactionRepository;

        public ITransactionRepository TransactionRepository { get { return _transactionRepository; } }

        public TransactionService()
        {
            this._transactionRepository = new TransactionRepository();
        }

        public List<TransactionListItemViewModel> GetReservations()
        {
            return _transactionRepository.GetReservations();
        }
    }
}
