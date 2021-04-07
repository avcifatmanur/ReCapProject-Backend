using Entities.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.UserId).NotEmpty();
            RuleFor(u => u.UserId).GreaterThan(0);
            RuleFor(u => u.UserFirstName).NotEmpty();
            RuleFor(u => u.UserFirstName).MinimumLength(2);
            RuleFor(u => u.UserLastName).NotEmpty();
            RuleFor(u => u.UserLastName).MinimumLength(2);
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).Must(ValidEmail).WithMessage("Geçerli bir mail adresi olmalı!");
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password).MinimumLength(6).WithMessage("Parola en az 6 karakter uzunluğunda olmalı!");
        }

        private bool ValidEmail(string arg)
        {
            string ifadeler = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(ifadeler, RegexOptions.IgnoreCase);
            return regex.IsMatch(arg);
        }
    }
}
