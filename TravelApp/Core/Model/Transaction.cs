using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Core.Model
{
    public enum TransactionType
    {
        RESERVATION, PURCHASE
    }

    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public User User { get; set; }
        public Trip Trip { get; set; }
        public TransactionType Type { get; set; }
        public bool IsDeleted { get; set; }
    }
}
