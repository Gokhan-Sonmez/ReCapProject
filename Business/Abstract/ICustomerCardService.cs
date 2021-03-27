﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerCardService
    {

        IResult Add(CustomerCard customerCard);
        IResult Delete(CustomerCard customerCard);
        IResult Update(CustomerCard customerCard);

        IDataResult<CustomerCard> Get(int customerCardId);
        IDataResult<List<CustomerCard>> GetAll();
        IDataResult<List<CustomerCard>> GetByCustomerId(int customerId);
        IDataResult<List<CustomerCard>> GetByCardId(int cardId);
    }
}
