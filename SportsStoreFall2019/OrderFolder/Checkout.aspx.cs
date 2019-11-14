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
using Microsoft.AspNet.Identity;

namespace SportsStoreFall2019.OrderFolder
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void placeOrderButton_Click(object sender, EventArgs e)
        {
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

            // Create a connection string
            string connString = ConfigurationManager.ConnectionStrings["SportsStoreConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);

            // Create a command
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spCreateCustomerOrder";

            // Add parameters
            SqlParameter param = new SqlParameter("@CartID", cartID);
            param.DbType = DbType.String; //defining the datatype
            cmd.Parameters.Add(param); //adds the parameter to the collection of parameters of the command object

            param = new SqlParameter("@custID", User.Identity.GetUserId());
            param.DbType = DbType.String; //defining the datatype
            cmd.Parameters.Add(param); //adds the parameter to the collection of parameters of the command object

            param = new SqlParameter("@orderid", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param); //adds the parameter to the collection of parameters of the command object

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                Debug.Write("\n\n\n\n" + ex + "\n\n\n");
            }
            finally
            {
                cmd.Connection.Close();
            }
            Response.Redirect("~/OrderFolder/OrderPlaced.aspx?OrderId=" + param.Value);
        }
    }
}