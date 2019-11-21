using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsStoreFall2019.AdminFolder
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddProductButton_OnClick(object sender, EventArgs e)
        {
            var categoryID = int.Parse(ddlCategory.SelectedValue);
            var productName = this.productName.Text;
            var productDescription = this.productDescription.Text;
            var productPrice = decimal.Parse(this.productPrice.Text);
            var imageName = imageUpload.FileName;

            // Create a connection string
            string connString = ConfigurationManager.ConnectionStrings["SportsStoreConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);

            // Create a command
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spAddProduct";


            // Add parameters
            SqlParameter param = new SqlParameter("@name", productName);
            param.DbType = DbType.String;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@desc", productDescription);
            param.DbType = DbType.String;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@price", productPrice);
            param.DbType = DbType.Currency;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@image", imageName);
            param.DbType = DbType.String;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@categoryID", categoryID);
            param.DbType = DbType.Int32;
            cmd.Parameters.Add(param);

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                if (imageUpload.HasFile)
                {
                    imageUpload.PostedFile.SaveAs(Server.MapPath("~/Images/") + imageUpload.PostedFile.FileName);
                }
            }
            catch (Exception ex)
            {

                Debug.Write("\n\n\n\n" + ex + "\n\n\n");
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
    }
}