using DET.Write.Data.Decorators;
using DET.Write.Domain;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DET.Write.Data.CommandHandlers
{
    [DatabaseRetry]
    public class UpdateRoleCommandHandler : ICommandHandler<UpdateRoleCommand>
    {
        private DETWriteUow _detUow;

        public UpdateRoleCommandHandler(DETWriteUow detUow)
        {
            _detUow = detUow;
        }
        public void Handle(UpdateRoleCommand command)
        {
            if (command.IsValid())
            {
                _detUow.RoleRepo.Edit<UpdateRoleCommand>(command);
                _detUow.Save();
            }
            else
            {
                throw new ArgumentException("Validation failed");
            }
        }
    }
}
