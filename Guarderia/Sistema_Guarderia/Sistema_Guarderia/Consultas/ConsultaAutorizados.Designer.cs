namespace Sistema_Guarderia.Consultas
{
    partial class ConsultaAutorizados
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.dgvAutorizados = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarPersonaAutorizadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pb_Foto = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutorizados)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Foto)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(243, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Buscaqueda por Autorizado:";
            this.label1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(388, 27);
            this.txtFiltro.MaxLength = 200;
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(377, 20);
            this.txtFiltro.TabIndex = 2;
            this.txtFiltro.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dgvAutorizados
            // 
            this.dgvAutorizados.AllowUserToAddRows = false;
            this.dgvAutorizados.AllowUserToDeleteRows = false;
            this.dgvAutorizados.AllowUserToResizeColumns = false;
            this.dgvAutorizados.AllowUserToResizeRows = false;
            this.dgvAutorizados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAutorizados.Location = new System.Drawing.Point(246, 59);
            this.dgvAutorizados.MultiSelect = false;
            this.dgvAutorizados.Name = "dgvAutorizados";
            this.dgvAutorizados.ReadOnly = true;
            this.dgvAutorizados.RowHeadersVisible = false;
            this.dgvAutorizados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAutorizados.Size = new System.Drawing.Size(550, 302);
            this.dgvAutorizados.TabIndex = 3;
            this.dgvAutorizados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAutorizados_CellDoubleClick);
            this.dgvAutorizados.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAutorizados_RowEnter);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(808, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarPersonaAutorizadaToolStripMenuItem});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // agregarPersonaAutorizadaToolStripMenuItem
            // 
            this.agregarPersonaAutorizadaToolStripMenuItem.Name = "agregarPersonaAutorizadaToolStripMenuItem";
            this.agregarPersonaAutorizadaToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.agregarPersonaAutorizadaToolStripMenuItem.Text = "Agregar persona autorizada";
            this.agregarPersonaAutorizadaToolStripMenuItem.Click += new System.EventHandler(this.agregarPersonaAutorizadaToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(22, 20);
            this.toolStripMenuItem1.Text = " ";
            // 
            // pb_Foto
            // 
            this.pb_Foto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb_Foto.Location = new System.Drawing.Point(33, 100);
            this.pb_Foto.Margin = new System.Windows.Forms.Padding(2);
            this.pb_Foto.Name = "pb_Foto";
            this.pb_Foto.Size = new System.Drawing.Size(175, 184);
            this.pb_Foto.TabIndex = 30;
            this.pb_Foto.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 302);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 17);
            this.label2.TabIndex = 31;
            this.label2.Text = "Fotografía autorizado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(308, 377);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(431, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Para editar datos favor de dar doble click sobre el nombre de la persona que dese" +
    "a editar.";
            // 
            // ConsultaAutorizados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 399);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pb_Foto);
            this.Controls.Add(this.dgvAutorizados);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ConsultaAutorizados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de personas autorizadas a recoger niños";
            this.Load += new System.EventHandler(this.ConsultaAutorizados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutorizados)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Foto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.DataGridView dgvAutorizados;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarPersonaAutorizadaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.PictureBox pb_Foto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}