using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SportsStoreFall2019
{
    public class ShoppingCartAccess
    {
        public static void AddItem(string prodID, string cartID)
        {
            // Create a connection string
            string connString = ConfigurationManager.ConnectionStrings["SportsStoreConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);

            // Create a command
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spShoppingCartAddItem";


            // Add parameters
            SqlParameter param = new SqlParameter("@cartID", cartID);
            param.DbType = DbType.String; //defining the datatype
            cmd.Parameters.Add(param); //adds the parameter to the collection of parameters of the command object

            param = new SqlParameter("@productID", prodID);
            param.DbType = DbType.Int32; //defining the datatype
            cmd.Parameters.Add(param); //adds the parameter to the collection of parameters of the command object

            param = new SqlParameter("@attributes", "None");
            param.DbType = DbType.String; //defining the datatype
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
        }

        public static decimal GetCartTotal()
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
            cmd.CommandText = "spShoppingCartGetTotalAmount";

            // Add parameters
            SqlParameter param = new SqlParameter("@cartID", cartID);
            param.DbType = DbType.String; //defining the datatype
            cmd.Parameters.Add(param); //adds the parameter to the collection of parameters of the command object

            decimal cartTotal = 0m;

            try
            {
                cmd.Connection.Open();
                Decimal.TryParse(cmd.ExecuteScalar().ToString(), out cartTotal);
            }
            catch (Exception ex)
            {

                Debug.Write("\n\n\n\n" + ex + "\n\n\n");
            }
            finally
            {
                cmd.Connection.Close();
            }

            return cartTotal;
        }

        public static DataTable GetAllItems()
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
            cmd.CommandText = "spShoppingCartGetItems";

            // Add parameters
            SqlParameter param = new SqlParameter("@cartID", cartID);
            param.DbType = DbType.String; //defining the datatype
            cmd.Parameters.Add(param); //adds the parameter to the collection of parameters of the command object

            DataTable table = new DataTable();

            try
            {
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                table.Load(reader);
                reader.Close();
            }
            catch (Exception ex)
            {

                Debug.Write("\n\n\n\n" + ex + "\n\n\n");
            }
            finally
            {
                cmd.Connection.Close();
            }

            return table;
        }

        public static bool UpdateCartItems(string productID, int newQty)
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
            cmd.CommandText = "spShoppingCartUpdateItem";

            // Add parameters
            SqlParameter param = new SqlParameter("@cartID", cartID);
            param.DbType = DbType.String; //defining the datatype
            cmd.Parameters.Add(param); //adds the parameter to the collection of parameters of the command object

            param = new SqlParameter("@productID", productID);
            param.DbType = DbType.Int32; //defining the datatype
            cmd.Parameters.Add(param); //adds the parameter to the collection of parameters of the command object

            param = new SqlParameter("@quantity", newQty);
            param.DbType = DbType.Int32; //defining the datatype
            cmd.Parameters.Add(param); //adds the parameter to the collection of parameters of the command object

            try
            {
                cmd.Connection.Open();
                return cmd.ExecuteNonQuery() > 0;

            }
            catch (Exception ex)
            {

                Debug.Write("\n\n\n\n" + ex + "\n\n\n");
            }
            finally
            {
                cmd.Connection.Close();
            }

            return false;
        }
    }
}