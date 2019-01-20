using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForms3.Models.ViewModels
{
    public class ProductsWithCategoriesViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        
        public string Description { get; set; }

        public string ImagePath { get; set; }

        
        public double? UnitPrice { get; set; }
    }
}