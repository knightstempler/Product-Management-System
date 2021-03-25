using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Product_Management_System.BL
{
    class CLS_PRODCUT
    {
        public DataTable GET_ALL_CATEGORES()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("GET_ALL_CATEGORES", null);
            DAL.Close();
            return Dt;
        }

        // INSERT DATA TO DATABASE
        public void ADD_PRODUCT(int ID_CAT, string ID_PRODUCT, string LABLE_PRODUCT, int QTE, string PRICE, byte[] img)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[6];

            param[0] = new SqlParameter("@ID_CAT", SqlDbType.Int);
            param[0].Value = ID_CAT;

            param[1] = new SqlParameter("@ID_PRODUCT", SqlDbType.VarChar, 50);
            param[1].Value = ID_PRODUCT;

            param[2] = new SqlParameter("@LABLE_PRODUCT", SqlDbType.VarChar, 50);
            param[2].Value = LABLE_PRODUCT;

            param[3] = new SqlParameter("@QTE", SqlDbType.Int);
            param[3].Value = QTE;

            param[4] = new SqlParameter("@PRICE", SqlDbType.VarChar, 50);
            param[4].Value = PRICE;

            param[5] = new SqlParameter("@IMAGE", SqlDbType.Image);
            param[5].Value = img;

            DAL.ExecuteCommand("ADD_PRODUCT", param);
        }

        public DataTable VerifyProductID(string ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;
            Dt = DAL.SelectData("VerifyProductID", param);
            DAL.Close();
            return Dt;
        }



        public DataTable GET_ALL_PRODUCTS()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("GET_ALL_PRODUCTS", null);
            DAL.Close();
            return Dt;
        }

        public DataTable SearchProduct(string ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;
            Dt = DAL.SelectData("SearchProduct", param);
            DAL.Close();
            return Dt;
        }

        public void DeleteProduct(string ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.VarChar,50);
            param[0].Value = ID;
            DAL.ExecuteCommand("DeleteProduct", param);
        }

        public DataTable GET_IMAGE_PRODUCT(string ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;
            Dt = DAL.SelectData("GET_IMAGE_PRODUCT", param);
            DAL.Close();
            return Dt;
        }

        public void UPDATE_PRODUCT(int ID_CAT, string ID_PRODUCT, string LABLE_PRODUCT, int QTE, string PRICE, byte[] img)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[6];

            param[0] = new SqlParameter("@ID_CAT", SqlDbType.Int);
            param[0].Value = ID_CAT;

            param[1] = new SqlParameter("@ID_PRODUCT", SqlDbType.VarChar, 50);
            param[1].Value = ID_PRODUCT;

            param[2] = new SqlParameter("@LABLE_PRODUCT", SqlDbType.VarChar, 50);
            param[2].Value = LABLE_PRODUCT;

            param[3] = new SqlParameter("@QTE", SqlDbType.Int);
            param[3].Value = QTE;

            param[4] = new SqlParameter("@PRICE", SqlDbType.VarChar, 50);
            param[4].Value = PRICE;

            param[5] = new SqlParameter("@IMAGE", SqlDbType.Image);
            param[5].Value = img;

            DAL.ExecuteCommand("UPDATE_PRODUCT", param);
        }

    }

}
