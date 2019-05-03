using App.Application.ViewModels.Shop;
using App.Domain.Core.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Application.EventSourcedNormalizers.Shop.Detail
{
    public class DetailHistory
    {
        public static IList<DetailHistoryData> HistoryData { get; set; }
        public static IList<DetailHistoryData> ToJavaScriptDetailHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<DetailHistoryData>();
            DetailHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.When);
            var list = new List<DetailHistoryData>();
            var last = new DetailHistoryData();
            foreach (var change in sorted)
            {
                var jsSlot = new DetailHistoryData
                {
                    DetailId = change.DetailId == 0 || change.DetailId == last.DetailId
                        ? 0 : change.DetailId,
                    DetailName = string.IsNullOrWhiteSpace(change.DetailName) || change.DetailName == last.DetailName
                        ? "" : change.DetailName,
                    DetailFeature = string.IsNullOrWhiteSpace(change.DetailFeature) || change.DetailFeature == last.DetailFeature
                        ? "" : change.DetailFeature,
                    CategoryViewModel = change.CategoryViewModel.CategoryId == 0 || change.CategoryViewModel == last.CategoryViewModel
                    ? new CategoryViewModel() : change.CategoryViewModel,
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    When = change.When,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void DetailHistoryDeserializer(IList<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new DetailHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "DetailCreatedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.DetailId = values["DetailId"];
                        slot.DetailName = values["DetailName"];
                        slot.DetailFeature = values["DetailFeature"];
                        slot.CategoryViewModel = values["CategoryViewModel"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Who = e.User;
                        break;
                    case "DetailUpdatedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.DetailId = values["DetailId"];
                        slot.DetailName = values["DetailName"];
                        slot.DetailFeature = values["DetailFeature"];
                        slot.CategoryViewModel = values["CategoryViewModel"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Who = e.User;
                        break;
                    case "DetailRemovedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Action = "Removed";
                        slot.When = values["Timestamp"];
                        slot.DetailId = values["DetailId"];
                        slot.Who = e.User;
                        break;
                }
                HistoryData.Add(slot);
            }
        }
    }
}
