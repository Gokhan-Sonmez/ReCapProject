using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IResult Add(Payment payment);
   
        IDataResult<Payment> Get(int paymentid);
        IDataResult<List<Payment>> GetAll();
        IDataResult<List<Payment>> GetByRentalId(int rentalId);

    }
}
