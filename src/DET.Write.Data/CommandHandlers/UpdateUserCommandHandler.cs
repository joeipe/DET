using DET.Write.Data.Decorators;
using DET.Write.Domain;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DET.Write.Data.CommandHandlers
{
    [DatabaseRetry]
    public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand>
    {
        private DETWriteUow _detUow;

        public UpdateUserCommandHandler(DETWriteUow detUow)
        {
            _detUow = detUow;
        }

        public void Handle(UpdateUserCommand command)
        {
            if (command.IsValid())
            {
                _detUow.UserRepo.Edit<UpdateUserCommand>(command);
                _detUow.Save();
            }
            else
            {
                throw new ArgumentException("Validation failed");
            }
        }
    }
}
