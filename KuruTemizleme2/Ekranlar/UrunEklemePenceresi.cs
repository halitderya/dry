﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using MetroFramework.Controls;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuruTemizleme2.Ekranlar
{
    
    public partial class UrunEklemePenceresi : MetroFramework.Forms.MetroForm
    {

        MetroTile mcb;
        string hizmet;
        public int sayi = 0;
        public UrunEklemePenceresi()
        {

            InitializeComponent();
        }

        private void UrunEklemePenceresi_Load(object sender, EventArgs e)
        {

            var sqlclass = new SQLClass();




            tableLayoutPanel1.RowCount = sqlclass.hizmetsayisi();
           // this.tableLayoutPanel1.RowCount = 1;
            RowStyle rs = new RowStyle(SizeType.Percent, (100 / sqlclass.hizmetsayisi()));

            this.tableLayoutPanel1.RowStyles.Add(rs);
            for (int i = 0; i < sqlclass.hizmetsayisi(); i++) //this loop cascading mcb buttons according service value
            {
                  mcb = new MetroTile();
                  mcb.AutoSizeMode = AutoSizeMode.GrowOnly;
                  mcb.TextAlign = ContentAlignment.MiddleCenter;
                  mcb.Click += new System.EventHandler(this.mcb_click);
                  mcb.Dock = DockStyle.Fill;
                  mcb.Text = sqlclass.cbismi(i);
                
                  //   tableLayoutPanel1.Controls.Add(mcb, (i / 3) /3, i / 3);
                  tableLayoutPanel1.Controls.Add(mcb);
                  

            }


        }

        private void mcb_click(object sender, EventArgs e) //by mcb buttons user decides which services are selected 
        {

            try
            {
                var mcb = sender as MetroTile;

                foreach (MetroTile b in this.tableLayoutPanel1.Controls) //tile color dont changes till usecustombackcolor property value is true. 
                {
                    b.UseCustomBackColor = false;
                    this.Refresh();
                }

                mcb.UseCustomBackColor = true;
                mcb.BackColor = Color.Orange;
                hizmet = mcb.Text;

                if (Convert.ToInt32(metroTile1.Text) > 0) metroButton3.Enabled = true;
            }

            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, "An error occured while choose service: "+ex.Message);

            }





        }
        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (sayi > 99)
            { }
            else
            {
                
                sayi++;
                metroTile1.Text = sayi.ToString();
                if (Convert.ToInt32(metroTile1.Text) > 0 && hizmet != null)
                {
                    metroButton3.Enabled = true;
                }
                else
                { metroButton3.Enabled = false; }
            }

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (sayi == 0)
            { }
            else{
                sayi--;
                metroTile1.Text = sayi.ToString();
                if (Convert.ToInt32(metroTile1.Text) > 0 && hizmet != null) { metroButton3.Enabled = true; }
                else
                {
                    metroButton3.Enabled = false;
                }
            }
            
        }



        public void ekran (string urun)
        {
            metroLabel1.Text = urun;

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(metroTile1.Text) > 0)
                {
                    var sqlclass = new SQLClass();
                    int price= sqlclass.getprice(metroLabel1.Text.ToString(), hizmet);
                    var fm = testekrani.MainFormRef;
                    fm.urunekle(metroLabel1.Text, hizmet,Convert.ToInt32(metroTile1.Text),price);
                    fm.dataGridView1.ColumnHeadersVisible = true;
                    fm.TBTutar.Visible = true;
                    fm.metroLabel2.Visible = true;
                    this.Close();
                }
                else { MetroFramework.MetroMessageBox.Show(testekrani.MainFormRef, "Quantity must be selected", "Quantity not selected", MessageBoxButtons.OK, MessageBoxIcon.Information); }

            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, "An Error Occured Details:" + ex.Message);
            }





        }


    }
}
