using System;
using System.Collections.Generic;
using System.Text;

namespace DET.Write.Domain
{
    public class DeleteUserCommand : UserCommand
    {
        public DeleteUserCommand()
        {

        }

        public DeleteUserCommand(int id, string firstName, string lastName, int roleId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            RoleId = roleId;
        }
    }
}
