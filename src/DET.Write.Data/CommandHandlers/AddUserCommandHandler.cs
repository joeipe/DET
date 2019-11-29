using DET.Write.Data.Decorators;
using DET.Write.Domain;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DET.Write.Data.CommandHandlers
{
    [DatabaseRetry]
    public class AddUserCommandHandler : ICommandHandler<AddUserCommand>
    {
        private DETWriteUow _detUow;

        public AddUserCommandHandler(DETWriteUow detUow)
        {
            _detUow = detUow;
        }

        public void Handle(AddUserCommand command)
        {
            if (command.IsValid())
            {
                _detUow.UserRepo.Add<AddUserCommand>(command);
                _detUow.Save();
            }
            else
            {
                throw new ArgumentException("Validation failed");
            }
        }
    }
}
