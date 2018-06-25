using Sistema_Guarderia.Clases;
using Sistema_Guarderia.Registros;
using System;
using System.Collections;
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
            dgvAutorizados.Columns[3].Visible = false;
            dgvAutorizados.Columns[4].Visible = false;
            dgvAutorizados.Columns[5].Visible = false;
            dgvAutorizados.Columns[6].Visible = false;
            //Nombrando columnas
            dgvAutorizados.Columns[7].HeaderText = "Nombre Completo";
            dgvAutorizados.Columns[8].HeaderText = "Nombre niño(a)";
            dgvAutorizados.Columns[9].HeaderText = "Estatus";
            dgvAutorizados.Columns[10].HeaderText = "Ultima actualización";
            //Lago de las columnas
            dgvAutorizados.Columns["NombreAutorizadoCompleto"].Width = 200;
            dgvAutorizados.Columns["NombreNinio"].Width = 200;
            dgvAutorizados.Columns["dfechaultimaactualizacion"].Width = 130;
            dgvAutorizados.Columns["estatus"].Width = 50;
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
                         where infoFiltrada.Field<string>("NombreAutorizadoCompleto").ToUpper().Contains(txtFiltro.Text.ToUpper())
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
            int idFoto = Convert.ToInt32(dgvAutorizados.Rows[e.RowIndex].Cells["id_foto"].Value);

            try
            {
                var ninios = from ninio in dtInfoAutorizados.AsEnumerable()
                             where ninio.Field<int>("id_foto") == idFoto
                             select ninio;
                List<int> listaIdNinios = new List<int>();
                foreach (var item in ninios)
                {
                    listaIdNinios.Add(Convert.ToInt32(item["id_ninio"]));
                }
                
                CPersona autorizado = new CPersona()
                {
                    estado = (BitArray)dgvAutorizados.Rows[e.RowIndex].Cells["bactivo"].Value,
                    estadoStr = dgvAutorizados.Rows[e.RowIndex].Cells["estatus"].Value.ToString(),
                    id_persona = Convert.ToInt32(dgvAutorizados.Rows[e.RowIndex].Cells["id_autorizado"].Value),
                    id_foto = Convert.ToInt32(dgvAutorizados.Rows[e.RowIndex].Cells["id_foto"].Value),
                    listaIdNinios = listaIdNinios,
                    fotografiaImage = this.pb_Foto.Image,
                    nombre = dgvAutorizados.Rows[e.RowIndex].Cells["cnombres"].Value.ToString(),
                    apellidoPaterno = dgvAutorizados.Rows[e.RowIndex].Cells["capellidopat"].Value.ToString(),
                    apellidoMaterno = dgvAutorizados.Rows[e.RowIndex].Cells["capellidomat"].Value.ToString()
                };
                RegistrarAutorizados modificar = new RegistrarAutorizados("Cambios", autorizado);
                this.Hide();
                modificar.ShowDialog();
                this.dtInfoAutorizados = logica.ConsultaAutorizados();
                dgvAutorizados.DataSource = this.dtInfoAutorizados;
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}",ex.Message),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
