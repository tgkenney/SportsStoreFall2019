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
            string connString = ConfigurationManager.ConnectionStrings["SportsStoreConn"].ConnectionString;

            SqlConnection conn = new SqlConnection(connString);

            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "spShoppingCartAddItem";

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
    }
}