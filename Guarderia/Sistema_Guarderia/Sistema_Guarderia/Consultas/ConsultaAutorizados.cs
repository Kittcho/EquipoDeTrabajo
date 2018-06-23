using Sistema_Guarderia.Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Guarderia.Consultas
{
    public partial class ConsultaAutorizados : Form
    {
        public ConsultaAutorizados()
        {
            InitializeComponent();
        }

        private void ConsultaAutorizados_Load(object sender, EventArgs e)
        {

        }

        private void agregarPersonaAutorizadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrarAutorizados autorizados = new RegistrarAutorizados("Agregar");
            autorizados.ShowDialog();
            this.Show();
        }
    }
}
