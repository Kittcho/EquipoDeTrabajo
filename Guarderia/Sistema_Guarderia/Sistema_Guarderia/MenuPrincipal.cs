using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_Guarderia.Registros;
using Sistema_Guarderia.Facturacion;
using Sistema_Guarderia.Inicio;
using Sistema_Guarderia.Acceso;
using Devart.Data;
using Devart.Common;
using Sistema_Guarderia.Clases;
using Sistema_Guarderia.Consultas;

namespace Sistema_Guarderia
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        #region LLamados a formularios

        private void registroAutorizadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void registroClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarCliente RegistroCliente = new RegistrarCliente();
            RegistroCliente.ShowDialog();
        }

        private void generarFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Genera_factura Factura = new Genera_factura();
            Factura.ShowDialog();
        }

        private void registrarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Checador checador = new Checador();
            checador.ShowDialog();
        }

        #endregion

        #region Eventos
        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            
            Acceso_usuario acceso = new Acceso_usuario();
            acceso.ShowDialog();

            bool bAcceso = acceso.bAcceso;

            if (!bAcceso)
            {
                this.Close();
            }
        }

        #endregion

        private void checadorClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChecadorClientes clientes = new ChecadorClientes();
            clientes.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registroAutorizadosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConsultaAutorizados autorizados = new ConsultaAutorizados();
            autorizados.ShowDialog();
        }
    }
}
