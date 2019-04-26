using App.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Commands.Shop.Category
{
    public abstract class CategoryCommand : Command
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
