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
            productImage.ImageUrl = "images/" + pd.Image;
            descLabel.Text = pd.Description;
            priceLabel.Text = String.Format("", pd.Price);
        }
    }
}