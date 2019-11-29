using System;
using System.Collections.Generic;
using System.Text;

namespace DET.Write.Domain
{
    public class DeleteRoleCommand : RoleCommand
    {
        public DeleteRoleCommand()
        {

        }

        public DeleteRoleCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
