using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DET.Write.Domain.Validations
{
    public class AddRoleValidation : AbstractValidator<AddRoleCommand>
    {
        public AddRoleValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name cannot be empty");
        }
    }
}
