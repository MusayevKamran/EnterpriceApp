using App.Domain.Commands.Shop.Comment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Validations.Shop.Comment
{
    public abstract class CommentValidation<T> : AbstractValidator<T> where T : CommentCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.CommentContent)
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

