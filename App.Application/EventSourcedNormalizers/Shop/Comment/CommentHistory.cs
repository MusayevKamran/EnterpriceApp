using App.Application.ViewModels.Shop;
using App.Domain.Core.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Application.EventSourcedNormalizers.Shop.Comment
{
    public class CommentHistory
    {
        public static IList<CommentHistoryData> HistoryData { get; set; }
        public static IList<CommentHistoryData> ToJavaScriptCommentHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<CommentHistoryData>();
            CommentHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.When);
            var list = new List<CommentHistoryData>();
            var last = new CommentHistoryData();
            foreach (var change in sorted)
            {
                var jsSlot = new CommentHistoryData
                {
                    CommentId = change.CommentId == 0 || change.CommentId == last.CommentId
                        ? 0 : change.CommentId,
                    CommentContent = string.IsNullOrWhiteSpace(change.CommentContent) || change.CommentContent == last.CommentContent
                        ? "" : change.CommentContent,
                    ProductViewModel = change.ProductViewModel.ProductId == 0 || change.ProductViewModel == last.ProductViewModel
                    ? new ProductViewModel() : change.ProductViewModel,
                    UserId = change.UserId == 0 || change.UserId == last.UserId ? 0 : change.UserId,
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    When = change.When,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void CommentHistoryDeserializer(IList<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new CommentHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "CommentCreatedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.CommentId = values["CommentId"];
                        slot.CommentContent = values["CommentContent"];
                        slot.ProductViewModel = values["ProductViewModel"];
                        slot.UserId = values["UserId"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Who = e.User;
                        break;
                    case "CommentUpdatedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.CommentId = values["CommentId"];
                        slot.CommentContent = values["CommentContent"];
                        slot.ProductViewModel = values["ProductViewModel"];
                        slot.UserId = values["UserId"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Who = e.User;
                        break;
                    case "CommentRemovedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Action = "Removed";
                        slot.When = values["Timestamp"];
                        slot.CommentId = values["CommentId"];
                        slot.Who = e.User;
                        break;
                }
                HistoryData.Add(slot);
            }
        }
    }
}
