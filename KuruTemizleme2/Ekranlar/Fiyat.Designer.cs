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
            this.components = new System.ComponentModel.Container();
            this.panel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urunadi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wet_cleaning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dry_cleaning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ironing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.icon = new System.Windows.Forms.DataGridViewImageColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
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
            this.product_type,
            this.urunadi,
            this.wet_cleaning,
            this.dry_cleaning,
            this.ironing,
            this.icon});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgv.Location = new System.Drawing.Point(20, 60);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 60;
            this.dgv.Size = new System.Drawing.Size(703, 150);
            this.dgv.TabIndex = 1;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            this.dgv.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_CellMouseUp);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "id";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // product_type
            // 
            this.product_type.DataPropertyName = "product_type";
            this.product_type.HeaderText = "Service Type";
            this.product_type.Name = "product_type";
            // 
            // urunadi
            // 
            this.urunadi.DataPropertyName = "product_name";
            this.urunadi.HeaderText = "Service Name";
            this.urunadi.Name = "urunadi";
            // 
            // wet_cleaning
            // 
            this.wet_cleaning.DataPropertyName = "wet_cleaning";
            this.wet_cleaning.HeaderText = "Washing";
            this.wet_cleaning.Name = "wet_cleaning";
            // 
            // dry_cleaning
            // 
            this.dry_cleaning.DataPropertyName = "dry_cleaning";
            this.dry_cleaning.HeaderText = "Dry Cleaning";
            this.dry_cleaning.Name = "dry_cleaning";
            // 
            // ironing
            // 
            this.ironing.DataPropertyName = "ironing";
            this.ironing.HeaderText = "Ironing";
            this.ironing.Name = "ironing";
            // 
            // icon
            // 
            this.icon.DataPropertyName = "icon";
            this.icon.HeaderText = "Icon";
            this.icon.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.icon.Name = "icon";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(629, 31);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "RowCount()";
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeRowToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(157, 26);
            // 
            // removeRowToolStripMenuItem
            // 
            this.removeRowToolStripMenuItem.Name = "removeRowToolStripMenuItem";
            this.removeRowToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.removeRowToolStripMenuItem.Text = "Remove Row(s)";
            this.removeRowToolStripMenuItem.Click += new System.EventHandler(this.removeRowToolStripMenuItem_Click);
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
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panel2;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button button2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removeRowToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn urunadi;
        private System.Windows.Forms.DataGridViewTextBoxColumn wet_cleaning;
        private System.Windows.Forms.DataGridViewTextBoxColumn dry_cleaning;
        private System.Windows.Forms.DataGridViewTextBoxColumn ironing;
        private System.Windows.Forms.DataGridViewImageColumn icon;
    }
}