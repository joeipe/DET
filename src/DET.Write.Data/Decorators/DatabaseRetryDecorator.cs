using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DET.Write.Data.Decorators
{
    public class DatabaseRetryDecorator<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> _handler;

        public DatabaseRetryDecorator(ICommandHandler<TCommand> handler)
        {
            _handler = handler;
        }

        public void Handle(TCommand command)
        {
            var retry = 3;
            for (int i = 0; ; i++)
            {
                try
                {
                    _handler.Handle(command);
                    return;
                }
                catch (Exception ex)
                {
                    if (i >= retry || !IsDatabaseException(ex))
                        throw;
                }
            }
        }

        private bool IsDatabaseException(Exception exception)
        {
            string message = exception.InnerException?.Message;

            if (message == null)
                return false;

            return message.Contains("The connection is broken and recovery is not possible")
                || message.Contains("error occurred while establishing a connection");
        }
    }
}
