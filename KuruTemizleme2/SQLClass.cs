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

        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["KuruTemizleme2.Properties.Settings.KurudbConnectionString"].ToString());

        public string fiyat(string urunadi, string hizmet)
        {
            SqlParameter urunad = new SqlParameter("@URUN", SqlDbType.NVarChar);
            SqlParameter hizme = new SqlParameter("@HIZMET", SqlDbType.NVarChar);
            SqlCommand isim = new SqlCommand();
            isim.CommandType = CommandType.StoredProcedure;
            isim.Connection = myConnection;
            isim.CommandText = "sp_fiyat_Getir";
            myConnection.Open();
            urunad.Value = urunadi;
            hizme.Value = hizmet;
            isim.Parameters.Add(urunadi);
            isim.Parameters.Add(hizmet);
            string result = isim.ExecuteScalar().ToString();
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
        public int columnsil(string column)
        {   SqlParameter urunad = new SqlParameter("@ISIM", SqlDbType.NVarChar,100);
            SqlCommand columnsil = new SqlCommand("sp_sutun_sil");
            columnsil.Parameters.Clear();
            columnsil.CommandType = CommandType.StoredProcedure;
            columnsil.Connection = myConnection;
            myConnection.Open();
            SqlParameter retval = columnsil.Parameters.Add("@SONUC", SqlDbType.VarChar,100);
            columnsil.Parameters.Add(urunad);
            retval.Direction = ParameterDirection.Output;
            urunad.Value = column;


            columnsil.ExecuteNonQuery();
            myConnection.Close();

            return Convert.ToInt32(columnsil.Parameters["@SONUC"].Value);


        }
        public int columnekle (string column)
        {
            SqlCommand columnekle = new SqlCommand("sp_sutun_ekle");
            columnekle.Parameters.Clear();
            columnekle.CommandType = CommandType.StoredProcedure;
            columnekle.Connection = myConnection;
            SqlParameter urunad = new SqlParameter("@ISIM", SqlDbType.NVarChar);
            myConnection.Open();
            urunad.Value = column;
            columnekle.Parameters.Add(urunad);
            int affectedrows = Convert.ToInt16( columnekle.ExecuteNonQuery());
            myConnection.Close();
            return affectedrows;
        }
    }
}