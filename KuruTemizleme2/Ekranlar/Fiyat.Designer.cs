namespace KuruTemizleme2.Ekranlar
{
    partial class Fiyat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urunadi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.icon = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.ColumnCount = 2;
            this.panel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel2.Location = new System.Drawing.Point(8, 63);
            this.panel2.Name = "panel2";
            this.panel2.RowCount = 2;
            this.panel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel2.Size = new System.Drawing.Size(0, 0);
            this.panel2.TabIndex = 0;
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.urunadi,
            this.grup,
            this.Column4,
            this.icon});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgv.Location = new System.Drawing.Point(20, 60);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(703, 150);
            this.dgv.TabIndex = 1;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(629, 31);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(451, 31);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(133, 23);
            this.metroButton1.TabIndex = 4;
            this.metroButton1.Text = "Hizmet Ekleme / Silme";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "id";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // urunadi
            // 
            this.urunadi.DataPropertyName = "product_name";
            this.urunadi.HeaderText = "Ürün Adı";
            this.urunadi.Name = "urunadi";
            // 
            // grup
            // 
            this.grup.DataPropertyName = "product_type";
            this.grup.HeaderText = "Grup";
            this.grup.Name = "grup";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Ekle";
            this.Column4.Name = "Column4";
            this.Column4.Text = "Gözat...";
            this.Column4.Visible = false;
            // 
            // icon
            // 
            this.icon.DataPropertyName = "icon";
            this.icon.HeaderText = "Simge";
            this.icon.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.icon.Name = "icon";
            // 
            // Fiyat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 653);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.panel2);
            this.Name = "Fiyat";
            this.Text = "Ürün ve Hizmet Fiyatlarını Düzenleme...";
            this.Load += new System.EventHandler(this.Fiyat_Load);
            this.SizeChanged += new System.EventHandler(this.Fiyat_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panel2;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button button2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn urunadi;
        private System.Windows.Forms.DataGridViewTextBoxColumn grup;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
        private System.Windows.Forms.DataGridViewImageColumn icon;
    }
}