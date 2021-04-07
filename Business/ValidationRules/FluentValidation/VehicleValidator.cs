using Entities.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class VehicleValidator:AbstractValidator<Vehicle>
    {
        public VehicleValidator()
        {
            RuleFor(v => v.CarId).NotEmpty();
            RuleFor(v => v.CarId).GreaterThan(0);
            RuleFor(v => v.VehicleName).NotEmpty();
            RuleFor(v => v.VehicleName).MinimumLength(2);
            RuleFor(v => v.DailyPrice).NotEmpty();
            RuleFor(v => v.DailyPrice).GreaterThan(0);
            RuleFor(v => v.DailyPrice).GreaterThanOrEqualTo(200).When(v => v.BrandId  == 4).WithMessage("Günlük tutar 200 veya üzeri olmalı!");
            RuleFor(v => v.DailyPrice).GreaterThanOrEqualTo(250).When(v => v.BrandId == 5).WithMessage("Günlük tutar 250 veya üzeri olmalı!");

        }
    }
}
