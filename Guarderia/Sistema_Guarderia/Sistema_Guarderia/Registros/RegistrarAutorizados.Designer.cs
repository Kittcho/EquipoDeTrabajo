namespace Sistema_Guarderia.Registros
{
    partial class RegistrarAutorizados
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activarDarDeBajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbInfoBasica = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_nombres = new System.Windows.Forms.TextBox();
            this.txt_ApePat = new System.Windows.Forms.TextBox();
            this.txt_ApeMat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEstatusAutorizado = new System.Windows.Forms.Label();
            this.btn_huella = new System.Windows.Forms.Button();
            this.pb_huella = new System.Windows.Forms.PictureBox();
            this.btn_foto = new System.Windows.Forms.Button();
            this.pb_Foto = new System.Windows.Forms.PictureBox();
            this.gbNinios = new System.Windows.Forms.GroupBox();
            this.dgvNinios = new System.Windows.Forms.DataGridView();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.niñosAsignadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informaciónBasicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ambosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.gbInfoBasica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_huella)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Foto)).BeginInit();
            this.gbNinios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNinios)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 536);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(640, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(640, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activarDarDeBajaToolStripMenuItem,
            this.modificarToolStripMenuItem,
            this.guardarToolStripMenuItem});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            this.opcionesToolStripMenuItem.DropDownOpened += new System.EventHandler(this.opcionesToolStripMenuItem_DropDownOpened);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // activarDarDeBajaToolStripMenuItem
            // 
            this.activarDarDeBajaToolStripMenuItem.Name = "activarDarDeBajaToolStripMenuItem";
            this.activarDarDeBajaToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.activarDarDeBajaToolStripMenuItem.Text = "Activar/Dar de baja";
            this.activarDarDeBajaToolStripMenuItem.Click += new System.EventHandler(this.activarDarDeBajaToolStripMenuItem_Click);
            // 
            // gbInfoBasica
            // 
            this.gbInfoBasica.Controls.Add(this.btn_foto);
            this.gbInfoBasica.Controls.Add(this.label8);
            this.gbInfoBasica.Controls.Add(this.btn_huella);
            this.gbInfoBasica.Controls.Add(this.txt_nombres);
            this.gbInfoBasica.Controls.Add(this.pb_huella);
            this.gbInfoBasica.Controls.Add(this.txt_ApePat);
            this.gbInfoBasica.Controls.Add(this.txt_ApeMat);
            this.gbInfoBasica.Controls.Add(this.label1);
            this.gbInfoBasica.Controls.Add(this.pb_Foto);
            this.gbInfoBasica.Controls.Add(this.label2);
            this.gbInfoBasica.Controls.Add(this.label3);
            this.gbInfoBasica.Controls.Add(this.lblEstatusAutorizado);
            this.gbInfoBasica.Location = new System.Drawing.Point(15, 26);
            this.gbInfoBasica.Margin = new System.Windows.Forms.Padding(2);
            this.gbInfoBasica.Name = "gbInfoBasica";
            this.gbInfoBasica.Padding = new System.Windows.Forms.Padding(2);
            this.gbInfoBasica.Size = new System.Drawing.Size(614, 202);
            this.gbInfoBasica.TabIndex = 0;
            this.gbInfoBasica.TabStop = false;
            this.gbInfoBasica.Text = "Información Básica";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(120, 31);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Estatus Autorizado";
            // 
            // txt_nombres
            // 
            this.txt_nombres.Location = new System.Drawing.Point(229, 61);
            this.txt_nombres.Margin = new System.Windows.Forms.Padding(2);
            this.txt_nombres.MaxLength = 100;
            this.txt_nombres.Name = "txt_nombres";
            this.txt_nombres.Size = new System.Drawing.Size(252, 20);
            this.txt_nombres.TabIndex = 1;
            this.txt_nombres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_nombres_KeyPress);
            // 
            // txt_ApePat
            // 
            this.txt_ApePat.Location = new System.Drawing.Point(229, 84);
            this.txt_ApePat.Margin = new System.Windows.Forms.Padding(2);
            this.txt_ApePat.MaxLength = 50;
            this.txt_ApePat.Name = "txt_ApePat";
            this.txt_ApePat.Size = new System.Drawing.Size(252, 20);
            this.txt_ApePat.TabIndex = 2;
            this.txt_ApePat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ApePat_KeyPress);
            // 
            // txt_ApeMat
            // 
            this.txt_ApeMat.Location = new System.Drawing.Point(229, 107);
            this.txt_ApeMat.Margin = new System.Windows.Forms.Padding(2);
            this.txt_ApeMat.MaxLength = 50;
            this.txt_ApeMat.Name = "txt_ApeMat";
            this.txt_ApeMat.Size = new System.Drawing.Size(252, 20);
            this.txt_ApeMat.TabIndex = 3;
            this.txt_ApeMat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ApeMat_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nombre(s)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Apellido Paterno";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 109);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Apellido Materno";
            // 
            // lblEstatusAutorizado
            // 
            this.lblEstatusAutorizado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEstatusAutorizado.Location = new System.Drawing.Point(229, 30);
            this.lblEstatusAutorizado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEstatusAutorizado.Name = "lblEstatusAutorizado";
            this.lblEstatusAutorizado.Size = new System.Drawing.Size(88, 19);
            this.lblEstatusAutorizado.TabIndex = 0;
            // 
            // btn_huella
            // 
            this.btn_huella.Location = new System.Drawing.Point(508, 146);
            this.btn_huella.Margin = new System.Windows.Forms.Padding(2);
            this.btn_huella.Name = "btn_huella";
            this.btn_huella.Size = new System.Drawing.Size(74, 40);
            this.btn_huella.TabIndex = 3;
            this.btn_huella.Text = "Registrar huella";
            this.btn_huella.UseVisualStyleBackColor = true;
            // 
            // pb_huella
            // 
            this.pb_huella.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb_huella.Location = new System.Drawing.Point(498, 17);
            this.pb_huella.Margin = new System.Windows.Forms.Padding(2);
            this.pb_huella.Name = "pb_huella";
            this.pb_huella.Size = new System.Drawing.Size(102, 122);
            this.pb_huella.TabIndex = 31;
            this.pb_huella.TabStop = false;
            // 
            // btn_foto
            // 
            this.btn_foto.Location = new System.Drawing.Point(26, 146);
            this.btn_foto.Margin = new System.Windows.Forms.Padding(2);
            this.btn_foto.Name = "btn_foto";
            this.btn_foto.Size = new System.Drawing.Size(74, 40);
            this.btn_foto.TabIndex = 2;
            this.btn_foto.Text = "Seleccionar Fotografía";
            this.btn_foto.UseVisualStyleBackColor = true;
            this.btn_foto.Click += new System.EventHandler(this.btn_foto_Click);
            // 
            // pb_Foto
            // 
            this.pb_Foto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb_Foto.Location = new System.Drawing.Point(15, 17);
            this.pb_Foto.Margin = new System.Windows.Forms.Padding(2);
            this.pb_Foto.Name = "pb_Foto";
            this.pb_Foto.Size = new System.Drawing.Size(102, 122);
            this.pb_Foto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Foto.TabIndex = 29;
            this.pb_Foto.TabStop = false;
            // 
            // gbNinios
            // 
            this.gbNinios.Controls.Add(this.dgvNinios);
            this.gbNinios.Location = new System.Drawing.Point(15, 233);
            this.gbNinios.Name = "gbNinios";
            this.gbNinios.Size = new System.Drawing.Size(613, 292);
            this.gbNinios.TabIndex = 32;
            this.gbNinios.TabStop = false;
            this.gbNinios.Text = "Niños";
            // 
            // dgvNinios
            // 
            this.dgvNinios.AllowUserToAddRows = false;
            this.dgvNinios.AllowUserToDeleteRows = false;
            this.dgvNinios.AllowUserToResizeColumns = false;
            this.dgvNinios.AllowUserToResizeRows = false;
            this.dgvNinios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNinios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNinios.Location = new System.Drawing.Point(3, 16);
            this.dgvNinios.MultiSelect = false;
            this.dgvNinios.Name = "dgvNinios";
            this.dgvNinios.RowHeadersVisible = false;
            this.dgvNinios.Size = new System.Drawing.Size(607, 273);
            this.dgvNinios.TabIndex = 1;
            this.dgvNinios.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvNinios_CurrentCellDirtyStateChanged);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informaciónBasicaToolStripMenuItem,
            this.niñosAsignadosToolStripMenuItem,
            this.ambosToolStripMenuItem});
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.modificarToolStripMenuItem.Text = "Modificar";
            // 
            // niñosAsignadosToolStripMenuItem
            // 
            this.niñosAsignadosToolStripMenuItem.CheckOnClick = true;
            this.niñosAsignadosToolStripMenuItem.Name = "niñosAsignadosToolStripMenuItem";
            this.niñosAsignadosToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.niñosAsignadosToolStripMenuItem.Text = "Niño(s) asignados";
            this.niñosAsignadosToolStripMenuItem.Click += new System.EventHandler(this.niñosAsignadosToolStripMenuItem_Click);
            // 
            // informaciónBasicaToolStripMenuItem
            // 
            this.informaciónBasicaToolStripMenuItem.CheckOnClick = true;
            this.informaciónBasicaToolStripMenuItem.Name = "informaciónBasicaToolStripMenuItem";
            this.informaciónBasicaToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.informaciónBasicaToolStripMenuItem.Text = "Información Basica";
            this.informaciónBasicaToolStripMenuItem.Click += new System.EventHandler(this.informaciónBasicaToolStripMenuItem_Click);
            // 
            // ambosToolStripMenuItem
            // 
            this.ambosToolStripMenuItem.CheckOnClick = true;
            this.ambosToolStripMenuItem.Name = "ambosToolStripMenuItem";
            this.ambosToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.ambosToolStripMenuItem.Text = "Ambos";
            this.ambosToolStripMenuItem.Click += new System.EventHandler(this.ambosToolStripMenuItem_Click);
            // 
            // RegistrarAutorizados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 558);
            this.Controls.Add(this.gbNinios);
            this.Controls.Add(this.gbInfoBasica);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "RegistrarAutorizados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Autorizados";
            this.Load += new System.EventHandler(this.RegistrarAutorizados_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbInfoBasica.ResumeLayout(false);
            this.gbInfoBasica.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_huella)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Foto)).EndInit();
            this.gbNinios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNinios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activarDarDeBajaToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbInfoBasica;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_nombres;
        private System.Windows.Forms.TextBox txt_ApePat;
        private System.Windows.Forms.TextBox txt_ApeMat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblEstatusAutorizado;
        private System.Windows.Forms.Button btn_huella;
        private System.Windows.Forms.PictureBox pb_huella;
        private System.Windows.Forms.Button btn_foto;
        private System.Windows.Forms.PictureBox pb_Foto;
        private System.Windows.Forms.GroupBox gbNinios;
        private System.Windows.Forms.DataGridView dgvNinios;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem niñosAsignadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informaciónBasicaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ambosToolStripMenuItem;
    }
}