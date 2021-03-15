using Business.Abstract;
using Business.Constans;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
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

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceded(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Add(file).Replace("\\", "/");
            carImage.UploadDate = DateTime.Now;
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.ImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            
            FileHelper.Delete(GetPath(carImage.ImageId).Replace("/", "\\"));
            _carImageDal.Delete(carImage);
            

            return new SuccessResult(Messages.ImageDelete);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceded(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Update(GetPath(carImage.ImageId), file).Replace("\\", "/");
            carImage.UploadDate = DateTime.Now;

            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.ImageUpdate);
        }

        public IDataResult<CarImage> Get(int id)
        {

            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.ImageId == id), Messages.ImageListed);

        }

        public IDataResult<List<CarImage>> GetCarImageByCarId(int CarId)
        {
            IResult result = BusinessRules.Run(CheckCarImageExists(CarId));

            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Messages);
            }
            return new SuccessDataResult<List<CarImage >>(CheckCarImageExists(CarId).Data, Messages.ImageListed);
             
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


        private IDataResult<List<CarImage>> CheckCarImageExists(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Any();
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"/images/default.png");
            if (!result)
            {

                List<CarImage> carimage = new List<CarImage>();
                carimage.Add(new CarImage { CarId = carId, ImagePath = path.Replace("\\", "/"), UploadDate = DateTime.Now });
                return new SuccessDataResult<List<CarImage>>(carimage);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == carId).ToList());
        }

        
        private string GetPath(int id)
        {
            var result = _carImageDal.Get(p => p.ImageId == id);
            return result.ImagePath;
           
        }

    }
}
