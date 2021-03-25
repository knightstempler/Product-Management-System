using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Product_Management_System.BL
{
    class CLS_COSTOMERS
    {
        // INSERT DATA TO DATABASE
        public void ADD_COSTOMERS(string First_Name, string Last_Name, string Tel, string Email,  byte[] Picture)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[5];

            param[0] = new SqlParameter("@First_Name", SqlDbType.VarChar,50);
            param[0].Value = First_Name;

            param[1] = new SqlParameter("@Last_Name", SqlDbType.VarChar, 50);
            param[1].Value = Last_Name;

            param[2] = new SqlParameter("@Tel", SqlDbType.NChar, 20);
            param[2].Value = Tel;

            param[3] = new SqlParameter("@Email", SqlDbType.VarChar,50);
            param[3].Value = Email;

            param[4] = new SqlParameter("@Picture", SqlDbType.Image);
            param[4].Value = Picture;

            DAL.ExecuteCommand("ADD_COSTOMERS ", param);
        }

        public DataTable GET_ALL_CUSTOMERES()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("GET_ALL_CUSTOMERES", null);
            DAL.Close();
            return Dt;
        }

        public DataTable SEARCH_CUSTOMER(string criterion)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();

            DataTable Dt = new DataTable();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@criterion", SqlDbType.VarChar, 50);

            param[0].Value = criterion;

            Dt = DAL.SelectData("SEARCH_CUSTOMER", param);

            DAL.Close();

            return Dt;

        }

        public void EDIT_COSTOMERS(string First_Name, string Last_Name, string Tel, string Email, byte[] Picture,int ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[6];

            param[0] = new SqlParameter("@First_Name", SqlDbType.VarChar, 50);
            param[0].Value = First_Name;

            param[1] = new SqlParameter("@Last_Name", SqlDbType.VarChar, 50);
            param[1].Value = Last_Name;

            param[2] = new SqlParameter("@Tel", SqlDbType.NChar, 20);
            param[2].Value = Tel;

            param[3] = new SqlParameter("@Email", SqlDbType.VarChar, 50);
            param[3].Value = Email;

            param[4] = new SqlParameter("@Picture", SqlDbType.Image);
            param[4].Value = Picture;

            param[5] = new SqlParameter("@ID", SqlDbType.Int);
            param[5].Value = ID;

            DAL.ExecuteCommand("EDIT_COSTOMERS ", param);
        }

        public void DELETE_CUSTOMER(int ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;
            DAL.ExecuteCommand("DELETE_CUSTOMER ", param);
        }


    }
}
