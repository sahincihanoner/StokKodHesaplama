namespace StokKodHesaplama.Screens
{
    partial class Calculate
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtAdet = new System.Windows.Forms.TextBox();
            this.txtToplamKargo = new System.Windows.Forms.TextBox();
            this.txtBirimKargo = new System.Windows.Forms.TextBox();
            this.txtKomisyon = new System.Windows.Forms.TextBox();
            this.txtFiyat = new System.Windows.Forms.TextBox();
            this.txtDesi = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblKar = new System.Windows.Forms.Label();
            this.cbStockCode = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMaliyet = new System.Windows.Forms.TextBox();
            this.btnExcel = new System.Windows.Forms.Button();
            this.sahinBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtAdet
            // 
            this.txtAdet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdet.Location = new System.Drawing.Point(159, 68);
            this.txtAdet.Name = "txtAdet";
            this.txtAdet.Size = new System.Drawing.Size(137, 20);
            this.txtAdet.TabIndex = 1;
            this.txtAdet.TextChanged += new System.EventHandler(this.txtAdet_TextChanged);
            // 
            // txtToplamKargo
            // 
            this.txtToplamKargo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtToplamKargo.Location = new System.Drawing.Point(962, 68);
            this.txtToplamKargo.Name = "txtToplamKargo";
            this.txtToplamKargo.Size = new System.Drawing.Size(128, 20);
            this.txtToplamKargo.TabIndex = 3;
            this.txtToplamKargo.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // txtBirimKargo
            // 
            this.txtBirimKargo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBirimKargo.Location = new System.Drawing.Point(781, 68);
            this.txtBirimKargo.Multiline = true;
            this.txtBirimKargo.Name = "txtBirimKargo";
            this.txtBirimKargo.Size = new System.Drawing.Size(134, 20);
            this.txtBirimKargo.TabIndex = 4;
            // 
            // txtKomisyon
            // 
            this.txtKomisyon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKomisyon.Location = new System.Drawing.Point(623, 68);
            this.txtKomisyon.Name = "txtKomisyon";
            this.txtKomisyon.Size = new System.Drawing.Size(124, 20);
            this.txtKomisyon.TabIndex = 5;
            this.txtKomisyon.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // txtFiyat
            // 
            this.txtFiyat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiyat.Location = new System.Drawing.Point(466, 68);
            this.txtFiyat.Name = "txtFiyat";
            this.txtFiyat.Size = new System.Drawing.Size(137, 20);
            this.txtFiyat.TabIndex = 6;
            // 
            // txtDesi
            // 
            this.txtDesi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesi.Location = new System.Drawing.Point(316, 68);
            this.txtDesi.Name = "txtDesi";
            this.txtDesi.Size = new System.Drawing.Size(127, 20);
            this.txtDesi.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(186, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(280, 40);
            this.button1.TabIndex = 8;
            this.button1.Text = "Hesapla";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(48, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Stok Kodu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(211, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Adet";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(371, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Desi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(515, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Fiyat";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(649, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Komisyon";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(791, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "Birim Kargo Ücreti";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(958, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Toplam Kargo Ücreti";
            // 
            // lblKar
            // 
            this.lblKar.AutoSize = true;
            this.lblKar.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKar.Location = new System.Drawing.Point(251, 270);
            this.lblKar.Name = "lblKar";
            this.lblKar.Size = new System.Drawing.Size(139, 42);
            this.lblKar.TabIndex = 20;
            this.lblKar.Text = "label10";
            this.lblKar.Visible = false;
            // 
            // cbStockCode
            // 
            this.cbStockCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbStockCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbStockCode.FormattingEnabled = true;
            this.cbStockCode.Location = new System.Drawing.Point(14, 68);
            this.cbStockCode.Name = "cbStockCode";
            this.cbStockCode.Size = new System.Drawing.Size(121, 21);
            this.cbStockCode.TabIndex = 21;
            this.cbStockCode.SelectedIndexChanged += new System.EventHandler(this.cbStockCode_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(1155, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 16);
            this.label9.TabIndex = 19;
            this.label9.Text = "Maliyet";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // txtMaliyet
            // 
            this.txtMaliyet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaliyet.Location = new System.Drawing.Point(1127, 68);
            this.txtMaliyet.Name = "txtMaliyet";
            this.txtMaliyet.Size = new System.Drawing.Size(129, 20);
            this.txtMaliyet.TabIndex = 17;
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.GreenYellow;
            this.btnExcel.Location = new System.Drawing.Point(671, 160);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(280, 40);
            this.btnExcel.TabIndex = 22;
            this.btnExcel.Text = "Excel\'e Aktar";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // sahinBox
            // 
            this.sahinBox.Location = new System.Drawing.Point(159, 392);
            this.sahinBox.Multiline = true;
            this.sahinBox.Name = "sahinBox";
            this.sahinBox.Size = new System.Drawing.Size(735, 110);
            this.sahinBox.TabIndex = 23;
            this.sahinBox.TextChanged += new System.EventHandler(this.sahinBox_TextChanged);
            // 
            // Calculate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sahinBox);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.cbStockCode);
            this.Controls.Add(this.lblKar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtMaliyet);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtDesi);
            this.Controls.Add(this.txtFiyat);
            this.Controls.Add(this.txtKomisyon);
            this.Controls.Add(this.txtBirimKargo);
            this.Controls.Add(this.txtToplamKargo);
            this.Controls.Add(this.txtAdet);
            this.Name = "Calculate";
            this.Size = new System.Drawing.Size(1311, 762);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtAdet;
        private System.Windows.Forms.TextBox txtToplamKargo;
        private System.Windows.Forms.TextBox txtBirimKargo;
        private System.Windows.Forms.TextBox txtKomisyon;
        private System.Windows.Forms.TextBox txtFiyat;
        private System.Windows.Forms.TextBox txtDesi;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblKar;
        private System.Windows.Forms.ComboBox cbStockCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMaliyet;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.TextBox sahinBox;
    }
}
