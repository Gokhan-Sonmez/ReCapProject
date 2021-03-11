using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentCarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from re in context.Rentals
                             join ca in context.Cars
                             on re.CarId equals ca.CarId
                             join b in context.Brands
                             on ca.BrandId equals b.BrandId
                             join cu in context.Customers
                             on re.CustomerId equals cu.CustomerId
                             join us in context.Users
                             on cu.UserId equals us.UserId
                             select new RentalDetailDto
                             {
                                 RentalId= re.RentalId,
                                 BrandName = b.BrandName,
                                 FirstName = us.FirstName,
                                 LastName = us.LastName,
                                 RentDate = re.RentDate
                             };

                return result.ToList();

            }
        }
    }
}
