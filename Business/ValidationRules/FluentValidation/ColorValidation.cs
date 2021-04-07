using Entities.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidation:AbstractValidator<Color>
    {
        public ColorValidation()
        {
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.ColorName).NotEmpty();
            
        }
    }
}
