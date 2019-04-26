using App.Domain.Commands.Shop.Category;
using FluentValidation;
using System;

namespace App.Domain.Validations.Shop.Category
{
    public abstract class CategoryValidation<T> : AbstractValidator<T> where T : CategoryCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.CategoryName)
                .NotEmpty().WithMessage("Please ensure you have entered the Category Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }
        protected void ValidateId()
        {
            RuleFor(c => c.CategoryId)
                .NotEqual(Guid.Empty);
        }
    }
}
