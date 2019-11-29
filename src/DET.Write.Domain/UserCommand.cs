using DET.Write.Domain.Validations;
using SharedKernel;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DET.Write.Domain
{
    public class UserCommand : Entity
    {
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public int RoleId { get; protected set; }
        public RoleCommand Role { get; private set; }

        public override bool IsValid()
        {
            return true;
        }
    }
}
