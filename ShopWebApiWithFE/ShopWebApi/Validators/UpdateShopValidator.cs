using FluentValidation;
using ShopWebApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebApi.Validators
{
    public class UpdateShopValidator : AbstractValidator<UpdateShop>
    {
        public UpdateShopValidator()
        {
            RuleFor(s => s.Name).NotNull().MinimumLength(4);
        }

    }
}