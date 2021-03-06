﻿using System;
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
            //string productAction = Request.QueryString["ProductAction"];
            //if (productAction == "add")
            //{
            //    LabelAddStatus.Text = "Product added!";
            //}

            //if (productAction == "remove")
            //{
            //    LabelRemoveStatus.Text = "Product removed!";
            //}
            if (Session["OutcomeMessage"] != null)
            {
                LabelAddStatus.Text = Convert.ToString(Session["OutcomeMessage"]);
            }
        }

        protected void UpdateProductButton_Click(object sender, EventArgs e)
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
                var ID = Convert.ToInt16(DropDownRemoveProduct.SelectedValue);
                bool addSuccess = false;
                using (var db=new ApplicationDbContext())
                {
                    if (db.Products.Any(p => p.ProductID == ID))
                    {


                        addSuccess = products.AddProduct(UpdateNameTextBox.Text, UpdateDescriptionTextBox.Text,
                        UpdatePriceTextBox.Text, UpdateCategoryDropDownList.SelectedValue, UpdateFileUpload.FileName,ID);

                    }
                    else
                    {
                        addSuccess = products.AddProduct(UpdateNameTextBox.Text, UpdateDescriptionTextBox.Text,
                        UpdatePriceTextBox.Text, UpdateCategoryDropDownList.SelectedValue, UpdateFileUpload.FileName);
                    }
                }
                
                if (addSuccess)
                {
                    // Reload the page.
                    Session["OutcomeMessage"] = ID == 0 ? "Added new product " + UpdateNameTextBox.Text : "Updated product " + UpdateNameTextBox.Text; 
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl /*+ "?ProductAction=add"*/);
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
                    Session["OutcomeMessage"] = "Removed product "+ UpdateNameTextBox.Text;
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl /*+ "?ProductAction=remove"*/);
                }
                else
                {
                    LabelRemoveStatus.Text = "Unable to locate product.";
                }
            }
        }

        

        protected void DropDownRemoveProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var db = new ApplicationDbContext())
            {
                var dropdownValue = Convert.ToInt16(DropDownRemoveProduct.SelectedValue);
                this.updateProduct = db.Products.Where(p => p.ProductID == dropdownValue).FirstOrDefault();
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