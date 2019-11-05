using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsStoreFall2019
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateControls();
        }

        protected void PopulateControls()
        {
            DataTable dt = ShoppingCartAccess.GetAllItems();

            if(dt.Rows.Count > 0)
            {
                titleLabel.Text = "Items in shopping cart: ";
                grid.DataSource = dt;
                grid.DataBind();

                UpdateButton.Enabled = true;
            }
            else
            {
                titleLabel.Text = "There are no items in your cart: ";
                grid.Visible = false;
                UpdateButton.Enabled = false;
            }
        }
    }
}