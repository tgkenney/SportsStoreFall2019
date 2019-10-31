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

            SqlParameter param = new SqlParameter("@Cartid", cartID);
            param.DbType = DbType.Guid; //defining the datatype
            cmd.Parameters.Add(param); //adds the parameter to the collection of parameters of the command object

            param = new SqlParameter("@Prodid", prodID);
            param.DbType = DbType.Guid; //defining the datatype
            cmd.Parameters.Add(param); //adds the parameter to the collection of parameters of the command object

            param = new SqlParameter("@Attributes", "None");
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