using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Interfaces
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
