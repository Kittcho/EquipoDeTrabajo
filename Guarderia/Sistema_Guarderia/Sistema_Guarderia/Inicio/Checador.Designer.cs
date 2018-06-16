namespace Sistema_Guarderia.Inicio
{
    partial class Checador
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
            this.ptb_huella = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_huella)).BeginInit();
            this.SuspendLayout();
            // 
            // ptb_huella
            // 
            this.ptb_huella.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ptb_huella.Location = new System.Drawing.Point(83, 76);
            this.ptb_huella.Name = "ptb_huella";
            this.ptb_huella.Size = new System.Drawing.Size(180, 231);
            this.ptb_huella.TabIndex = 0;
            this.ptb_huella.TabStop = false;
            // 
            // Checador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 485);
            this.Controls.Add(this.ptb_huella);
            this.Name = "Checador";
            this.Text = "Checador Personal";
            ((System.ComponentModel.ISupportInitialize)(this.ptb_huella)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ptb_huella;
    }
}