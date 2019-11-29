using SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DET.Domain
{
    public class Role : EntityBase
    {
        public string Name { get; private set; }
        public List<User> Users { get; private set; }
    }
}
