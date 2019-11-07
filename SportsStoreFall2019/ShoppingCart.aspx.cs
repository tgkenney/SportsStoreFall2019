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
            if(!IsPostBack)
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

                decimal amount = ShoppingCartAccess.GetCartTotal();
                cartTotal.Text = String.Format("{0:c}", amount);

                UpdateButton.Enabled = true;
            }
            else
            {
                titleLabel.Text = "There are no items in your cart: ";
                grid.Visible = false;
                cartTotal.Text = String.Format("{0:c}", 0);
                UpdateButton.Enabled = false;
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            // Variables
            int rowsCount = grid.Rows.Count;
            string productid;
            int newQty;
            GridViewRow gridRow;
            TextBox editQtyBox;
            bool success = true;

            for (int i = 0; i < rowsCount; i++)
            {
                productid = grid.DataKeys[i].Value.ToString();
                gridRow = grid.Rows[i];
                editQtyBox = (TextBox)gridRow.FindControl("editQuantity");

                if(Int32.TryParse(editQtyBox.Text, out newQty))
                {
                    success = success && ShoppingCartAccess.UpdateCartItems(productid, newQty);
                }
                else
                {
                    success = false;
                }

                statusLabel.Text = success ? "Quantity updated" : "An error occured while updating quantity";
                PopulateControls();
            }
        }
    }
}