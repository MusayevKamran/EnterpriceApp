using App.Application.ViewModels.Shop;
using App.Domain.Core.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Application.EventSourcedNormalizers.Shop.Category
{
    public class CategoryHistory
    {
        public static IList<CategoryHistoryData> HistoryData { get; set; }
        public static IList<CategoryHistoryData> ToJavaScriptCategoryHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<CategoryHistoryData>();
            CategoryHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.When);
            var list = new List<CategoryHistoryData>();
            var last = new CategoryHistoryData();
            foreach (var change in sorted)
            {
                var jsSlot = new CategoryHistoryData
                {
                    CategoryId = change.CategoryId == 0 || change.CategoryId == last.CategoryId
                        ? 0 : change.CategoryId,
                    CategoryName = string.IsNullOrWhiteSpace(change.CategoryName) || change.CategoryName == last.CategoryName
                        ? "" : change.CategoryName,
                    SubCategory = change.SubCategory == 0 || change.SubCategory == last.SubCategory
                        ? 0 : change.SubCategory,
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    When = change.When,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void CategoryHistoryDeserializer(IList<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new CategoryHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "CategoryCreatedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.CategoryId = values["CategoryId"];
                        slot.CategoryName = values["CategoryName"];
                        slot.SubCategory = values["SubCategory"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Who = e.User;
                        break;
                    case "CategoryUpdatedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.CategoryId = values["CategoryId"];
                        slot.CategoryName = values["CategoryName"];
                        slot.SubCategory = values["SubCategory"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Who = e.User;
                        break;
                    case "CategoryRemovedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Action = "Removed";
                        slot.When = values["Timestamp"];
                        slot.CategoryId = values["CategoryId"];
                        slot.Who = e.User;
                        break;
                }
                HistoryData.Add(slot);
            }
        }
    }
}
