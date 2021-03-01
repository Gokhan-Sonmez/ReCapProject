using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class OperationClaim : IEntity
    {
        public int OperationClaimId { get; set; }
        public string Name { get; set; }
    }
}
