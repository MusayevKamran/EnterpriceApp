using App.Domain.Models.Shop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Application.ViewModels.Shop
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "The Category Name is Required")]
        [MinLength(3)]
        [MaxLength(30)]
        [DisplayName("CategoryName")]
        public string CategoryName { get; set; }

    }
}
