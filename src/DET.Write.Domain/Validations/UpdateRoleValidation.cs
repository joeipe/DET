using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DET.Write.Domain.Validations
{
    public class UpdateRoleValidation : AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleValidation()
        {
            RuleFor(c => c.Id)
                .NotEqual(0).WithMessage("Id cannot be empty");

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name cannot be empty");
        }
    }
}
