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
            this.btn_ilerle = new System.Windows.Forms.Button();
            this.btn_islem_basla = new System.Windows.Forms.Button();
            this.lbl_sutun = new System.Windows.Forms.Label();
            this.lbl_satir = new System.Windows.Forms.Label();
            this.txt_sutun = new System.Windows.Forms.TextBox();
            this.txt_satir = new System.Windows.Forms.TextBox();
            this.btn_olustur = new System.Windows.Forms.Button();
            this.grb_baslangic = new System.Windows.Forms.GroupBox();
            this.rd_el_ile = new System.Windows.Forms.RadioButton();
            this.rd_random = new System.Windows.Forms.RadioButton();
            this.chk_rota = new System.Windows.Forms.CheckBox();
            this.lbl_kapsamalar = new System.Windows.Forms.Label();
            this.grb_baslangic.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_ilerle
            // 
            this.btn_ilerle.Location = new System.Drawing.Point(440, 23);
            this.btn_ilerle.Name = "btn_ilerle";
            this.btn_ilerle.Size = new System.Drawing.Size(75, 50);
            this.btn_ilerle.TabIndex = 14;
            this.btn_ilerle.Text = "İlerle";
            this.btn_ilerle.UseVisualStyleBackColor = true;
            this.btn_ilerle.Click += new System.EventHandler(this.btn_ilerle_Click);
            // 
            // btn_islem_basla
            // 
            this.btn_islem_basla.Location = new System.Drawing.Point(359, 23);
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
            this.lbl_sutun.Location = new System.Drawing.Point(68, 21);
            this.lbl_sutun.Name = "lbl_sutun";
            this.lbl_sutun.Size = new System.Drawing.Size(45, 17);
            this.lbl_sutun.TabIndex = 12;
            this.lbl_sutun.Text = "Sütun";
            // 
            // lbl_satir
            // 
            this.lbl_satir.AutoSize = true;
            this.lbl_satir.Location = new System.Drawing.Point(11, 21);
            this.lbl_satir.Name = "lbl_satir";
            this.lbl_satir.Size = new System.Drawing.Size(37, 17);
            this.lbl_satir.TabIndex = 11;
            this.lbl_satir.Text = "Satır";
            // 
            // txt_sutun
            // 
            this.txt_sutun.Location = new System.Drawing.Point(64, 41);
            this.txt_sutun.Multiline = true;
            this.txt_sutun.Name = "txt_sutun";
            this.txt_sutun.Size = new System.Drawing.Size(49, 32);
            this.txt_sutun.TabIndex = 10;
            // 
            // txt_satir
            // 
            this.txt_satir.Location = new System.Drawing.Point(9, 41);
            this.txt_satir.Multiline = true;
            this.txt_satir.Name = "txt_satir";
            this.txt_satir.Size = new System.Drawing.Size(49, 32);
            this.txt_satir.TabIndex = 9;
            // 
            // btn_olustur
            // 
            this.btn_olustur.Location = new System.Drawing.Point(271, 23);
            this.btn_olustur.Name = "btn_olustur";
            this.btn_olustur.Size = new System.Drawing.Size(73, 50);
            this.btn_olustur.TabIndex = 8;
            this.btn_olustur.Text = "Olustur";
            this.btn_olustur.UseVisualStyleBackColor = true;
            this.btn_olustur.Click += new System.EventHandler(this.btn_olustur_Click);
            // 
            // grb_baslangic
            // 
            this.grb_baslangic.Controls.Add(this.chk_rota);
            this.grb_baslangic.Controls.Add(this.rd_random);
            this.grb_baslangic.Controls.Add(this.rd_el_ile);
            this.grb_baslangic.Controls.Add(this.txt_sutun);
            this.grb_baslangic.Controls.Add(this.txt_satir);
            this.grb_baslangic.Controls.Add(this.lbl_satir);
            this.grb_baslangic.Controls.Add(this.lbl_sutun);
            this.grb_baslangic.Controls.Add(this.btn_olustur);
            this.grb_baslangic.Location = new System.Drawing.Point(3, 0);
            this.grb_baslangic.Name = "grb_baslangic";
            this.grb_baslangic.Size = new System.Drawing.Size(350, 96);
            this.grb_baslangic.TabIndex = 16;
            this.grb_baslangic.TabStop = false;
            this.grb_baslangic.Text = "Başlangıç";
            // 
            // rd_el_ile
            // 
            this.rd_el_ile.AutoSize = true;
            this.rd_el_ile.Location = new System.Drawing.Point(119, 23);
            this.rd_el_ile.Name = "rd_el_ile";
            this.rd_el_ile.Size = new System.Drawing.Size(140, 21);
            this.rd_el_ile.TabIndex = 13;
            this.rd_el_ile.TabStop = true;
            this.rd_el_ile.Text = "Değerleri el ile gir";
            this.rd_el_ile.UseVisualStyleBackColor = true;
            // 
            // rd_random
            // 
            this.rd_random.AutoSize = true;
            this.rd_random.Location = new System.Drawing.Point(119, 47);
            this.rd_random.Name = "rd_random";
            this.rd_random.Size = new System.Drawing.Size(132, 21);
            this.rd_random.TabIndex = 14;
            this.rd_random.TabStop = true;
            this.rd_random.Text = "Random atansın";
            this.rd_random.UseVisualStyleBackColor = true;
            // 
            // chk_rota
            // 
            this.chk_rota.AutoSize = true;
            this.chk_rota.Location = new System.Drawing.Point(117, 72);
            this.chk_rota.Name = "chk_rota";
            this.chk_rota.Size = new System.Drawing.Size(148, 21);
            this.chk_rota.TabIndex = 15;
            this.chk_rota.Text = "Sadece rota kullan";
            this.chk_rota.UseVisualStyleBackColor = true;
            // 
            // lbl_kapsamalar
            // 
            this.lbl_kapsamalar.AutoSize = true;
            this.lbl_kapsamalar.Location = new System.Drawing.Point(521, 49);
            this.lbl_kapsamalar.Name = "lbl_kapsamalar";
            this.lbl_kapsamalar.Size = new System.Drawing.Size(99, 17);
            this.lbl_kapsamalar.TabIndex = 17;
            this.lbl_kapsamalar.Text = "Kapsamalar = ";
            // 
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 700);
            this.Controls.Add(this.lbl_kapsamalar);
            this.Controls.Add(this.grb_baslangic);
            this.Controls.Add(this.btn_ilerle);
            this.Controls.Add(this.btn_islem_basla);
            this.Name = "AnaForm";
            this.Text = "AnaForm";
            this.Load += new System.EventHandler(this.AnaForm_Load);
            this.grb_baslangic.ResumeLayout(false);
            this.grb_baslangic.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_ilerle;
        private System.Windows.Forms.Button btn_islem_basla;
        private System.Windows.Forms.Label lbl_sutun;
        private System.Windows.Forms.Label lbl_satir;
        private System.Windows.Forms.TextBox txt_sutun;
        private System.Windows.Forms.TextBox txt_satir;
        private System.Windows.Forms.Button btn_olustur;
        private System.Windows.Forms.GroupBox grb_baslangic;
        private System.Windows.Forms.RadioButton rd_random;
        private System.Windows.Forms.RadioButton rd_el_ile;
        private System.Windows.Forms.CheckBox chk_rota;
        private System.Windows.Forms.Label lbl_kapsamalar;
    }
}