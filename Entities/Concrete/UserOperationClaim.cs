using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class UserOperationClaim : IEntity
    {
        public int UserOperationClaimId { get; set; }
        public int OpetationClaimId { get; set; }
        public int UserId { get; set; }
    }
}
