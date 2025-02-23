﻿using System;
using MetroFramework.Controls;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using MetroFramework;

namespace KuruTemizleme2.Ekranlar
{

    public partial class testekrani : MetroFramework.Forms.MetroForm
    {
        public static testekrani MainFormRef { get; private set; }

        MetroTabControl MTC = new MetroTabControl();

        Image ikon;
        public Size sz = new Size();
        double intd;
        public int ColumnCount = Properties.Settings.Default.TilePerPage;
        public int sayisi = 0;
        public int lokasyon = 0;
        public int workheight = 0;
        public int workwidth = 0;
        public int tilesizex = 0;
        public int tilesizey = 0;
        public int tilemarginx = 0;
        public int tilemarginy = 0;

        bool isexist = false;
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["KuruTemizleme2.Properties.Settings.KurudbConnectionString"].ToString());
        public testekrani()
        {

            InitializeComponent();
            MainFormRef = this;

        }
        private void TileDose(int sayisi)
        {
            try
            {
                SqlCommand isim = new SqlCommand();
                isim.CommandType = CommandType.StoredProcedure;
                isim.Connection = myConnection;
                isim.CommandText = "sp_tileadi_getir";
                tilesayisi();
                myConnection.Open();
                DataTable dt = new DataTable();
                dt.Load(isim.ExecuteReader());

                if (myConnection.State == ConnectionState.Closed)
                { myConnection.Open(); }
                for (int i = 0; i < sayisi; i++)
                {
                    intd = Convert.ToDouble(i);
                    intd = Math.Floor(intd / ColumnCount);
                    MetroTile ml = new MetroTile();
                    ml.Size = new Size(tilesizex - (MP.Size.Width / 100), tilesizey - (MP.Size.Width / 100));
                    ml.Text = dt.Rows[i][2].ToString();
                    ml.TileTextFontSize = MetroTileTextSize.Tall;
                    ml.TileTextFontWeight = MetroTileTextWeight.Bold;
                    byte[] data = new byte[0];
                    ml.Name = "tile" + i.ToString();

                    ml.Click += new EventHandler(Ml_Click); //burada icon var mı diye kontrol ediliyor
                    if (dt.Rows[i][6] != DBNull.Value)
                    {
                        MemoryStream ms = new MemoryStream((byte[])(dt.Rows[i][6]));
                        ikon = Image.FromStream(ms);
                        Bitmap bit = new Bitmap(ikon, ml.Size.Width / 2, ml.Size.Width / 2);

                        ml.TileImageAlign = ContentAlignment.TopRight;
                        ml.TileImage = bit;
                        ml.UseTileImage = true;



                    }

                    ml.Location = new Point(((i % ColumnCount) * ml.Size.Width) + ((i % ColumnCount) * (MP.Size.Width / 100)), Convert.ToInt32(intd) * ml.Size.Width + ((Convert.ToInt32(intd)) * (MP.Size.Width / 100)));
                    this.MP.Controls.Add(ml);
                    MP.AutoScroll = true;

                }
                if (myConnection.State == ConnectionState.Open)
                { myConnection.Close(); }
                resize();
            }
            catch (Exception ex) { MetroFramework.MetroMessageBox.Show(this, "An Error Occured= " + ex.Message); }
        }

        private void Ml_Click(object sender, EventArgs e)
        {
            MetroTile tile = sender as MetroTile;
            UrunEklemePenceresi uep = new UrunEklemePenceresi();
            uep.ekran(tile.Text);
            uep.ShowDialog();
        }

        private void tilesayisi()
        {
            SqlCommand numara = new SqlCommand();
            numara.CommandType = CommandType.StoredProcedure;
            numara.CommandText = "sp_tilesayisi_getir";
            numara.Connection = myConnection;
            if (myConnection.State == ConnectionState.Closed)
            { myConnection.Open(); }
            sayisi = Convert.ToInt32(numara.ExecuteScalar()); //burdaki sayi kaç adet hizmet olduğu toplamda

            if (myConnection.State == System.Data.ConnectionState.Open)
            { myConnection.Close(); }
        }
        private void testekrani_Load(object sender, EventArgs e)
        {

            this.dataGridView1.BackgroundColor = this.BackColor;
            this.dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MP.Controls.Clear();
            resize();
            tilesayisi();
            TileDose(sayisi);
            MP.AutoScroll = true;
            metroTile2.Text = "Close";
            this.WindowState = FormWindowState.Maximized;

        }
        private void resize()
        {
            workheight = this.MP.Size.Height;
            workwidth = this.MP.Size.Width;
            tilesizex = (this.workwidth / ColumnCount);
            tilesizey = tilesizex;
        }
        private void testekrani_SizeChanged(object sender, EventArgs e)
        {
            this.MP.Controls.Clear();
            resize();
            tilesayisi();
            TileDose(sayisi);
        }
        private void testekrani_ResizeEnd(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        public void urunekle(string adi, string hizmet, int adet, int fiyat)
        {
            Image img = Properties.Resources.delete_16x16;

            try
            {
                foreach (DataGridViewRow rowy in dataGridView1.Rows)
                {

                    if ((Convert.ToString(rowy.Cells[1].Value) == hizmet) && (Convert.ToString(rowy.Cells[0].Value) == adi))
                    {
                        rowy.Cells[2].Value = Convert.ToInt16(rowy.Cells[2].Value) + adet;
                        rowy.Cells[4].Value = Convert.ToInt16(rowy.Cells[2].Value) * (Convert.ToInt16(rowy.Cells[3].Value));
                        isexist = true;
                    }


                }
                if (isexist ==true)
                {

                    
                    //MessageBox.Show(this, "aynısından bir tane var");

                    isexist =false;
                   



                }
                else
                {
                    this.dataGridView1.Rows.Add(adi, hizmet, adet, fiyat,fiyat*adet ,img);

                }

                if (dataGridView1.RowCount > 0)
                { metroTile2.Text = "Clear"; }


            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "An error occured while adding product" + ex.Message);
            }

        }


        private void updatequantity()
        {
            
              
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].GetType() == typeof(DataGridViewImageCell))
            {
                dataGridView1.Rows.RemoveAt(e.RowIndex);
                if (dataGridView1.Rows.Count==0) { dataGridView1.ColumnHeadersVisible = false; metroTile2.Text = "Close";  }
            }
            

        }
        

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void fiyatyukle (string urun, string hizmet)
        {
            var sqlclass = new SQLClass();
            sqlclass.getprice(urun, hizmet);
            


        }

        private void CloseorClear(object sender, EventArgs e)
        {
          
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {

        }

        private void click_basket(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            { this.Close(); }
            if (dataGridView1.RowCount > 0)
            {
                this.dataGridView1.Rows.Clear();
                dataGridView1.ColumnHeadersVisible = false;
                metroTile2.Text = "Close";

            }
        }
    }
}
