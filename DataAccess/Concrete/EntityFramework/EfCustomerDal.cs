using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentCarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetailDto(Expression<Func<Customer, bool>> filter = null)
        {
            using (RentCarContext context = new RentCarContext())
            {
                
                var result = from co in filter is null ? context.Customers : context.Customers.Where(filter)
                             join us in context.Users
                             on co.UserId  equals us.UserId
                            
                             select new CustomerDetailDto
                             {
                                 CustomerId = co.CustomerId,
                                 CompanyName = co.CompanyName,
                                 FirstName = us.FirstName,
                                 LastName = us.LastName,
                                 Findeks = co.Findeks
                             };
                return result.ToList();
            }
        }
    }
}
