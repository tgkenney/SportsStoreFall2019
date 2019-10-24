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
    public class CatalogAccess
    {
        public static Product GetProductDetails(string prodID)
        {
            string connString = ConfigurationManager.ConnectionStrings["SportsStoreConn"].ConnectionString;

            // Create a connection
            SqlConnection conn = new SqlConnection(connString);

            // Create a command
            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "spGetProductByID";

            SqlParameter param = new SqlParameter("prodid", prodID);
            param.DbType = DbType.Int32;
            cmd.Parameters.Add(param);

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

            Product pd = new Product();

            if (table.Rows.Count > 0)
            {
                DataRow dr = table.Rows[0];

                pd.ProductID = Convert.ToInt32(prodID);
                pd.Name = dr["Name"].ToString();
                pd.Image = dr["Image"].ToString();
                pd.Description = dr["Description"].ToString();
                pd.Price = Convert.ToDecimal(dr["Price"].ToString());
                pd.PromoDept = Convert.ToBoolean(dr["PromoDept"].ToString());
                pd.PromoFront = Convert.ToBoolean(dr["PromoFront"].ToString());
                pd.Thumbnail = dr["Thumbnail"].ToString();
            }

            return pd;
        }
    }
}