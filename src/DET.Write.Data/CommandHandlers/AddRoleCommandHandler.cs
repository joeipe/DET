using DET.Write.Data.Decorators;
using DET.Write.Domain;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DET.Write.Data.CommandHandlers
{
    [DatabaseRetry]
    public class AddRoleCommandHandler : ICommandHandler<AddRoleCommand>
    {
        private DETWriteUow _detUow;

        public AddRoleCommandHandler(DETWriteUow detUow)
        {
            _detUow = detUow;
        }

        public void Handle(AddRoleCommand command)
        {
            if (command.IsValid())
            {
                _detUow.RoleRepo.Add<AddRoleCommand>(command);
                _detUow.Save();
            }
            else
            {
                throw new ArgumentException("Validation failed");
            }
        }
    }
}
