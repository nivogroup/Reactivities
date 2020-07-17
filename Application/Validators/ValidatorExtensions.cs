using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Validators
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MinimumLength(6).WithMessage("Min length 6")
                .Matches("[A-Z]").WithMessage("Atleast 1 Uppercae")
                .Matches("[a-z]").WithMessage("Atleast 1 lowercase")
                .Matches("[0-9]").WithMessage("Atleast 1 Number")
                .Matches("[^a-zA-Z0-9]").WithMessage("Atleast on Special Character");

            return options;
        }
    }
}
