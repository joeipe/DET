using SharedKernel;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;

namespace DET.Read.Domain
{
    public class Role : IEntity
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public List<User> Users { get; private set; }
    }
}
