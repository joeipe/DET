using System;
using System.Collections.Generic;
using System.Text;

namespace DET.Web.ViewModels
{
    public class UserVM : VMBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public RoleVM Role { get; set; }
    }
}
