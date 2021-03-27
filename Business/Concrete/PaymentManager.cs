using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public IResult Add(Payment payment)
        {
            _paymentDal.Add(payment);
            return new SuccessResult(Messages.SuccessfullyPaid);
        }

   
        public IDataResult<Payment> Get(int paymentid)
        {
            return new SuccessDataResult<Payment>(_paymentDal.Get(p => p.PaymentId == paymentid), Messages.PaymentIdListed);
        }

        public IDataResult<List<Payment>> GetAll()
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll(), Messages.PaymentListed);
        }

        public IDataResult<List<Payment>> GetByRentalId(int rentalId)
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll(p=>p.RentalId==rentalId), Messages.PaymentListed);
        }

      
    }
}
