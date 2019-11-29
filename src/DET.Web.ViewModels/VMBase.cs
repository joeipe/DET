using SharedKernel.Interfaces;
using System;

namespace DET.Web.ViewModels
{
    public abstract class VMBase : IEntity
    {
        public int Id { get; set; }
    }
}
