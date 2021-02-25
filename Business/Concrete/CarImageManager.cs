using Business.Abstract;
using Business.Constans;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {

        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceded(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.ImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.ImageDelete);
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.ImageUpdate);
        }
        public IDataResult<CarImage> Get(int Id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.ImageId == Id), Messages.ImageIdListed);
             
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.ImageListed);
        }

       private IResult CheckImageLimitExceded(int carId)
        {
            var result = _carImageDal.GetAll(c=>c.CarId== carId);

            if (result.Count>5)
            {
                return new ErrorResult(Messages.ImageLimit);
            }

            return new SuccessResult();

        }


        private IResult CheckImageExists(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Any();

            if (result)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        

    }
}
