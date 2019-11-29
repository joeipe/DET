using DET.Write.Domain.Validations;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DET.Write.Domain
{
    public class AddUserCommand : UserCommand
    {
        public AddUserCommand()
        {

        }

        public AddUserCommand(string firstName, string lastName, int roleId)
        {
            FirstName = firstName;
            LastName = lastName;
            RoleId = roleId;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddUserValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
