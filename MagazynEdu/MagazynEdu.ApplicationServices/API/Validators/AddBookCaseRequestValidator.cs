using FluentValidation;
using MagazynEdu.ApplicationServices.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynEdu.ApplicationServices.API.Validators
{
    public class AddBookCaseRequestValidator : AbstractValidator<AddBookCaseRequest>
    {
        public AddBookCaseRequestValidator()
        {
            this.RuleFor(x => x.Number).InclusiveBetween(0, 10).WithMessage("WRONG_RANGE"); 
            this.RuleFor(x => x.Name).Length(1, 10);
        }
    }
}
