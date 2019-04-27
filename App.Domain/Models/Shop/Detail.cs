using App.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Models.Shop
{
    public class Detail : Entity<int>
    {
        public Detail(Guid detailId, string detailName, string detailFeature)
        {
            DetailId = detailId;
            DetailName = detailName;
            DetailFeature = detailFeature;
        }
        public Guid DetailId { get; set; }
        public string DetailName { get; set; }
        public string DetailFeature { get; set; }
        public Category Category { get; set; }
    }
}
