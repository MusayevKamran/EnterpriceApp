using App.Domain.Validations.Shop.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Commands.Shop.Category
{
    public class CreateNewCategoryCommand : CategoryCommand
    {
        public CreateNewCategoryCommand(Guid categoryId, string categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
            AggregateId = categoryId;
        }
        public override bool IsValid()
        {
            ValidationResult = new CreateNewCategoryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

