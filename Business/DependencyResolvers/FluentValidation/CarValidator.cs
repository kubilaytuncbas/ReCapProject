using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.CarName).MinimumLength(2);
            //RuleFor(p => p.CarName).Must(StartWithA); Kendin Kural oluşturmak istediğinde kullanacağın yapı
        }

        //private bool StartWithA(string arg)
        //{
        //    return arg.StartsWith("A");
        //}
    }
}
