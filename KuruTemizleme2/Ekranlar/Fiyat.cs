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
        SqlParameter uptparam1 = new SqlParameter("@product", SqlDbType.NVarChar);
        SqlParameter uptparam2 = new SqlParameter("@group", SqlDbType.NVarChar);
        SqlParameter uptparam3 = new SqlParameter("@wet", SqlDbType.Int);
        SqlParameter uptparam4 = new SqlParameter("@dry", SqlDbType.Int);
        SqlParameter uptparam5 = new SqlParameter("@iron", SqlDbType.Int);
        SqlParameter uptparam6 = new SqlParameter("@icon", SqlDbType.Image);
        private int rowIndex = 0;
        int before, after; //for finding deleted row count


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
                uptparam1.Value = dgv.Rows[h].Cells["product_name"].Value.ToString();
                uptparam2.Value = dgv.Rows[h].Cells["product_type"].Value.ToString();
                uptparam3.Value = dgv.Rows[h].Cells["wet_cleaning"].Value;
                uptparam4.Value = dgv.Rows[h].Cells["dry_cleaning"].Value;
                uptparam5.Value = dgv.Rows[h].Cells["ironing"].Value;
                uptparam6.Value = dgv.Rows[h].Cells["icon"].Value;
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


            
        }


        private void dgv_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e) 
        {

            if (e.Button == MouseButtons.Right)
            {
                if (dgv.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dgv.SelectedCells[0].RowIndex;

                    DataGridViewRow selectedRow = dgv.Rows[selectedrowindex];


                    if (Convert.ToString(selectedRow.Cells["urunadi"].Value).Length>0) // check if row empty or not
                    {
                        dgv.Rows[e.RowIndex].Selected = true;
                        rowIndex = e.RowIndex;
                        contextMenuStrip1.Show(this.dgv, e.Location);
                        contextMenuStrip1.Show(Cursor.Position);
                    }
                    
                }

                
            }
  
        }
        



        private void removeRowToolStripMenuItem_Click(object sender, EventArgs e)
        {

           DialogResult confirmdelete= MetroFramework.MetroMessageBox.Show(this, dgv.SelectedRows.Count.ToString() + " Row(s) will be removed. Are you sure to proceed?", "Confirm Erase?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

            if (confirmdelete==DialogResult.Yes)
            {
                try
                {

                    


                    if (!this.dgv.Rows[this.rowIndex].IsNewRow)
                    {
                        if (MyConnection.State == ConnectionState.Closed)
                        { MyConnection.Open(); }
                        before = sqlclass.rowcountfunc(); //finding rowcount before delete


                        foreach (DataGridViewRow row in dgv.SelectedRows)
                        {
                            int a = Convert.ToInt16( dgv.Rows[row.Index].Cells[1].Value);
                            sqlclass.deleterow(a);
                            dgv.Rows.RemoveAt(row.Index);
                        }

                        after = sqlclass.rowcountfunc();
                        if (MyConnection.State == ConnectionState.Open)
                        { MyConnection.Close(); }

                    }
                    else {  }
                }

                catch(Exception ex)
                {
                    MetroFramework.MetroMessageBox.Show(this,"An error occured when trying remove rows. Contact your software supplier. Detailed information: "+ex.Message.ToString(),"Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                finally
                {
                    MetroFramework.MetroMessageBox.Show(this,(before-after).ToString()+ " Row(s) removed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyConnection.Close();


                }
            }
            else if (confirmdelete==DialogResult.No)
            {

            }
       
        }
    }
}
