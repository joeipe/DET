using DET.Write.Domain.Validations;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DET.Write.Domain
{
    public class UpdateUserCommand : UserCommand
    {
        public UpdateUserCommand()
        {

        }

        public UpdateUserCommand(int id, string firstName, string lastName, int roleId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            RoleId = roleId;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateUserValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
