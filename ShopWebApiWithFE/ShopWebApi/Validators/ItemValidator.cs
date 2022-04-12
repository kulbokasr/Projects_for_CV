using FluentValidation;
using ShopWebApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebApi.Validators
{
    public class ItemValidator : AbstractValidator<CreateItem> 
    {
        public ItemValidator()
        {
            RuleFor(x => x.Price).GreaterThan(0.01);
        }

    }
}
