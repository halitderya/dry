using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using MetroFramework.Controls;


namespace KuruTemizleme2
{
    public partial class GirisEkrani : MetroFramework.Forms.MetroForm
    {
        Image imgkafa = Properties.Resources.manavatar;
        

        public GirisEkrani()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection MyConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["server"].ToString());

        }

        private void metroTile2_Click(object sender, EventArgs e)
        {




        }

        private void metroTile7_Click(object sender, EventArgs e)
        {
            Ekranlar.testekrani fiy = new Ekranlar.testekrani();
            fiy.Show();
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            Ekranlar.Fiyat fiyat = new Ekranlar.Fiyat();
            fiyat.Show();





        }

        private void GirisEkrani_ResizeEnd(object sender, EventArgs e)
        {

        }

        private void GirisEkrani_SizeChanged(object sender, EventArgs e)
        {

            pictureBox1.Image = null;
            //   pictureBox1.Size = new Size(metroPanel1.Size.Width, metroPanel1.Size.Height / 10 * 8);
            //   bmp = new Bitmap(imgkafa, this.metroPanel1.Size.Width, this.metroPanel1.Size.Height/10*8);
            pictureBox1.Image = imgkafa;
        }

        private void metroTile6_Click(object sender, EventArgs e)
        {

            Ekranlar.testekrani yen = new Ekranlar.testekrani();
            yen.Show();


        }

        private void metroTile2_Click_1(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {

        }
    }
}
