namespace Sistema_Guarderia
{
    partial class MenuPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.registroEntradasSalidasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checadorClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroAutorizadosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaDeClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registroEntradasSalidasToolStripMenuItem,
            this.clientesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(819, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // registroEntradasSalidasToolStripMenuItem
            // 
            this.registroEntradasSalidasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarClienteToolStripMenuItem,
            this.checadorClientesToolStripMenuItem});
            this.registroEntradasSalidasToolStripMenuItem.Name = "registroEntradasSalidasToolStripMenuItem";
            this.registroEntradasSalidasToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.registroEntradasSalidasToolStripMenuItem.Text = "Checador";
            // 
            // registrarClienteToolStripMenuItem
            // 
            this.registrarClienteToolStripMenuItem.Name = "registrarClienteToolStripMenuItem";
            this.registrarClienteToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.registrarClienteToolStripMenuItem.Text = "Checador Personal";
            this.registrarClienteToolStripMenuItem.Click += new System.EventHandler(this.registrarClienteToolStripMenuItem_Click);
            // 
            // checadorClientesToolStripMenuItem
            // 
            this.checadorClientesToolStripMenuItem.Name = "checadorClientesToolStripMenuItem";
            this.checadorClientesToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.checadorClientesToolStripMenuItem.Text = "Checador Clientes";
            this.checadorClientesToolStripMenuItem.Click += new System.EventHandler(this.checadorClientesToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registroClienteToolStripMenuItem,
            this.registroAutorizadosToolStripMenuItem1,
            this.bajaDeClientesToolStripMenuItem});
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.clientesToolStripMenuItem.Text = "Registros";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // registroClienteToolStripMenuItem
            // 
            this.registroClienteToolStripMenuItem.Name = "registroClienteToolStripMenuItem";
            this.registroClienteToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.registroClienteToolStripMenuItem.Text = "Registrar/editar Cliente";
            this.registroClienteToolStripMenuItem.Click += new System.EventHandler(this.registroClienteToolStripMenuItem_Click);
            // 
            // registroAutorizadosToolStripMenuItem1
            // 
            this.registroAutorizadosToolStripMenuItem1.Name = "registroAutorizadosToolStripMenuItem1";
            this.registroAutorizadosToolStripMenuItem1.Size = new System.Drawing.Size(216, 22);
            this.registroAutorizadosToolStripMenuItem1.Text = "Registrar niño(a)";
            this.registroAutorizadosToolStripMenuItem1.Click += new System.EventHandler(this.registroAutorizadosToolStripMenuItem1_Click);
            // 
            // bajaDeClientesToolStripMenuItem
            // 
            this.bajaDeClientesToolStripMenuItem.Name = "bajaDeClientesToolStripMenuItem";
            this.bajaDeClientesToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.bajaDeClientesToolStripMenuItem.Text = "Registro de autorizados(as)";
            this.bajaDeClientesToolStripMenuItem.Click += new System.EventHandler(this.registroAutorizadosToolStripMenuItem1_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 563);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MenuPrincipal";
            this.Text = "Pekes Club";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem registroEntradasSalidasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroAutorizadosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bajaDeClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checadorClientesToolStripMenuItem;
    }
}

