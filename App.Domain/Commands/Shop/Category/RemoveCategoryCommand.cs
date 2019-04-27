using App.Domain.Validations.Shop.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Commands.Shop.Category
{
    public class RemoveCategoryCommand : CategoryCommand
    {
        public RemoveCategoryCommand(int categoryId)
        {
            CategoryId = categoryId;
            AggregateId = categoryId;
        }
        public override bool IsValid()
        {
            ValidationResult = new RemoveCategoryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
