using Business.Concrete;
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
            CarManager carManager = new CarManager(new EfCarDal());


            var result = carManager.Add(new Car { BrandId = 3, ColorId = 3, ModelYear = 2000, DailyPrice = 0, Description = "Hy" });

            if (result.Success==true)
            {
                Console.WriteLine(result.Messages);
            }
            else
            {
              
               Console.WriteLine(result.Messages);

            }
            // carManager.Delete(new Car { Id = 1002});

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
