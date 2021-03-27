using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        IFindeksCheckService _findeksCheckService;

        public RentalManager(IRentalDal rentalDal, IFindeksCheckService findeksCheckService)
        {
            _rentalDal = rentalDal;
            _findeksCheckService = findeksCheckService;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(RentCarReturnDateCheck(rental.CarId),RentCarStatusCheck(rental.CarId), 
                CheckIfFindeksEnough(rental.CustomerId,rental.CarId));
            if (result != null)
            {
                return result;
            }


            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDelete);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdate);
        }

        public IDataResult<Rental> Get(int rentalid)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == rentalid), Messages.RentalIdListed);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.RentalListed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalByCarId(int carId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(c => c.CarId == carId));
        }


        private IResult RentCarReturnDateCheck(int carId)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId);
            if (result.Count > 0)
            {
                foreach (var rent in result)
                {
                    if (rent.ReturnDate == null)
                    {
                        return new ErrorResult(Messages.DontAvailable);

                    }
                }
            }
            return new SuccessResult();
        }

        private IResult RentCarStatusCheck(int carId)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId);
            if (result.Count > 0)
            {
                foreach (var rent in result)
                {
                    if (rent.Status == false)
                    {
                        return new ErrorResult(Messages.DontAvailable);
                    }
                }
            }
            return new SuccessResult();
        }

        private IResult CheckIfFindeksEnough(int customerId,int carId)
        {
            var result = _findeksCheckService.CheckIfFindeksEnough(customerId, carId);
            if (!result)
            {
                return new ErrorResult(Messages.FindeksNotEnough);
            }

            return new SuccessResult(Messages.FindeksEnough);
        }

    }
}
