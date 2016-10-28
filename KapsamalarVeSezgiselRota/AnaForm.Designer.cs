namespace KapsamalarVeSezgiselRota
{
    partial class AnaForm
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
            this.lbl_durum = new System.Windows.Forms.Label();
            this.btn_ilerle = new System.Windows.Forms.Button();
            this.btn_islem_basla = new System.Windows.Forms.Button();
            this.lbl_sutun = new System.Windows.Forms.Label();
            this.lbl_satir = new System.Windows.Forms.Label();
            this.txt_sutun = new System.Windows.Forms.TextBox();
            this.txt_satir = new System.Windows.Forms.TextBox();
            this.btn_olustur = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_durum
            // 
            this.lbl_durum.AutoSize = true;
            this.lbl_durum.Location = new System.Drawing.Point(731, 49);
            this.lbl_durum.Name = "lbl_durum";
            this.lbl_durum.Size = new System.Drawing.Size(0, 17);
            this.lbl_durum.TabIndex = 15;
            // 
            // btn_ilerle
            // 
            this.btn_ilerle.Location = new System.Drawing.Point(349, 21);
            this.btn_ilerle.Name = "btn_ilerle";
            this.btn_ilerle.Size = new System.Drawing.Size(75, 50);
            this.btn_ilerle.TabIndex = 14;
            this.btn_ilerle.Text = "İlerle";
            this.btn_ilerle.UseVisualStyleBackColor = true;
            this.btn_ilerle.Click += new System.EventHandler(this.btn_ilerle_Click);
            // 
            // btn_islem_basla
            // 
            this.btn_islem_basla.Location = new System.Drawing.Point(249, 21);
            this.btn_islem_basla.Name = "btn_islem_basla";
            this.btn_islem_basla.Size = new System.Drawing.Size(75, 50);
            this.btn_islem_basla.TabIndex = 13;
            this.btn_islem_basla.Text = "İsleme basla";
            this.btn_islem_basla.UseVisualStyleBackColor = true;
            this.btn_islem_basla.Click += new System.EventHandler(this.btn_islem_basla_Click);
            // 
            // lbl_sutun
            // 
            this.lbl_sutun.AutoSize = true;
            this.lbl_sutun.Location = new System.Drawing.Point(75, 15);
            this.lbl_sutun.Name = "lbl_sutun";
            this.lbl_sutun.Size = new System.Drawing.Size(45, 17);
            this.lbl_sutun.TabIndex = 12;
            this.lbl_sutun.Text = "Sütun";
            // 
            // lbl_satir
            // 
            this.lbl_satir.AutoSize = true;
            this.lbl_satir.Location = new System.Drawing.Point(18, 15);
            this.lbl_satir.Name = "lbl_satir";
            this.lbl_satir.Size = new System.Drawing.Size(37, 17);
            this.lbl_satir.TabIndex = 11;
            this.lbl_satir.Text = "Satır";
            // 
            // txt_sutun
            // 
            this.txt_sutun.Location = new System.Drawing.Point(71, 35);
            this.txt_sutun.Multiline = true;
            this.txt_sutun.Name = "txt_sutun";
            this.txt_sutun.Size = new System.Drawing.Size(49, 32);
            this.txt_sutun.TabIndex = 10;
            // 
            // txt_satir
            // 
            this.txt_satir.Location = new System.Drawing.Point(16, 35);
            this.txt_satir.Multiline = true;
            this.txt_satir.Name = "txt_satir";
            this.txt_satir.Size = new System.Drawing.Size(49, 32);
            this.txt_satir.TabIndex = 9;
            // 
            // btn_olustur
            // 
            this.btn_olustur.Location = new System.Drawing.Point(126, 21);
            this.btn_olustur.Name = "btn_olustur";
            this.btn_olustur.Size = new System.Drawing.Size(73, 50);
            this.btn_olustur.TabIndex = 8;
            this.btn_olustur.Text = "Olustur";
            this.btn_olustur.UseVisualStyleBackColor = true;
            this.btn_olustur.Click += new System.EventHandler(this.btn_olustur_Click);
            // 
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 700);
            this.Controls.Add(this.lbl_durum);
            this.Controls.Add(this.btn_ilerle);
            this.Controls.Add(this.btn_islem_basla);
            this.Controls.Add(this.lbl_sutun);
            this.Controls.Add(this.lbl_satir);
            this.Controls.Add(this.txt_sutun);
            this.Controls.Add(this.txt_satir);
            this.Controls.Add(this.btn_olustur);
            this.Name = "AnaForm";
            this.Text = "AnaForm";
            this.Load += new System.EventHandler(this.AnaForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_durum;
        private System.Windows.Forms.Button btn_ilerle;
        private System.Windows.Forms.Button btn_islem_basla;
        private System.Windows.Forms.Label lbl_sutun;
        private System.Windows.Forms.Label lbl_satir;
        private System.Windows.Forms.TextBox txt_sutun;
        private System.Windows.Forms.TextBox txt_satir;
        private System.Windows.Forms.Button btn_olustur;
    }
}