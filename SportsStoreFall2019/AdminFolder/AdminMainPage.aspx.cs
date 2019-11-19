using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsStoreFall2019.AdminFolder
{
    public partial class AdminMainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddProduct_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminFolder/AddProduct.aspx");
        }
    }
}