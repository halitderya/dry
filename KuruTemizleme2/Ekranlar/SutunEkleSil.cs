using System;
using System.Windows.Forms;
using MetroFramework.Controls;
using System.Linq;
using System.Text.RegularExpressions;

namespace KuruTemizleme2.Ekranlar
{
    public partial class SutunEkleSil : MetroFramework.Forms.MetroForm
    {
        MetroTextBox mtb = new MetroTextBox();
        SQLClass sqlclass = new SQLClass();
        MetroFramework.Forms.MetroForm he = new MetroFramework.Forms.MetroForm();


        public SutunEkleSil()
        {
  

            InitializeComponent();

        }

        private void SutunEkleSil_Load(object sender, EventArgs e)
        {



           this.Size = new System.Drawing.Size(System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width / 2, System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height / 2);
           int hizmetsayisi = sqlclass.hizmetsayisi();
           int kolonsayisi=  tablealtpanel.ColumnCount = 4;
            
            


            tablealtpanel.RowCount = sqlclass.hizmetsayisi()/tablealtpanel.ColumnCount;

            this.tablealtpanel.RowStyles.Clear();
            if (hizmetsayisi<kolonsayisi || hizmetsayisi==kolonsayisi)
            {


                hizmetsayisi = kolonsayisi+1;


            }
            for (int i = 0; i<sqlclass.hizmetsayisi()/tablealtpanel.ColumnCount+1;i++)
            {
               
                this.tablealtpanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / (hizmetsayisi / 4)));
            }


            this.tablealtpanel.ColumnStyles.Clear();









            for (int i =0; i<tablealtpanel.ColumnCount;i++)
            {
                this.tablealtpanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            }
            
        
            this.MaximumSize = this.Size;
            
            for (int i = 0; i < sqlclass.hizmetsayisi(); i++)
            {
                MetroCheckBox mcb = new MetroCheckBox();
                mcb.Text = sqlclass.cbismi(i);
           //    mcb, (i / 4) / 4, i / 4
             //   mcb.Dock = DockStyle.Fill;
                tablealtpanel.Controls.Add(mcb);


            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            string targetcolumns="";
            foreach (var checkBox in this.tablealtpanel.Controls.OfType<MetroCheckBox>())
            {



                if (checkBox.CheckState == CheckState.Checked)
                {
                    if(targetcolumns=="")
                    {
                        targetcolumns = checkBox.Text;
                    }
                    else
                    {
                        targetcolumns = targetcolumns + " , " + checkBox.Text;

                    }

                }



            }

          //  MessageBox.Show(this, sqlclass.columnsil(sira).ToString());



        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            MetroLabel mlb = new MetroLabel();
            MetroButton mb = new MetroButton();
            TableLayoutPanel tlp = new TableLayoutPanel();
            tlp.ColumnStyles.Clear();
            tlp.RowStyles.Clear();
            he.Text = "Hizmet Ekle";
            mtb.Dock = DockStyle.Fill;
            mlb.Dock = DockStyle.Fill;
            tlp.SetColumnSpan(mtb, 3);
            tlp.SetColumnSpan(mlb, 2);
            tlp.SetColumnSpan(mb, 5);
            mtb.Size = new System.Drawing.Size(mtb.Size.Width, mlb.Size.Height);
            mtb.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            mtb.Enabled = true;
            mtb.Multiline = false;
            mtb.TextAlign = HorizontalAlignment.Center;
            mlb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            mb.Dock = DockStyle.Fill;
            tlp.Dock = DockStyle.Fill;
            tlp.RowCount = 5;
            tlp.ColumnCount = 6;
            tlp.Controls.Add(mlb, 0, 1);
            tlp.Controls.Add(mtb, 3, 1);
            tlp.Controls.Add(mb, 0, 5);
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            mlb.Text = "Hizmet Adı: ";
            mb.Text = "Ekle";
            he.Resizable = false;
            he.MaximumSize = he.Size;
            he.Controls.Add(tlp);
            tlp.Dock = DockStyle.Fill;
            he.Show();
            mb.Click  += new System.EventHandler(this.mbclick);
            mtb.KeyPress += new KeyPressEventHandler(this.keypress);

        }
        private void keypress(object sender,KeyPressEventArgs e)
        {

           if( e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back))

            {
                e.Handled = true;
            }


        }
        private void mbclick(object sender, EventArgs e)
        {
            if (mtb.Text.Length>1)
            {
                if(sqlclass.columnekle(mtb.Text.ToString())==-1)
                {
                    { MetroFramework.MetroMessageBox.Show(he, mtb.Text.ToString() + " Hizmeti Başarıyla Eklenmiştir."); }
                }
                else { MetroFramework.MetroMessageBox.Show(he, "Ekleme Başarısız!"); }


            }
            else { MetroFramework.MetroMessageBox.Show(he, "Lütfen Bir Hizmet Adı Giriniz."); }

        }


    }
}
