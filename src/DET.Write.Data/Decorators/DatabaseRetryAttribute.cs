
using System;
using System.Collections.Generic;
using System.Text;

namespace DET.Write.Data.Decorators
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class DatabaseRetryAttribute : Attribute
    {
        public DatabaseRetryAttribute()
        {

        }
    }
}
