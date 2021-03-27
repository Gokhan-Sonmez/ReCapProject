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
    public class CustomerCardManager : ICustomerCardService
    {

        ICustomerCardDal _customerCardDal;

        public CustomerCardManager(ICustomerCardDal customerCardDal)
        {
            _customerCardDal = customerCardDal;
        }

        public IResult Add(CustomerCard customerCard)
        {
            _customerCardDal.Add(customerCard);
            return new SuccessResult(Messages.CardAdded);
        }

        public IResult Delete(CustomerCard customerCard)
        {
            _customerCardDal.Delete(customerCard);
            return new SuccessResult(Messages.CardDeleted);
        }

        public IDataResult<CustomerCard> Get(int customerCardId)
        {
            return new SuccessDataResult<CustomerCard>(_customerCardDal.Get(c=>c.CustomerCardId==customerCardId),Messages.CardListed);
        }

        public IDataResult<List<CustomerCard>> GetAll()
        {
            return new SuccessDataResult<List<CustomerCard>>(_customerCardDal.GetAll(), Messages.CardListed);
        }

        public IDataResult<List<CustomerCard>> GetByCardId(int cardId)
        {
            return new SuccessDataResult<List<CustomerCard>>(_customerCardDal.GetAll(c=>c.CardId==cardId),Messages.CardListed);
        }

        public IDataResult<List<CustomerCard>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<CustomerCard>>(_customerCardDal.GetAll(c=>c.CustomerId==customerId), Messages.CardListed);
        }

        public IResult Update(CustomerCard customerCard)
        {
            _customerCardDal.Update(customerCard);
            return new SuccessResult(Messages.CardUpdated);
        }
    }
}
