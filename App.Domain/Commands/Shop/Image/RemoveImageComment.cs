using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Commands.Shop.Image
{
    public class RemoveImageCommand : ImageCommand
    {
        public RemoveImageCommand(int imageId)
        {
            ImageId = imageId;
            AggregateId = imageId;
        }
        public override bool IsValid()
        {
            return true;
        }
    }
}
