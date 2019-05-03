using App.Domain.Validations.Shop.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Commands.Shop.Category
{
    public class UpdateCategoryCommand : CategoryCommand
    {
        public UpdateCategoryCommand(int categoryId, string categoryName, int subCategory)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
            SubCategory = subCategory;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateCategoryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
