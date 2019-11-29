using DET.Write.Domain.Validations;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DET.Write.Domain
{
    public class AddRoleCommand : RoleCommand
    {
        public AddRoleCommand()
        {

        }

        public AddRoleCommand(string name)
        {
            Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddRoleValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
