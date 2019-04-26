using App.Domain.Commands.Shop.Category;


namespace App.Domain.Validations.Shop.Category
{
    public class CreateNewCategoryCommandValidation : CategoryValidation<CreateNewCategoryCommand>
    {
        public CreateNewCategoryCommandValidation()
        {
            ValidateId();
            ValidateName();
        }
    }
}
