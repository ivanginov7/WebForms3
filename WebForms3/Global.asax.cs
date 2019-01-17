using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using WebForms3.Logic;
using WebForms3.Models;

namespace WebForms3
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            // Initialize the product database.
            Database.SetInitializer(new DbInitializer());
            //create custom role and user
            RoleActions roleActioons = new RoleActions();
            roleActioons.AddUserAndRole();
        }
    }
}