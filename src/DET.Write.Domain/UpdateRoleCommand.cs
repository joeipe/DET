using DET.Write.Domain.Validations;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DET.Write.Domain
{
    public class UpdateRoleCommand : RoleCommand
    {
        public UpdateRoleCommand()
        {

        }

        public UpdateRoleCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateRoleValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
