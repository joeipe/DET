using DET.Write.Data.Decorators;
using DET.Write.Domain;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DET.Write.Data.CommandHandlers
{
    [DatabaseRetry]
    public class DeleteRoleCommandHandler : ICommandHandler<DeleteRoleCommand>
    {
        private DETWriteUow _detUow;

        public DeleteRoleCommandHandler(DETWriteUow detUow)
        {
            _detUow = detUow;
        }

        public void Handle(DeleteRoleCommand command)
        {
            _detUow.RoleRepo.Delete(command);
            _detUow.Save();
        }
    }
}
