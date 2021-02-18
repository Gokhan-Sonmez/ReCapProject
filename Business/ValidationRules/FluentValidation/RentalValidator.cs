
using Entities.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {


        public RentalValidator()
        {

            RuleFor(r => r.RentDate).NotEmpty();


        }

       

    }
}
