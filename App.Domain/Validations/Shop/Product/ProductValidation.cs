using App.Domain.Commands.Shop.Product;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Validations.Shop.Product
{
    public abstract class ProductValidation<T> : AbstractValidator<T> where T : ProductCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.ProductName)
                .NotEmpty().WithMessage("Please ensure you have entered the Category Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }
        protected void ValidateId()
        {
            //RuleFor(c => c.CategoryId)
            //    .NotEqual(Guid.Empty);
        }
    }
}
