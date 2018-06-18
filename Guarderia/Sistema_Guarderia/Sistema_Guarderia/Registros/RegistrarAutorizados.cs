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
            //Valida que los controles no esten vacios
            if(!negocio.ValidaFormulario(this.Controls as ControlCollection, out controlVacio, out mensaje))
            {
                controlVacio.Focus();
                MessageBox.Show(mensaje,"Proceso inconcluso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }else
            {
                //TODO: REALIZAR EL PROCESO DE GUARDADO
                if (txt_CodigoPostal.Text.Length < 5)
                {
                    MessageBox.Show("Favor de ingresar un código postal valido.","Proceso inconcluso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    this.txt_CodigoPostal.Select();
                    this.txt_CodigoPostal.Focus();
                }
                else if (txt_NumCasa.Text.Length < 10)
                {
                    MessageBox.Show("Favor de ingresar un número telefonico valido.\nSi el número es de casa, favor de ingresar la LADA.", "Proceso inconcluso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txt_CodigoPostal.Select();
                    this.txt_CodigoPostal.Focus();
                }
                else//INICIAMOS CON EL PORCESO DE GUARDADO
                {

                }



            }
        }

        private void txt_nombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloLetras(e);
        }

        private void txt_ApePat_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloLetras(e);
        }

        private void txt_ApeMat_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloLetras(e);
        }

        private void txt_Calle_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloLetras(e);
        }

        private void txt_Ciudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloLetras(e);
        }

        private void txt_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txt_NumCasa_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txt_CodigoPostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txt_Colonia_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumerosYLetras(e);
        }

        /// <summary>
        /// Solo deja capturar letras, retoseso o espacio en el textbox
        /// </summary>
        /// <param name="e">Evento contenedor de la tecla presionada</param>
        private void SoloLetras(KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// Solo deja capturar numeros y retoseso en el textbox
        /// </summary>
        /// <param name="e">Evento contenedor de la tecla presionada</param>
        private void SoloNumeros(KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// Solo deja capturar numeros, letras, retoseso y espacio en el textbox
        /// </summary>
        /// <param name="e">Evento contenedor de la tecla presionada</param>
        private void SoloNumerosYLetras(KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && !(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
