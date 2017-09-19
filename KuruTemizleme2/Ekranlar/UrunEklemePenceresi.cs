using System;
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
        
        public int sayi = 0;
        public UrunEklemePenceresi()
        {

            InitializeComponent();
        }

        private void UrunEklemePenceresi_Load(object sender, EventArgs e)
        {
            var sqlclass = new SQLClass();
            //tableLayoutPanel1.RowCount = sqlclass.hizmetsayisi();
            tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowCount = 1;
           // RowStyle rs = new RowStyle(SizeType.Percent,(100/sqlclass.hizmetsayisi()));
            RowStyle rs = new RowStyle(SizeType.Percent, (100 / 1));

            this.tableLayoutPanel1.RowStyles.Add(rs);
            for (int i=0;i<sqlclass.hizmetsayisi();i++)
            {
                MetroCheckBox mcb = new MetroCheckBox();
                mcb.Text = sqlclass.cbismi(i);
                tableLayoutPanel1.Controls.Add(mcb, (i /4) / 4,i /4);
                
            }
            

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (sayi > 19)
            { }
            else
            {
                
                sayi++;
                metroTile1.Text = sayi.ToString();
            }

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (sayi == 0)
            { }
            else{
                sayi--;
                metroTile1.Text = sayi.ToString();
            }
        }



        public void ekran (string urun)
        {
            metroLabel1.Text = urun;

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {




            if (Convert.ToInt32(metroTile1.Text)>0)
            {
                var fm = testekrani.MainFormRef;
                fm.urunekle(metroLabel1.Text,"Yıkalama", Convert.ToInt32(metroTile1.Text), 1);
                fm.dataGridView1.ColumnHeadersVisible = true;
                fm.TBTutar.Visible = true;
                fm.metroLabel2.Visible = true;
                this.Close();
            }
            else {MetroFramework.MetroMessageBox.Show(testekrani.MainFormRef, "En az bir adet ürün seçmelisiniz","Adet Seçilmedi",MessageBoxButtons.OK,MessageBoxIcon.Information); }


        }


    }
}
