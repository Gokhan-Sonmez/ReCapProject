using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICardService
    {

        IResult Add(Card card);
        IResult Delete(Card card);
        IResult Update(Card card);
        IDataResult<Card> Get(int cardid);
        IDataResult<List<Card>> GetAll();
    
    }
}
