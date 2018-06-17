using Sistema_Guarderia.Clases;
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
        //Variables Globales
        byte[] imagenBytes;
        CNegocios negocio;

        public RegistrarAutorizados()
        {
            InitializeComponent();
            negocio = new CNegocios();
        }

        private void inicializar()
        {
            activarDarDeBajaToolStripMenuItem.Enabled = false;
        }

        private void RegistrarCliente_Load(object sender, EventArgs e)
        {

        }

        private void btn_foto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            dialog.ShowDialog();

            if (!string.IsNullOrWhiteSpace(dialog.SafeFileName))
            {
                //Tomando la imagen
                this.imagenBytes = this.negocio.ObtieneImagenEnArregloBytes(dialog.FileName);
                //mostrando en el picturebox
                this.pb_Foto.Image = Image.FromFile(dialog.FileName);
                this.pb_Foto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control controlVacio;
            string mensaje = string.Empty;
            if(!negocio.ValidaFormulario(this.Controls as ControlCollection, out controlVacio, out mensaje))
            {
                controlVacio.Focus();
                MessageBox.Show(mensaje,"Proceso inconcluso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }else
            {
                //TODO: REALIZAR EL PROCESO DE GUARDADO
            }
        }

        //TODO: VALIDAR LAS CAJAS DE TEXTO PARA QUE SOLO ACEPTEN LETRAS O NUMEROS
    }
}
