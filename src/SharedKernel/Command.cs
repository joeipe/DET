using FluentValidation.Results;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SharedKernel
{
    public abstract class Command : ICommand
    {
        [NotMapped]
        public ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid();
    }
}
