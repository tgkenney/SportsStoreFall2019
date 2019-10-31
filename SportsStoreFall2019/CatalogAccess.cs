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
    public class CatalogAccess // Utility class that allows us to connect to the database
    {
        public static DataTable GetAllProductsInDept(string departmentID)
        {
            //create a connection string
            string connString = ConfigurationManager.ConnectionStrings["SportsStoreConn"].ConnectionString;

            //create a connection
            SqlConnection conn = new SqlConnection(connString);

            //create a command
            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "spGetProductsOnDeptPromoByDeptID";

            //Add the @deptid parameter to the command object
            SqlParameter param = new SqlParameter("@deptid", departmentID);
            param.DbType = DbType.Int32;
            cmd.Parameters.Add(param);

            //add the @desclength parameter to the command object
            SqlParameter param2 = new SqlParameter("@desclength", 60);
            param.DbType = DbType.Int32;
            cmd.Parameters.Add(param2);

            //open the connection, run the command and close the connection

            DataTable table = new DataTable();

            try
            {
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                table.Load(reader);
                reader.Close();
            }
            catch(Exception ex)
            {
                //print out the expections
                Debug.Write("\n\n\n\n" + ex + "\n\n\n");
            }
            finally
            {
                cmd.Connection.Close();
            }

            return table;
        }
        public static Product GetProductDetails(string prodID)
        {
            string connString = ConfigurationManager.ConnectionStrings["SportsStoreConn"].ConnectionString;

            SqlConnection conn = new SqlConnection(connString);

            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "spGetProductByID";

            SqlParameter param = new SqlParameter("@prodID", prodID);
            param.DbType = DbType.Int32; //defining the datatype
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

        public static DataTable GetAllDepartments()
        {
            string connString = ConfigurationManager.ConnectionStrings["SportsStoreConn"].ConnectionString;

            SqlConnection conn = new SqlConnection(connString);

            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "spGetDepartments";

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

        public static DataTable GetCategoriesInDepartment(string departmentID)
        {
            string connString = ConfigurationManager.ConnectionStrings["SportsStoreConn"].ConnectionString;

            SqlConnection conn = new SqlConnection(connString);

            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "spGetCategoriesInDepartment";

            SqlParameter param = new SqlParameter("@deptID", departmentID);
            param.DbType = DbType.Int32; //defining the datatype
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
    }
}