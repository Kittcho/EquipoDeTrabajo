using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Guarderia.Registros
{
    public partial class RegistrarAutorizados : Form
    {
        public RegistrarAutorizados()
        {
            InitializeComponent();
        }

        private void inicializar()
        {
            activarDarDeBajaToolStripMenuItem.Enabled = false;
        }

        private void RegistrarCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
