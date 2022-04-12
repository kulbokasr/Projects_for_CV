using FluentValidation;
using ShopWebApi.Dtos;
using ShopWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebApi.Validators
{
    public class ShopValidator : AbstractValidator<CreateShop>
    {
        public ShopValidator()
        {
            RuleFor(s => s.Name).NotNull().MinimumLength(4);
        }

    }
}
