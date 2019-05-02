using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Commands.Shop.Detail
{
    public class UpdateDetailCommand : DetailCommand
    {
        public UpdateDetailCommand(int detailId, string detailName, string detailFuture, Models.Shop.Category category)
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
