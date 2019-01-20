using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms3.Logic;
using WebForms3.Models;

namespace WebForms3.Admin
{
    public partial class AdminPage : System.Web.UI.Page
    {
        private Product updateProduct = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            string productAction = Request.QueryString["ProductAction"];
            if (productAction == "add")
            {
                LabelAddStatus.Text = "Product added!";
            }

            if (productAction == "remove")
            {
                LabelRemoveStatus.Text = "Product removed!";
            }
        }

        protected void AddProductButton_Click(object sender, EventArgs e)
        {
            Boolean fileOK = false;
            String path = Server.MapPath("~/Catalog/Images/");
            if (UpdateFileUpload.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(UpdateFileUpload.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
            }

            if (fileOK)
            {
                try
                {
                    // Save to Images folder.
                    UpdateFileUpload.PostedFile.SaveAs(path + UpdateFileUpload.FileName);
                    // Save to Images/Thumbs folder.
                    UpdateFileUpload.PostedFile.SaveAs(path + "Thumbs/" + UpdateFileUpload.FileName);
                }
                catch (Exception ex)
                {
                    LabelAddStatus.Text = ex.Message;
                }

                // Add product data to DB.
                AddProducts products = new AddProducts();
                bool addSuccess = products.AddProduct(UpdateNameTextBox.Text, UpdateDescriptionTextBox.Text,
                    UpdatePriceTextBox.Text, UpdateCategoryDropDownList.SelectedValue, UpdateFileUpload.FileName);
                if (addSuccess)
                {
                    // Reload the page.
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?ProductAction=add");
                }
                else
                {
                    LabelAddStatus.Text = "Unable to add new product to database.";
                }
            }
            else
            {
                LabelAddStatus.Text = "Unable to accept file type.";
            }
        }

        public IQueryable GetCategories()
        {
            var _db = new ApplicationDbContext();
            IQueryable query = _db.Categories;
            return query;
        }

        public IQueryable GetProducts()
        {
            var _db = new ApplicationDbContext();
            IQueryable query = _db.Products;
            return query;
        }

        protected void RemoveProductButton_Click(object sender, EventArgs e)
        {
            using (var _db = new ApplicationDbContext())
            {
                int productId = Convert.ToInt16(DropDownRemoveProduct.SelectedValue);
                var myItem = (from c in _db.Products where c.ProductID == productId select c).FirstOrDefault();
                if (myItem != null)
                {
                    _db.Products.Remove(myItem);
                    _db.SaveChanges();

                    // Reload the page.
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?ProductAction=remove");
                }
                else
                {
                    LabelRemoveStatus.Text = "Unable to locate product.";
                }
            }
        }

        protected void UpdateProductButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    var ID = DropDownRemoveProduct.SelectedIndex + 1;
                    if (db.Products.Any(p => p.ProductID == ID))
                    {
                        var updatedProduct = new Product { ProductID = ID };
                        updateProduct.ProductName = UpdateNameTextBox.Text;
                        updateProduct.Description = UpdateDescriptionTextBox.Text;
                        updateProduct.UnitPrice = Convert.ToDouble(UpdatePriceTextBox.Text);
                        updateProduct.CategoryID = UpdateCategoryDropDownList.SelectedIndex + 1;
                        db.Entry<Product>(updateProduct).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
        }

        protected void DropDownRemoveProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var db = new ApplicationDbContext())
            {
                this.updateProduct = db.Products.Where(p => p.ProductID == DropDownRemoveProduct.SelectedIndex+1).FirstOrDefault();
                if (updateProduct != null)
                {
                    UpdateNameTextBox.Text = updateProduct.ProductName;
                    UpdateDescriptionTextBox.Text = updateProduct.Description;
                    UpdatePriceTextBox.Text = updateProduct.UnitPrice.ToString();
                    UpdateCategoryDropDownList.SelectedIndex = Convert.ToInt16(updateProduct.CategoryID) - 1;
                }
            }
        }
    }
}