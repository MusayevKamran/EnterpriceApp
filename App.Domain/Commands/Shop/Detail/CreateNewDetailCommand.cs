using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Commands.Shop.Detail
{
    public class CreateNewDetailCommand : DetailCommand
    {
        public CreateNewDetailCommand(int detailId, string detailName, string detailFuture, Models.Shop.Category category)
        {
            DetailId = detailId;
            DetailName = detailName;
            DetailFeature = detailFuture;
            Category = category;
        }
        public override bool IsValid()
        {
            return true;
        }
    }
}
