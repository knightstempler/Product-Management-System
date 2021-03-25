using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Product_Management_System.DAL
{
    class DataAccessLayer
    {
        SqlConnection sqlconection;
        public DataAccessLayer()
        {
            sqlconection = new SqlConnection("Server=.; Database=Product_DB; Integrated Security = True");
        }

        // Method to Open Connection
        public void Open()
        {
            
            if (sqlconection.State != ConnectionState.Open)
            {
                
                sqlconection.Open();

            }
        }

        // Method to Close Connection
        public void Close()
        {
            if (sqlconection.State == ConnectionState.Open)
            {
                
                sqlconection.Close();

            }
        }

        // Method to read Data From Database
        public DataTable SelectData(string storeg_procedure, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = storeg_procedure;
            sqlcmd.Connection = sqlconection;

            if (param != null)
            {
                for (int i = 0; i < param.Length; i++)
                {
                    sqlcmd.Parameters.Add(param[i]);
                }
            }

            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // Method to INSERT,UPDATE,DELETE FROM DATABASE

        public void ExecuteCommand(string storeg_procedure, SqlParameter[] param)
        {

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = storeg_procedure;
            sqlcmd.Connection = sqlconection;

            if (param != null)
            {
                sqlcmd.Parameters.AddRange(param);
            }
            sqlcmd.ExecuteNonQuery();
        }
    }
}
