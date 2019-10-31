using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsStoreFall2019
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string prodID = Request.QueryString["ProductID"];

            Product pd = CatalogAccess.GetProductDetails(prodID);

            PopulateControls(pd);
        }
        protected void PopulateControls(Product pd)
        {
            nameLabel.Text = pd.Name;
            productImage.ImageUrl = "Images/" + pd.Image;
            descLabel.Text = pd.Description;
            priceLabel.Text = String.Format("{0:C}", pd.Price);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string prodID = Request.QueryString["ProductID"].ToString();

            string cartID;

            HttpContext context = HttpContext.Current;

            if (context.Request.Cookies["SportsStore_CartID"] != null)
            {
                cartID = context.Request.Cookies["SportsStore_CartID"].Value;
            }
            else
            {
                cartID = Guid.NewGuid().ToString();

                HttpCookie cookie = new HttpCookie("SportsStore_CartID", cartID);

                DateTime currentDate = DateTime.Now;
                TimeSpan timeSpan = new TimeSpan(10, 0, 0, 0);
                DateTime expirationDate = currentDate.Add(timeSpan);

                cookie.Expires = expirationDate;

                context.Response.Cookies.Add(cookie);
            }

            ShoppingCartAccess.AddItem(prodID, cartID);
        }
    }
}