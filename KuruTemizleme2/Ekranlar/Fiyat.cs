using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using MetroFramework.Controls;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace KuruTemizleme2.Ekranlar
{
    public partial class Fiyat : MetroFramework.Forms.MetroForm
    {
        SutunEkleSil sutuneklesil = new SutunEkleSil();
        SQLClass sqlclass = new SQLClass();
        SqlCommand isim = new SqlCommand();
        SqlCommand upt = new SqlCommand();
        SqlConnection MyConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["KuruTemizleme2.Properties.Settings.KurudbConnectionString"].ConnectionString);
        SqlParameter param = new SqlParameter("@Sira", SqlDbType.Int);
        int rowcount = 0;
        SqlParameter uptparam1 = new SqlParameter("@urun", SqlDbType.NVarChar);
        SqlParameter uptparam2 = new SqlParameter("@grup", SqlDbType.NVarChar);
        SqlParameter uptparam3 = new SqlParameter("@1_1", SqlDbType.Int);
        SqlParameter uptparam4 = new SqlParameter("@1_2", SqlDbType.Int);
        SqlParameter uptparam5 = new SqlParameter("@1_3", SqlDbType.Int);
        SqlParameter uptparam6 = new SqlParameter("@ICON", SqlDbType.Image);


        List<SqlParameter> prm = new List<SqlParameter>()
 {

 };






        MetroButton mb = new MetroButton();
        OpenFileDialog fd = new OpenFileDialog();
        



        public Fiyat()
        {
            InitializeComponent();
        }

        private void Kaydet(object sender, EventArgs e)
        {
            rowcount = dgv.RowCount;
            upt.Parameters.Clear();
            upt.CommandType = CommandType.StoredProcedure;
            upt.Connection = MyConnection;
            upt.CommandText = "sp_tablo_insert_or_update";
            

            upt.Parameters.Add(uptparam1);
            upt.Parameters.Add(uptparam2);
            upt.Parameters.Add(uptparam3);
            upt.Parameters.Add(uptparam4);
            upt.Parameters.Add(uptparam5);
            upt.Parameters.Add(uptparam6);

            if (MyConnection.State == ConnectionState.Closed)
            { MyConnection.Open(); }
            for (int h=0; h<rowcount-1;h++)
            {
                uptparam1.Value = dgv.Rows[h].Cells["urunadi"].Value.ToString();
                uptparam2.Value = dgv.Rows[h].Cells["grup"].Value.ToString();
                uptparam3.Value = dgv.Rows[h].Cells["birbir"].Value;
                uptparam4.Value = dgv.Rows[h].Cells["biriki"].Value;
                uptparam5.Value = dgv.Rows[h].Cells["biruc"].Value;
                uptparam6.Value = dgv.Rows[h].Cells["ikibir"].Value;
                upt.ExecuteNonQuery();

            }


            if (MyConnection.State == ConnectionState.Open)
            { MyConnection.Close(); }









        }
        private void Fiyat_Load(object sender, EventArgs e)
        {
            mb.Text = "Kaydet";
            this.Controls.Add(mb);
            mb.Click += new EventHandler(this.Kaydet);
            isim.CommandType = CommandType.StoredProcedure;
            isim.Connection = MyConnection;
            isim.CommandText = "sp_tablo_getir";
            isim.Parameters.Add(param);
            tabloyugetir();
        }



        private void tabloyugetir()


        {
            MyConnection.Open();
            param.Value = 0;
            SqlDataAdapter da = new SqlDataAdapter(isim);
            var ds = new DataSet();
            da.Fill(ds);
            dgv.DataSource = ds.Tables[0];
            dgv.Dock = DockStyle.Top;
            this.Controls.Add(dgv);
            MyConnection.Close();





        }





        private void button1_Click(object sender, EventArgs e)
        {



        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Fiyat_SizeChanged(object sender, EventArgs e)
        {

            dgv.Size = new System.Drawing.Size(dgv.Size.Width, this.Size.Height - this.Size.Height/100*20);
            mb.Location = new System.Drawing.Point(dgv.Location.X+dgv.Size.Width-mb.Size.Width, dgv.Bottom+dgv.Size.Height/100*3);
            
            //  dgv.RowTemplate.Height =dgv.Height/10;

        }

        private void button2_Click(object sender, EventArgs e)
        {


            MessageBox.Show(dgv.Rows.Count.ToString());



        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].GetType() == typeof(DataGridViewImageCell))
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.Filter = "Tüm Desteklenen Dosya Türleri | *.jpg; *.png; *.tiff ";


                if (opf.ShowDialog() == DialogResult.OK)
                {
                    dgv.Rows[e.RowIndex].Cells["icon"].Value = Image.FromFile(opf.FileName);

                }



            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

            sutuneklesil.Show();
            sqlclass.hizmetsayisi();
            
        }
    }
}
