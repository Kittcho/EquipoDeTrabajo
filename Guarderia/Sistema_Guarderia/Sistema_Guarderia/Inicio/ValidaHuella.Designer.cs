namespace Sistema_Guarderia.Inicio
{
    partial class ValidaHuella
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
            this.pb_huella = new System.Windows.Forms.PictureBox();
            this.lbl_ninio = new System.Windows.Forms.Label();
            this.lbl_nombre = new System.Windows.Forms.Label();
            this.pb_foto = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_huella)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_foto)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_huella
            // 
            this.pb_huella.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb_huella.Location = new System.Drawing.Point(80, 86);
            this.pb_huella.Name = "pb_huella";
            this.pb_huella.Size = new System.Drawing.Size(169, 184);
            this.pb_huella.TabIndex = 0;
            this.pb_huella.TabStop = false;
            // 
            // lbl_ninio
            // 
            this.lbl_ninio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_ninio.Location = new System.Drawing.Point(288, 86);
            this.lbl_ninio.Name = "lbl_ninio";
            this.lbl_ninio.Size = new System.Drawing.Size(219, 23);
            this.lbl_ninio.TabIndex = 1;
            this.lbl_ninio.Text = "label1";
            // 
            // lbl_nombre
            // 
            this.lbl_nombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_nombre.Location = new System.Drawing.Point(288, 142);
            this.lbl_nombre.Name = "lbl_nombre";
            this.lbl_nombre.Size = new System.Drawing.Size(219, 23);
            this.lbl_nombre.TabIndex = 2;
            this.lbl_nombre.Text = "label2";
            // 
            // pb_foto
            // 
            this.pb_foto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb_foto.Location = new System.Drawing.Point(542, 86);
            this.pb_foto.Name = "pb_foto";
            this.pb_foto.Size = new System.Drawing.Size(157, 165);
            this.pb_foto.TabIndex = 3;
            this.pb_foto.TabStop = false;
            // 
            // ValidaHuella
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 387);
            this.Controls.Add(this.pb_foto);
            this.Controls.Add(this.lbl_nombre);
            this.Controls.Add(this.lbl_ninio);
            this.Controls.Add(this.pb_huella);
            this.Name = "ValidaHuella";
            this.Text = "ValidaHuella";
            this.Load += new System.EventHandler(this.ValidaHuella_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_huella)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_foto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_huella;
        private System.Windows.Forms.Label lbl_ninio;
        private System.Windows.Forms.Label lbl_nombre;
        private System.Windows.Forms.PictureBox pb_foto;
    }
}