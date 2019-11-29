using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DET.Write.Domain.Validations
{
    public class AddUserValidation : AbstractValidator<AddUserCommand>
    {
        public AddUserValidation()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("FirstName cannot be empty");

            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("LastName cannot be empty");

            RuleFor(c => c.RoleId)
                .NotEqual(0).WithMessage("Role cannot be empty");
        }
    }
}
