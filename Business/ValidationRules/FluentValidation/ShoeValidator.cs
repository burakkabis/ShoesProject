using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ShoeValidator : AbstractValidator<Shoe>
    {


        public ShoeValidator()
        {
            RuleFor(s => s.ShoeName).NotEmpty().WithMessage("Ayakkabi ismi bos olamaz.");
            RuleFor(s => s.ShoeName).MinimumLength(3).WithMessage("Ayakkabi ismi en az 3 harften olusmali");
            RuleFor(s => s.UnitPrice).NotEmpty().WithMessage("Fiyat bos olmamali.");
            RuleFor(s => s.UnitPrice).GreaterThan(0).WithMessage("Fiyat 0 dan buyuk olmali.");
           // RuleFor(s => s.AnimalPrice).GreaterThanOrEqualTo(10).When(p => p.ColorId == 1);
           // RuleFor(s => a.AnimalName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");

        }

        //private bool StartWithA(string arg)
        //{
        //    return arg.StartsWith("A");
        //}
    }
}
