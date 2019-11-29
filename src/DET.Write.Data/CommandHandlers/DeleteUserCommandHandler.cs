using DET.Write.Data.Decorators;
using DET.Write.Domain;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DET.Write.Data.CommandHandlers
{
    [DatabaseRetry]
    public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand>
    {
        private DETWriteUow _detUow;

        public DeleteUserCommandHandler(DETWriteUow detUow)
        {
            _detUow = detUow;
        }

        public void Handle(DeleteUserCommand command)
        {
            _detUow.UserRepo.Delete(command);
            _detUow.Save();
        }
    }
}
