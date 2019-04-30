using App.Domain.Commands.Shop.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Validations.Shop.Product
{
    public class UpdateProductCommandValidation : ProductValidation<UpdateProductCommand>
    {
        public UpdateProductCommandValidation()
        {
            ValidateId();
            ValidateName();
        }
    }
}
