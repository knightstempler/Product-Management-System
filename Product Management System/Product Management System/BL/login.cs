using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Product_Management_System.BL
{
    class login
    {
        public DataTable LOGIN(string ID, string PWD)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;

            param[1] = new SqlParameter("@PWD", SqlDbType.VarChar, 50);
            param[1].Value = PWD;


            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("SP_LOGIN", param);
            DAL.Close();
            return Dt;
        }

        public void ADD_USER(string ID, string PWD, string USER_TYPE, string FullName)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;

            param[1] = new SqlParameter("@PWD", SqlDbType.VarChar, 50);
            param[1].Value = PWD;

            param[2] = new SqlParameter("@USER_TYPE", SqlDbType.VarChar, 50);
            param[2].Value = USER_TYPE;

            param[3] = new SqlParameter("@FullName", SqlDbType.VarChar, 50);
            param[3].Value = FullName;

            DAL.ExecuteCommand("ADD_USER ", param);
        }

        public void EDIT_USER(string ID, string PWD, string USER_TYPE, string FullName)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;

            param[1] = new SqlParameter("@PWD", SqlDbType.VarChar, 50);
            param[1].Value = PWD;

            param[2] = new SqlParameter("@USER_TYPE", SqlDbType.VarChar, 50);
            param[2].Value = USER_TYPE;

            param[3] = new SqlParameter("@FullName", SqlDbType.VarChar, 50);
            param[3].Value = FullName;

            DAL.ExecuteCommand("EDIT_USER ", param);
        }

        public void DELETE_USER(string ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;

            DAL.ExecuteCommand("DELETE_USER ", param);
        }


        public DataTable SEARCH_USERS(string Criterion)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@Criterion", SqlDbType.VarChar, 50);
            param[0].Value = Criterion;

            Dt = DAL.SelectData("SEARCH_USERS", param);
            DAL.Close();
            return Dt;
        }

    }
}
