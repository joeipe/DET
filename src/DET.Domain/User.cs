using SharedKernel;
using System;

namespace DET.Domain
{
    public class User : EntityBase
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int RoleId { get; private set; }
        public Role Role { get; private set; }
    }
}
