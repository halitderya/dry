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
        SqlDataAdapter da = new SqlDataAdapter(); //Datatable and dataset made public for update to DB
        DataSet ds = new DataSet(); //Datatable and dataset made public for update to DB

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


 //       List<SqlParameter> prm = new List<SqlParameter>()
 //{

 //};






        MetroButton mb = new MetroButton();
        OpenFileDialog fd = new OpenFileDialog();
        



        public Fiyat()
        {
            InitializeComponent();
        }

        private void Kaydet(object sender, EventArgs e)
        {

            try 
            {
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(da); // created a commandbuilder work with dataadapter "da"
                cmdBuilder.GetUpdateCommand();
                da.Update(ds); // ds was filled by db thru dgv
               
            }

                catch(Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, "An error occured while updating price list. Detailed information= " +  ex.Message);
            }


     








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



        private void tabloyugetir() // triggered by load event. Fills datagridview


        {

            MyConnection.Open();
            param.Value = 0;
            da.SelectCommand=isim;
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
            if (dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].GetType() == typeof(DataGridViewImageCell)) //checks is clicked cell imagecell
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.Filter = "All Supported File Types | *.jpg; *.png; *.tiff ";


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


                    if (Convert.ToString(selectedRow.Cells["urunadi"].Value).Length>0) // check is row empty or not
                    {
                        dgv.Rows[e.RowIndex].Selected = true;
                        rowIndex = e.RowIndex;
                        contextMenuStrip1.Show(this.dgv, e.Location); //brings menustrip to current cursor location
                        contextMenuStrip1.Show(Cursor.Position); //brings menustrip to current cursor location
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
                        before = sqlclass.rowcountfunc(); //finding rowcount from sqlclass before delete


                        foreach (DataGridViewRow row in dgv.SelectedRows)
                        {
                            int a = Convert.ToInt16( dgv.Rows[row.Index].Cells[1].Value);//finding id number selected row each 
                            sqlclass.deleterow(a); // removes selected row in DB
                            dgv.Rows.RemoveAt(row.Index); //removes selected row in DGV only.
                           




                        }

                        after = sqlclass.rowcountfunc();
                        if (MyConnection.State == ConnectionState.Open)
                        { MyConnection.Close(); } //finding rowcount from sqlclass after delete

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
                    ds.Clear();
                    dgv.Update();
                    dgv.Refresh();
                    tabloyugetir();


                }
            }
            else if (confirmdelete==DialogResult.No)
            {

            }
       
        }
    }
}
