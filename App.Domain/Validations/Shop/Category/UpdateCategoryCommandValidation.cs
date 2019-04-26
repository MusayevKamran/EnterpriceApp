using App.Domain.Commands.Shop.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Validations.Shop.Category
{
    public class UpdateCategoryCommandValidation : CategoryValidation<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidation()
        {
            ValidateId();
            ValidateName();
        }
    }
}
