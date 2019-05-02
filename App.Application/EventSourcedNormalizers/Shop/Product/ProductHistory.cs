using App.Application.ViewModels.Shop;
using App.Domain.Core.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Application.EventSourcedNormalizers.Shop.Product
{
    public class ProductHistory
    {
        public static IList<ProductHistoryData> HistoryData { get; set; }
        public static IList<ProductHistoryData> ToJavaScriptProductHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<ProductHistoryData>();
            CategoryHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.When);
            var list = new List<ProductHistoryData>();
            var last = new ProductHistoryData();
            foreach (var change in sorted)
            {
                var jsSlot = new ProductHistoryData
                {
                    ProductId = change.ProductId == Guid.Empty.ToString() || change.ProductId == last.ProductId
                        ? "" : change.ProductId,
                    ProductName = string.IsNullOrWhiteSpace(change.ProductName) || change.ProductName == last.ProductName
                        ? "" : change.ProductName,
                    CategoryViewModel = change.CategoryViewModel.CategoryId == 0 || change.CategoryViewModel == last.CategoryViewModel
                        ? new CategoryViewModel() : change.CategoryViewModel,
                    DetailViewModel = change.DetailViewModel.DetailId == 0 || change.DetailViewModel == last.DetailViewModel
                        ? new DetailViewModel() : change.DetailViewModel,
                    ImageViewModel = change.ImageViewModel.ImageId == 0 || change.ImageViewModel == last.ImageViewModel
                        ? new ImageViewModel() : change.ImageViewModel,
                    SellerViewModel = change.SellerViewModel.SellerId == 0 || change.SellerViewModel == last.SellerViewModel
                        ? new SellerViewModel() : change.SellerViewModel,
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
                var slot = new ProductHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "CategoryCreatedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.ProductId = values["ProductId"];
                        slot.ProductName = values["ProductName"];
                        slot.CategoryViewModel = values["CategoryViewModel"];
                        slot.DetailViewModel = values["DetailViewModel"];
                        slot.ImageViewModel = values["ImageViewModel"];
                        slot.SellerViewModel = values["SellerViewModel"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Who = e.User;
                        break;
                    case "CategoryUpdatedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.ProductId = values["ProductId"];
                        slot.ProductName = values["ProductName"];
                        slot.CategoryViewModel = values["CategoryViewModel"];
                        slot.DetailViewModel = values["DetailViewModel"];
                        slot.ImageViewModel = values["ImageViewModel"];
                        slot.SellerViewModel = values["SellerViewModel"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Who = e.User;
                        break;
                    case "CategoryRemovedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Action = "Removed";
                        slot.When = values["Timestamp"];
                        slot.ProductId = values["ProductId"];
                        slot.Who = e.User;
                        break;
                }
                HistoryData.Add(slot);
            }
        }
    }
}
