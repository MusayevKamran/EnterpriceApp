using App.Application.ViewModels.Shop;
using App.Domain.Core.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Application.EventSourcedNormalizers.Shop.Image
{
    public class ImageHistory
    {
        public static IList<ImageHistoryData> HistoryData { get; set; }
        public static IList<ImageHistoryData> ToJavaScriptImageHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<ImageHistoryData>();
            ImageHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.When);
            var list = new List<ImageHistoryData>();
            var last = new ImageHistoryData();
            foreach (var change in sorted)
            {
                var jsSlot = new ImageHistoryData
                {
                    ImageId = change.ImageId == 0 || change.ImageId == last.ImageId
                        ? 0 : change.ImageId,
                    ImageLink = string.IsNullOrWhiteSpace(change.ImageLink) || change.ImageLink == last.ImageLink
                        ? "" : change.ImageLink,
                    ProfileImage = change.ProfileImage == false || change.ProfileImage == last.ProfileImage
                        ? false : change.ProfileImage,
                    ProductViewModel = change.ProductViewModel.ProductId == 0 || change.ProductViewModel == last.ProductViewModel
                    ? new ProductViewModel() : change.ProductViewModel,
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    When = change.When,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void ImageHistoryDeserializer(IList<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new ImageHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "ImageCreatedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.ImageId = values["ImageId"];
                        slot.ImageLink = values["ImageLink"];
                        slot.ProfileImage = values["ProfileImage"];
                        slot.ProductViewModel = values["ProductViewModel"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Who = e.User;
                        break;
                    case "ImageUpdatedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.ImageId = values["ImageId"];
                        slot.ImageLink = values["ImageLink"];
                        slot.ProfileImage = values["ProfileImage"];
                        slot.ProductViewModel = values["ProductViewModel"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Who = e.User;
                        break;
                    case "ImageRemovedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Action = "Removed";
                        slot.When = values["Timestamp"];
                        slot.ImageId = values["ImageId"];
                        slot.Who = e.User;
                        break;
                }
                HistoryData.Add(slot);
            }
        }
    }
}
