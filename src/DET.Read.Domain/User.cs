using SharedKernel;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DET.Read.Domain
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int RoleId { get; private set; }
        public Role Role { get; private set; }
    }
}
