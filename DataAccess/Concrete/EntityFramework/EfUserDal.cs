using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, RentCarContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new RentCarContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.OperationClaimId equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.UserId
                             select new OperationClaim { OperationClaimId = operationClaim.OperationClaimId, Name = operationClaim.Name };
                return result.ToList();

            }
        }

        public List<UserForUpdateDto> GetUserDetails(Expression<Func<User, bool>> filter = null)
        {

            using (RentCarContext context = new RentCarContext())
            {
                var result = from u in filter is null ? context.Users : context.Users.Where(filter)
                           
                             select new UserForUpdateDto
                             {
                                UserId=u.UserId,
                                FirstName=u.FirstName,
                                LastName=u.LastName,
                                Email=u.Email,
                                
                             };

                return result.ToList();

            }

        }
    }
}
