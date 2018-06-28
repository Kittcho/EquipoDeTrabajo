using Sistema_Guarderia.Clases;
using Sistema_Guarderia.Consultas;
using Sistema_Guarderia.enumeradores;
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
        CPersona autorizado;
        bool imagenModificada = false;
        bool textoModificado = false;

        public RegistrarAutorizados(string opcion, CPersona autorizado = null)
        {
            InitializeComponent();
            logica = new CNegocios();
            this.opcion = opcion;
            this.autorizado = autorizado;
        }

        private void RegistrarAutorizados_Load(object sender, EventArgs e)
        {
            if (this.opcion.Equals("Agregar"))
            {
                 this.lblEstatusAutorizado.Text =  "Nuevo";
                 this.lblEstatusAutorizado.TextAlign = ContentAlignment.BottomCenter;
                 this.activarDarDeBajaToolStripMenuItem.Enabled = false;
                InicializaGridNinios();
            }
            else if (this.opcion.Equals("Cambios"))
            {
                this.lblEstatusAutorizado.Text = this.autorizado.estadoStr;
                this.lblEstatusAutorizado.TextAlign = ContentAlignment.BottomCenter;
                this.guardarToolStripMenuItem.Enabled = false;
                this.btn_foto.Text = "Recapturar forografía";
                this.btn_huella.Text = "Recapturar huella";
                this.txt_nombres.Text = this.autorizado.nombre;
                this.txt_ApePat.Text = this.autorizado.apellidoPaterno;
                this.txt_ApeMat.Text = this.autorizado.apellidoMaterno;
                this.pb_Foto.Image = this.autorizado.fotografiaImage;
                InicializaGridNinios(this.autorizado.listaIdNinios);
            }
            this.gbInfoBasica.Enabled = false;
            this.gbNinios.Enabled = false;
            this.modificarToolStripMenuItem.Enabled = false;
        }

        private void btn_foto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            dialog.ShowDialog();

            if (!string.IsNullOrWhiteSpace(dialog.SafeFileName))
            {
                //Tomando la imagen
                this.imagenBytes = this.logica.ConvierteImagenEnArregloBytes(dialog.FileName);
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
                        if (lblEstatusAutorizado.Text.Trim().Equals("Nuevo"))
                        {
                            CPersona autorizado = new CPersona()
                            {
                                nombre = this.txt_nombres.Text,
                                apellidoPaterno = this.txt_ApePat.Text,
                                apellidoMaterno = this.txt_ApeMat.Text,
                                imagenHuellaArray = new UTF8Encoding().GetBytes("Dedo falso"),
                                fotografiaArray = this.imagenBytes
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
                        else if (lblEstatusAutorizado.Text.Trim().Equals("Activo"))
                        {
                            int registrosInfoBasica = -1;
                            int registrosImagen = -1;
                            if (this.textoModificado)
                            {
                                registrosInfoBasica = logica.ActualizaInformacionBasica(new CPersona()
                                                                                        {
                                                                                            id_foto = this.autorizado.id_foto,
                                                                                            nombre = txt_nombres.Text,
                                                                                            apellidoPaterno = txt_ApePat.Text,
                                                                                            apellidoMaterno = txt_ApeMat.Text
                                                                                        });
                            }
                            if (this.imagenModificada)
                            {
                                registrosImagen = logica.ActualizaImagen(new CPersona() { 
                                                                         id_foto = this.autorizado.id_foto,
                                                                         imagenHuellaArray = logica.ConvierteImagenEnArregloBytes(this.pb_Foto.Image)
                                                                          });
                            }

                            // Validando si guardo la información
                            if (this.textoModificado && this.imagenModificada)
                            {
                                if (registrosInfoBasica > 0 && registrosImagen > 0)
                                {
                                    mensaje = "Todo se actualizo correctamente.";
                                    ActualizarCambiosGuadadosAutorizado(ActualizarCambiosGuardados.Infoyfoto);
                                }
                                else if (registrosInfoBasica > 0)
                                {
                                    mensaje = "Solo se guardo la información basica pero ocurrio un problema al intentar guardar la imagen de perfil. Favor de contactar al administrador del sistema";
                                    ActualizarCambiosGuadadosAutorizado(ActualizarCambiosGuardados.InfoBasica);
                                }else
                                {
                                    mensaje = "Solo se guardo la imagen de perfil pero ocurrio un problema al intentar guardar la información basica. Favor de contactar al administrador del sistema";
                                    ActualizarCambiosGuadadosAutorizado(ActualizarCambiosGuardados.Fotogragia);
                                }
                            }
                            else if (this.textoModificado)
                            {
                                if (registrosInfoBasica > 0)
                                {
                                    mensaje = "Se actualizó correctamente la información basica.";
                                    ActualizarCambiosGuadadosAutorizado(ActualizarCambiosGuardados.InfoBasica);
                                }
                                else
                                {
                                    mensaje = "Ocurrio un error al intentar guarda la información basica. Favor de contactarse con el administrador del sistema.";
                                }
                            }
                            else if (this.imagenModificada)
                            {
                                if (registrosImagen > 0)
                                {
                                    mensaje = "Se actualizó correctamente la información imagen de perfil.";
                                    ActualizarCambiosGuadadosAutorizado(ActualizarCambiosGuardados.Fotogragia);
                                }
                                else
                                {
                                    mensaje = "Ocurrio un error al intentar guarda la imagen de perfil. Favor de contactarse con el administrador del sistema.";
                                }
                            }

                            MessageBox.Show(mensaje,"Información",MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.textoModificado = false;
                            this.imagenModificada = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Mensaje de error: {0}",ex.Message),"Execepción",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void ActualizarCambiosGuadadosAutorizado(ActualizarCambiosGuardados opcion)
        {
            switch (opcion)
            {
                case ActualizarCambiosGuardados.InfoBasica:
                    this.autorizado.nombre = txt_nombres.Text;
                    this.autorizado.apellidoPaterno = txt_ApePat.Text;
                    this.autorizado.apellidoMaterno = txt_ApeMat.Text; 
                break;
                case ActualizarCambiosGuardados.Fotogragia:
                    this.autorizado.fotografiaImage = pb_Foto.Image;
                    this.autorizado.fotografiaArray = logica.ConvierteImagenEnArregloBytes(this.pb_Foto.Image);
                break;
                case ActualizarCambiosGuardados.Infoyfoto:
                    this.autorizado.nombre = txt_nombres.Text;
                    this.autorizado.apellidoPaterno = txt_ApePat.Text;
                    this.autorizado.apellidoMaterno = txt_ApeMat.Text; 
                    this.autorizado.fotografiaImage = pb_Foto.Image;
                    this.autorizado.fotografiaArray = logica.ConvierteImagenEnArregloBytes(this.pb_Foto.Image);
                break;
                case ActualizarCambiosGuardados.ListaNinios:
                    break;
                case ActualizarCambiosGuardados.Todo:
                    this.autorizado.nombre = txt_nombres.Text;
                    this.autorizado.apellidoPaterno = txt_ApePat.Text;
                    this.autorizado.apellidoMaterno = txt_ApeMat.Text; 
                    this.autorizado.fotografiaImage = pb_Foto.Image;
                    this.autorizado.fotografiaArray = logica.ConvierteImagenEnArregloBytes(this.pb_Foto.Image);
                    break;
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

        private void activarDarDeBajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            if (Convert.ToBoolean(autorizado.estado[0]))
            {
                mensaje = string.Format("¿Esta seguro(a) de querer dar de baja a la persona <{0} {1} {2}> como autorizado para recoger niño(s)?", this.txt_nombres.Text, txt_ApePat.Text, this.txt_ApeMat.Text);
            }
            else
            {
                mensaje = string.Format("¿Esta seguro(a) de querer activar a la persona <{0} {1} {2}> como autorizado para recoger niño(s) de nuevo?", this.txt_nombres.Text, txt_ApePat.Text, this.txt_ApeMat.Text);
            }

            DialogResult respuesta = MessageBox.Show(mensaje, "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Question);
            if (respuesta == DialogResult.OK)
            {
                int registros = logica.CambiaEstatusAutorizados(autorizado.id_foto, !Convert.ToBoolean(autorizado.estado[0]));
                if (registros > 0)
                {
                    MessageBox.Show("Persona actualizada correctamente", "Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void informaciónBasicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (informaciónBasicaToolStripMenuItem.Checked)
            {
                this.gbInfoBasica.Enabled = true;
                this.niñosAsignadosToolStripMenuItem.Checked = false;
                this.ambosToolStripMenuItem.Checked = false;
                this.gbNinios.Enabled = false;
            }
            else
            {
                this.gbInfoBasica.Enabled = false;
            }
        }

        private void niñosAsignadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (niñosAsignadosToolStripMenuItem.Checked)
            {
                this.gbNinios.Enabled = true;
                this.informaciónBasicaToolStripMenuItem.Checked = false;
                this.ambosToolStripMenuItem.Checked = false;
                this.gbInfoBasica.Enabled = false;
            }
            else
            {
                this.gbNinios.Enabled = false;
            }
        }

        private void ambosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ambosToolStripMenuItem.Checked)
            {
                this.gbInfoBasica.Enabled = true;
                this.gbNinios.Enabled = true;
                this.informaciónBasicaToolStripMenuItem.Checked = false;
                this.niñosAsignadosToolStripMenuItem.Checked = false;
            }
            else
            {
                this.gbInfoBasica.Enabled = false;
                this.gbNinios.Enabled = false;
            }
        }

        private void opcionesToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            if (lblEstatusAutorizado.Text.Trim().Equals("Activo"))
            {
                this.modificarToolStripMenuItem.Enabled = true;

                if (this.gbInfoBasica.Enabled && ValidaSiExistenCambiosInfoBasica(ref this.imagenModificada, ref this.textoModificado))
                {
                    this.guardarToolStripMenuItem.Enabled = true;
                }
                else
                {
                    this.guardarToolStripMenuItem.Enabled = false;
                }
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
        /// Muestra marcados en el grid los niños asociados al autorizado
        /// </summary>
        /// <param name="listaNinios">Lista de niños relacionados a la persona</param>
        private void InicializaGridNinios(List<int> listaNinios)
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

            foreach (DataGridViewRow row in dgvNinios.Rows)
            {
                foreach (int idNinio in listaNinios)
                {
                    if (Convert.ToInt32(row.Cells["id_ninio"].Value) == idNinio)
                    {
                        DataGridViewCheckBoxCell cellSelecion = row.Cells["ChkNinio"] as DataGridViewCheckBoxCell;
                        cellSelecion.Value = true;
                        continue;
                    } 
                }
            }
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

        /// <summary>
        /// Valida si fueron afectados los campos de datos personales, su foto o ambos
        /// </summary>
        /// <param name="imagenModificada"></param>
        /// <param name="textoModificado"></param>
        /// <returns></returns>
        private bool ValidaSiExistenCambiosInfoBasica(ref bool imagenModificada, ref bool textoModificado)
        {
            bool resp = false;

            if (!this.autorizado.nombre.Equals(txt_nombres.Text.Trim()) || !this.autorizado.apellidoPaterno.Equals(txt_ApePat.Text.Trim()) || !this.autorizado.apellidoMaterno.Equals(txt_ApeMat.Text.Trim()))
            {
                resp = true;
                this.textoModificado = true;
            }

            if (!this.autorizado.fotografiaImage.Equals(this.pb_Foto.Image))
            {
                resp = true;
                this.imagenModificada = true;
            }
            return resp;
        }
    }
}
