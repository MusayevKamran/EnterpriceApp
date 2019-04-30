using App.Domain.Commands.Shop.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Validations.Shop.Product
{
    public class RemoveProductCommandValidation : ProductValidation<RemoveProductCommand>
    {
        public RemoveProductCommandValidation()
        {
            ValidateId();
            ValidateName();
        }
    }
}
