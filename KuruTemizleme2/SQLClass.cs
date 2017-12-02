using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;
using System.Data;

namespace KuruTemizleme2
{
    class SQLClass
    {
        SqlCommand cbisim = new SqlCommand("sp_belirli_sutun_getir");
        SqlCommand removerow = new SqlCommand("sp_remove_row");
        SqlCommandBuilder cmdbl;

        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["KuruTemizleme2.Properties.Settings.KurudbConnectionString"].ToString());

        public int  getprice(string urunadi, string hizmet)
        {
            SqlParameter urunad = new SqlParameter("@URUN", SqlDbType.NVarChar);
            SqlParameter hizme = new SqlParameter("@HIZMET", SqlDbType.NVarChar);
            SqlCommand isim = new SqlCommand();
            isim.CommandType = CommandType.StoredProcedure;
            isim.Connection = myConnection;
            isim.CommandText = "sp_get_price";
            myConnection.Open();
            urunad.Value = urunadi;
            hizme.Value = hizmet;
            isim.Parameters.Add(urunad);
            isim.Parameters.Add(hizme);
            int result = Convert.ToInt16(isim.ExecuteScalar());
            return result;
        }
        public int hizmetsayisi()
            {
            SqlCommand sayicmd = new SqlCommand("sp_sutunsayisi_getir");
            sayicmd.CommandType = CommandType.StoredProcedure;
            sayicmd.Connection = myConnection;
            myConnection.Open();
            int result = Convert.ToInt32(sayicmd.ExecuteScalar());
            myConnection.Close();
            return result;




        }
        public string cbismi(int sira)
        {
            cbisim.Parameters.Clear();
            cbisim.CommandType = CommandType.StoredProcedure;
            cbisim.Connection = myConnection;

            SqlParameter urunad = new SqlParameter("@SIRA", SqlDbType.Int);
            myConnection.Open();
            urunad.Value = sira+1;
            cbisim.Parameters.Add(urunad);
            string ismi = cbisim.ExecuteScalar().ToString();
            myConnection.Close();
            return ismi.ToString();

        }
        private void sendchanges()
        {
            cmdbl = new SqlCommandBuilder();
            
               
        }
      
        public void deleterow(int rowid) // deletes row when parameters met
        {
            if (myConnection.State == ConnectionState.Closed)
            { myConnection.Open(); }
            removerow.Parameters.Clear();
           removerow.CommandType = CommandType.StoredProcedure;
            removerow.Connection = myConnection;
            SqlParameter rownumber = new SqlParameter("@rownumber", SqlDbType.Int); //row to be erased
              rownumber.Value = rowid;
              removerow.Parameters.Add(rownumber);

            removerow.ExecuteNonQuery();
            if (myConnection.State == ConnectionState.Open)
            { myConnection.Close(); }


        }
        public int rowcountfunc() // counts row count when needed and returns to i 
        {
            if (myConnection.State == ConnectionState.Closed)
            { myConnection.Open(); }
            SqlCommand countrow = new SqlCommand("countrow");
            countrow.CommandType = CommandType.StoredProcedure;
            countrow.Connection = myConnection;
            Int32 i = (Int32)countrow.ExecuteScalar();
            if (myConnection.State==ConnectionState.Open)
            { myConnection.Close(); }
            return i;
        }
        public int columnekle (string column) //unusable
        {
            SqlCommand columnekle = new SqlCommand("sp_column_ekle");
            columnekle.Parameters.Clear();
            columnekle.CommandType = CommandType.StoredProcedure;
            columnekle.Connection = myConnection;
            SqlParameter urunad = new SqlParameter("@SERVICE", SqlDbType.NVarChar);


            if (myConnection.State == ConnectionState.Closed)
            { myConnection.Open(); }


            urunad.Value = column;
            columnekle.Parameters.Add(urunad);
            int affectedrows = Convert.ToInt16( columnekle.ExecuteNonQuery());


            if (myConnection.State == ConnectionState.Open)
            { myConnection.Close(); }
            return affectedrows;
        }
       
        public int columnsil (string column)
        {
            SqlCommand columnsil = new SqlCommand("sp_column_sil");
            columnsil.Parameters.Clear();
            columnsil.CommandType = CommandType.StoredProcedure;
            columnsil.Connection = myConnection;
            SqlParameter columnturn = new SqlParameter("@SERVICE", SqlDbType.NVarChar);


            if(myConnection.State==ConnectionState.Closed)
            { myConnection.Open();}


            columnturn.Value = column;
            columnsil.Parameters.Add(columnturn);
            int affectedcolumn = Convert.ToInt16(columnsil.ExecuteNonQuery());


            if(myConnection.State==ConnectionState.Open)
            { myConnection.Close(); }
            return affectedcolumn;
        }
    }
}