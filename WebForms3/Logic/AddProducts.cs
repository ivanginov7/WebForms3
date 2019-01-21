using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebForms3.Models;

namespace WebForms3.Logic
{
    public class AddProducts
    {
        public bool AddProduct(string ProductName, string ProductDesc, string ProductPrice, string ProductCategory, string ProductImagePath, int ID=0)
        {
            var myProduct = new Product();
            myProduct.ProductName = ProductName;
            myProduct.Description = ProductDesc;
            myProduct.UnitPrice = Convert.ToDouble(ProductPrice);
            myProduct.ImagePath = ProductImagePath;
            myProduct.CategoryID = Convert.ToInt32(ProductCategory);

            using (var _db = new ApplicationDbContext())
            {
                if (ID == 0)
                {
                    // Add new product to DB.
                    _db.Products.Add(myProduct);

                }
                else
                {
                    //Update existing record
                    myProduct.ProductID = ID;
                    _db.Entry(myProduct).State = System.Data.Entity.EntityState.Modified;
                }
                _db.SaveChanges();
            }
            // Success.
            return true;
        }
    }
}