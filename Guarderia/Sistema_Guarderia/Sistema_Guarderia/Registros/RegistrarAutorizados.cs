using Sistema_Guarderia.Clases;
using Sistema_Guarderia.Consultas;
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
        CNegocios logica;
        string opcion = string.Empty;

        public RegistrarAutorizados(string opcion)
        {
            InitializeComponent();
            logica = new CNegocios();
            this.opcion = opcion;
        }

        private void RegistrarAutorizados_Load(object sender, EventArgs e)
        {
            if (this.opcion.Equals("Agregar"))
            {
                 this.lblEstatusAutorizado.Text =  "Nuevo";
                 this.lblEstatusAutorizado.TextAlign = ContentAlignment.BottomCenter;
                 this.activarDarDeBajaToolStripMenuItem.Enabled = false;
            }
            else if (this.opcion.Equals("Cambios"))
            {
                this.lblEstatusAutorizado.Text =  "Modificar";
                this.lblEstatusAutorizado.TextAlign = ContentAlignment.BottomCenter;
                this.guardarToolStripMenuItem.Enabled = false;
            }

            InicializaGridNinios();
        }

        private void btn_foto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            dialog.ShowDialog();

            if (!string.IsNullOrWhiteSpace(dialog.SafeFileName))
            {
                //Tomando la imagen
                this.imagenBytes = this.logica.ObtieneImagenEnArregloBytes(dialog.FileName);
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
            try
            {
                if (!logica.ValidaFormulario(this.Controls as ControlCollection, out controlVacio, out mensaje))
                {
                    controlVacio.Focus();
                    MessageBox.Show(mensaje, "Proceso inconcluso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    List<CNinio> listaNinios = new List<CNinio>();
                    foreach (DataGridViewRow item in dgvNinios.Rows)
                    {
                        if (Convert.ToBoolean((item.Cells["ChkNinio"] as DataGridViewCheckBoxCell).Value))
                        {
                            CNinio ninio = new CNinio()
                            {
                                id_ninio = Convert.ToInt32(item.Cells["id_ninio"].Value),
                                nombreNinio = item.Cells["nombreninio"].Value.ToString(),
                                nombrePadre = item.Cells["nombretutor"].Value.ToString()
                            };

                            listaNinios.Add(ninio);
                        }
                    }

                    if (listaNinios.Count == 0)
                    {
                        MessageBox.Show(string.Format("Favor de seleccionar el o los niños que estará autorizado de recoger {0} {1} {2}.", txt_nombres.Text, txt_ApePat.Text, txt_ApeMat.Text), "Proceso incloncuso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        UTF8Encoding encoding = new UTF8Encoding();
                        CPersona autorizado = new CPersona()
                        {
                            nombre = this.txt_nombres.Text,
                            apellidoPaterno = this.txt_ApePat.Text,
                            apellidoMaterno = this.txt_ApeMat.Text,
                            imagenHuella = encoding.GetBytes("Dedo falso"),
                            fotografia = this.imagenBytes
                        };

                        string resp = logica.GuardaImformacionAutorizados(ref autorizado, listaNinios);
                        if (resp.Equals("Completado"))
                        {
                            MessageBox.Show("Se registraron los datos correctamente.", "Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiaFormulario();
                        }
                        else
                        {
                            MessageBox.Show(resp, "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Mensaje de error: {0}",ex.Message),"Execepción",MessageBoxButtons.OK,MessageBoxIcon.Error);
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

        private void dgvNinios_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvNinios.IsCurrentCellDirty)
            {
                dgvNinios.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        /// <summary>
        /// Inicializa y formatea los valores del grid
        /// </summary>
        private void InicializaGridNinios()
        {
            dgvNinios.DataSource = logica.ConsultaNinios();
            dgvNinios.Columns.Insert(0, new DataGridViewCheckBoxColumn());
            dgvNinios.Columns[0].HeaderText = "Selección";
            dgvNinios.Columns[0].Name = "ChkNinio";
            dgvNinios.Columns["nombreninio"].HeaderText = "Niños inscritos";
            dgvNinios.Columns["nombretutor"].HeaderText = "Padre/Tutor responsable";
            dgvNinios.Columns["id_ninio"].Visible = false;
            dgvNinios.Columns["ChkNinio"].Width = 60;
            dgvNinios.Columns["nombreninio"].Width = 200;
            dgvNinios.Columns["nombretutor"].Width = 200;
            dgvNinios.Columns["nombreninio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvNinios.Columns["nombretutor"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvNinios.Columns["ChkNinio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgvNinios.Columns["nombreninio"].ReadOnly = true;
            dgvNinios.Columns["nombretutor"].ReadOnly = true;
            dgvNinios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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

        /// <summary>
        /// Limpia todos los controles de este formulario
        /// </summary>
        private void LimpiaFormulario()
        {
            this.txt_nombres.Text = string.Empty;
            this.txt_ApePat.Text = string.Empty;
            this.txt_ApeMat.Text = string.Empty;
            this.pb_Foto.Image = null;
            this.pb_huella.Image = null;
            foreach (DataGridViewRow row in dgvNinios.Rows)
            {
                DataGridViewCheckBoxCell cellSelecion = row.Cells["ChkNinio"] as DataGridViewCheckBoxCell;
                cellSelecion.Value = false;
            }
        }
    }
}
