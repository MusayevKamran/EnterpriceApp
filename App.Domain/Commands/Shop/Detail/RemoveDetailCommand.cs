using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Commands.Shop.Detail
{
    public class RemoveDetailCommand : DetailCommand
    {
        public RemoveDetailCommand(int detailId)
        {
            DetailId = detailId;
            AggregateId = detailId;
        }
        public override bool IsValid()
        {
            return true;
        }
    }
}
