using App.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Commands.Shop.Detail
{
    public abstract class DetailCommand : Command
    {
        public int DetailId { get; set; }
        public string DetailName { get; set; }
        public string DetailFeature { get; set; }
        public Models.Shop.Category Category { get; set; }
    }
}
