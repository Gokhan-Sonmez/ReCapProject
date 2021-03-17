using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            
                using (RentCarContext context = new RentCarContext())
                {
                    var result = from ca in context.Cars
                                 join co in context.Colors
                                 on ca.ColorId equals co.ColorId
                                 join b in context.Brands
                                 on ca.BrandId equals b.BrandId
                                 join im in context.CarImages
                                 on ca.CarId equals im.CarId
                                 select new CarDetailDto
                                 {
                                     CarId = ca.CarId,
                                     CarName = ca.CarName,
                                     ColorId = co.ColorId,
                                     ColorName = co.ColorName,
                                     BrandId = b.BrandId,
                                     BrandName = b.BrandName,
                                     DailyPrice = ca.DailyPrice,
                                     ImagePath = im.ImagePath
                                 };

                return filter == null
                ? result.ToList()
                : result.Where(filter).ToList();

            }

            }
    }
}
