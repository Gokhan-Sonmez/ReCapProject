using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
         //CarTest();

            //ColorTest();

            //BrandTest();

            //CarAddTest(carManager);
            // carManager.Delete(new Car { Id = 1002});

            RentalAddTest();

        }

        private static void RentalAddTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result = rentalManager.Add(new Rental
            {
                CarId = 4,
                CustomerId = 2,
                RentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                

            }) ;

            Messages(result);
        }

        private static void Messages(IResult result)
        {
            if (result.Success == true)
            {
                Console.WriteLine(result.Messages);
            }
            else
            {

                Console.WriteLine(result.Messages);

            }
        }

        private static void CarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            
            var result = carManager.Add(new Car { CarName = "TESLA Model S", BrandId = 3, ColorId = 3, ModelYear = 2000, DailyPrice = 0, Description = "Otomatik" });
           
            Messages(result);

        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.BrandName + " "+ car.CarName + " " + car.ColorName +" Price : " + car.DailyPrice);
            }

           
        }
    }
}
