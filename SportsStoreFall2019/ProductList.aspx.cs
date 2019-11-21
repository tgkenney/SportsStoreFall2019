using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsStoreFall2019
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateControls();
        }

        protected void PopulateControls()
        {
            string deptID = Request.QueryString["DepartmentID"]; //this statement reads the query string from the URL
            string catID = Request.QueryString["CategoryID"]; //reads the ID of the category that the user clicks

            if (catID != null)
            {
                DataList1.DataSource = CatalogAccess.GetProductsByCategory(catID);

                DataList1.DataBind();
            }
            else if (deptID != null)
            {
                DataList1.DataSource = CatalogAccess.GetAllProductsInDept(deptID);

                DataList1.DataBind();
            }
            else
            {
                deptID = "1";
                DataList1.DataSource = CatalogAccess.GetAllProductsInDept(deptID);

                DataList1.DataBind();
            }

        }
    }
}