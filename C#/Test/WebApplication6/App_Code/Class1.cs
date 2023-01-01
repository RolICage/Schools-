using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication6.App_Code
{
    public class Class1
    {
        static private SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security = True");
        static private SqlCommand cmd = new SqlCommand();

        SqlDataAdapter adapter = new SqlDataAdapter();


        static private DataTable SelectData(string str)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();

            cmd.CommandText = str;
            cmd.Connection = con;

            da.SelectCommand = cmd;
            try
            {
                con.Open();
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
        }

        static public DataTable getall()
        {
            string qury = "SELECT * from Students";
            return SelectData(qury);
        }

    }
}