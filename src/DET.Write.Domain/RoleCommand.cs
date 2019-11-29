using DET.Write.Domain.Validations;
using SharedKernel;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;

namespace DET.Write.Domain
{
    public class RoleCommand : Entity
    {
        public string Name { get; protected set; }
        public List<UserCommand> Users { get; private set; }

        public override bool IsValid()
        {
            return true;
        }
    }
}
