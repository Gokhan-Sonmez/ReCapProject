using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Payment : IEntity
    {
        public int PaymentId { get; set; }
        public int RentalId { get; set; }
        public decimal MoneyPaid { get; set; }
      
    }
}
