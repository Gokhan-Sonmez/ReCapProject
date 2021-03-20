using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentCarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetailDto()
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from co in context.Customers
                             join us in context.Users
                             on co.UserId  equals us.UserId
                            
                             select new CustomerDetailDto
                             {
                                 CustomerId = co.CustomerId,
                                 CompanyName = co.CompanyName,
                                 FirstName = us.FirstName,
                                 LastName = us.LastName
                             };
                return result.ToList();
            }
        }
    }
}
