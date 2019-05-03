using App.Domain.Validations.Shop.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Commands.Shop.Category
{
    public class CreateNewCategoryCommand : CategoryCommand
    {
        public CreateNewCategoryCommand(int categoryId, string categoryName, int subCategory)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
            SubCategory = subCategory;
        }
        public override bool IsValid()
        {
            ValidationResult = new CreateNewCategoryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

