using App.Domain.Core.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Application.EventSourcedNormalizers.Shop.Seller
{
    public class SellerHistory
    {
        public static IList<SellerHistoryData> HistoryData { get; set; }
        public static IList<SellerHistoryData> ToJavaScriptSellerHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<SellerHistoryData>();
            SellerHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.When);
            var list = new List<SellerHistoryData>();
            var last = new SellerHistoryData();
            foreach (var change in sorted)
            {
                var jsSlot = new SellerHistoryData
                {
                    SellerId = change.SellerId == 0 || change.SellerId == last.SellerId
                        ? 0 : change.SellerId,
                    Name = string.IsNullOrWhiteSpace(change.Name) || change.Name == last.Name
                        ? "" : change.Name,
                    Email = string.IsNullOrWhiteSpace(change.Email) || change.Email == last.Email
                        ? "" : change.Email,
                    PhoneNumber = string.IsNullOrWhiteSpace(change.PhoneNumber) || change.PhoneNumber == last.PhoneNumber
                        ? "" : change.PhoneNumber,
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    When = change.When,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void SellerHistoryDeserializer(IList<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new SellerHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "SellerCreatedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.SellerId = values["SellerId"];
                        slot.Name = values["Name"];
                        slot.Email = values["Email"];
                        slot.PhoneNumber = values["PhoneNumber"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Who = e.User;
                        break;
                    case "SellerUpdatedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.SellerId = values["SellerId"];
                        slot.Name = values["Name"];
                        slot.Email = values["Email"];
                        slot.PhoneNumber = values["PhoneNumber"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Who = e.User;
                        break;
                    case "SellerRemovedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Action = "Removed";
                        slot.When = values["Timestamp"];
                        slot.SellerId = values["SellerId"];
                        slot.Who = e.User;
                        break;
                }
                HistoryData.Add(slot);
            }
        }
    }
}
