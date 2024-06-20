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
            this.button1 = new System.Windows.Forms.Button();
            this.lblKar = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.sahinBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(213, 321);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(280, 40);
            this.button1.TabIndex = 8;
            this.button1.Text = "Hesapla";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblKar
            // 
            this.lblKar.AutoSize = true;
            this.lblKar.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKar.Location = new System.Drawing.Point(564, 475);
            this.lblKar.Name = "lblKar";
            this.lblKar.Size = new System.Drawing.Size(139, 42);
            this.lblKar.TabIndex = 20;
            this.lblKar.Text = "label10";
            this.lblKar.Visible = false;
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.GreenYellow;
            this.btnExcel.Location = new System.Drawing.Point(905, 321);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(280, 40);
            this.btnExcel.TabIndex = 22;
            this.btnExcel.Text = "Excel\'e Aktar";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // sahinBox
            // 
            this.sahinBox.Location = new System.Drawing.Point(163, 36);
            this.sahinBox.Multiline = true;
            this.sahinBox.Name = "sahinBox";
            this.sahinBox.Size = new System.Drawing.Size(996, 253);
            this.sahinBox.TabIndex = 23;
            this.sahinBox.TextChanged += new System.EventHandler(this.sahinBox_TextChanged);
            // 
            // Calculate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sahinBox);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.lblKar);
            this.Controls.Add(this.button1);
            this.Name = "Calculate";
            this.Size = new System.Drawing.Size(1311, 762);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblKar;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.TextBox sahinBox;
    }
}
