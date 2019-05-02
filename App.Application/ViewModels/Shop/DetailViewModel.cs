using App.Domain.Models.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.ViewModels.Shop
{
    public class DetailViewModel
    {
        public int DetailId { get;  set; }
        public string DetailName { get;  set; }
        public string DetailFeature { get;  set; }
        public Category Category { get;  set; }
    }
}
