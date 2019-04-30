using App.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Models.Shop
{
    public class Detail : Entity<int>
    {
        public Detail() { }
        public Detail(int detailId, string detailName, string detailFeature, Category category)
        {
            DetailId = detailId;
            DetailName = detailName;
            DetailFeature = detailFeature;
            Category = category;
        }
        public int DetailId { get; private set; }
        public virtual string DetailName { get; private set; }
        public virtual string DetailFeature { get; private set; }
        public virtual Category Category { get; private set; }
    }
}
