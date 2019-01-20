using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms3.Models;
using WebForms3.Models.ViewModels;

namespace WebForms3.Admin
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ImagePath = this.getImagePath();
            Page.DataBind();
        }
        public string ImagePath; 
        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<ProductsWithCategoriesViewModel> productsGrid_GetData()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            
            IQueryable<ProductsWithCategoriesViewModel> query =
                from p in db.Products
                join c in db.Categories
                on p.CategoryID equals c.CategoryID
                select new ProductsWithCategoriesViewModel
                {
                    ProductID = p.ProductID,
                    Description = p.Description,
                    ImagePath = "~/Catalog/Images/"+p.ImagePath,
                    ProductName = p.ProductName,
                    UnitPrice=p.UnitPrice

                };
            return query;
        }
        public string getImagePath()
        {
            var data = productsGrid_GetData();
            if (data != null)
            {
                var item = data.SingleOrDefault(p=>p.ProductID==1);
                return item.ImagePath;
            } else { return "Oshit"; }
        }
    }
}