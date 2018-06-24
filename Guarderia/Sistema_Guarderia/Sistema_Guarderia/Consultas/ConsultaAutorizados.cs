using Sistema_Guarderia.Clases;
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
        CNegocios logica;
        DataTable dtInfoAutorizados;

        public ConsultaAutorizados()
        {
            InitializeComponent();
            logica = new CNegocios();
            dtInfoAutorizados = new DataTable();
        }

        private void ConsultaAutorizados_Load(object sender, EventArgs e)
        {
            this.dtInfoAutorizados = logica.ConsultaAutorizados();
            dgvAutorizados.DataSource = this.dtInfoAutorizados;
            InicializarGridAutorizados();
        }

        private void InicializarGridAutorizados()
        {
            //Ocultando columnas
            dgvAutorizados.Columns[0].Visible = false;
            dgvAutorizados.Columns[1].Visible = false;
            dgvAutorizados.Columns[2].Visible = false;
            //Nombrando columnas
            dgvAutorizados.Columns[3].HeaderText = "Nombre Completo";
            dgvAutorizados.Columns[4].HeaderText = "Nombre niño(a)";
            dgvAutorizados.Columns[5].HeaderText = "Ultima actualización";
            //Lago de las columnas
            dgvAutorizados.Columns["NombreAutorizado"].Width = 200;
            dgvAutorizados.Columns["NombreNinio"].Width = 200;
            dgvAutorizados.Columns["dfechaultimaactualizacion"].Width = 130;
        }

        private void agregarPersonaAutorizadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrarAutorizados autorizados = new RegistrarAutorizados("Agregar");
            autorizados.ShowDialog();
            this.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dtFiltrada = dtInfoAutorizados.Clone();// Copiamos la estructura de la tabla origen

            var filtro = from infoFiltrada in this.dtInfoAutorizados.AsEnumerable()
                         where infoFiltrada.Field<string>("NombreAutorizado").ToUpper().Contains(txtFiltro.Text.ToUpper())
                         select infoFiltrada;

            foreach (var item in filtro)
            {
                dtFiltrada.ImportRow(item);
            }

            dgvAutorizados.DataSource = dtFiltrada;
        }

        private void dgvAutorizados_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0)
            {
                this.pb_Foto.Image = logica.ObtieneImagenPorId(Convert.ToInt32(dgvAutorizados.Rows[e.RowIndex].Cells["id_foto"].Value));
                this.pb_Foto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void dgvAutorizados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var registro = dgvAutorizados.CurrentRow;
            CPersona autorizado = new CPersona()
            {
                id_persona = Convert.ToInt32(registro.Cells["id_autorizado"].Value),
                id_foto = Convert.ToInt32(registro.Cells["id_foto"].Value),
                id_ninio = Convert.ToInt32(registro.Cells["id_ninio"].Value),
                fotografiaImage = this.pb_Foto.Image
            };
            RegistrarAutorizados modificar = new RegistrarAutorizados("Cambios", autorizado);
            modificar.ShowDialog();
        }
    }
}
