using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_Guarderia.Clases;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Sistema_Guarderia.Clases
{
    class CNegocios
    {
        //Objetos Globales
        PgConexion conexion;

        public CNegocios()
        {
            this.conexion = new PgConexion();
        }

        #region "Métodos de la foma ConsultaAutorizados"
        public DataTable LlenaGridAutorizados()
        {
            return new DataTable();
        }
        #endregion


        /// <summary>
        /// Convierte una imagen en arreglo de bytes
        /// </summary>
        /// <param name="path">Ruta de la imagen</param>
        /// <returns>La imagen convertida en arreglo de bytes</returns>
        public byte[] ObtieneImagenEnArregloBytes(string path)
        {
            Image imagen = Image.FromFile(path);
            using (var ms = new MemoryStream())
            {
                imagen.Save(ms, imagen.RawFormat);
                return ms.GetBuffer();
            }
        }

        /// <summary>
        /// Valida los controles que se encuentran en la forma
        /// </summary>
        /// <param name="controles">Arrego de controles contenidos en la forma</param>
        /// <param name="controlVacio">En caso de que algún control falte de llenarse este se regresará</param>
        /// <param name="mensaje">En caso de faltar llenar algún control se regresa un mensaje personalizado</param>
        /// <returns>true: si todos los controles esta llenos, false: si falta al menos uno en llenarse </returns>
        public bool ValidaFormulario(System.Windows.Forms.Form.ControlCollection controles, out Control controlVacio, out string mensaje)
        {
            mensaje = string.Empty;
            controlVacio = null;
            bool respuesta = true;

            foreach (var control in controles)
            {
                if (control.GetType().Name.Equals("GroupBox"))
                {
                    foreach (var item in (control as GroupBox).Controls)
                    {
                        if (item.GetType().Name.Equals("TextBox"))
                        {
                            if (string.IsNullOrWhiteSpace((item as TextBox).Text))
                            {
                                controlVacio = item as TextBox;
                                respuesta = false;
                                mensaje = "Favor de llenar completamente el formulario";
                                break;
                            }
                        }
                    }
                    if (!respuesta)
                    {
                        break;
                    }
                }
                else if (control.GetType().Name.Equals("PictureBox"))
                {
                    if ((control as PictureBox).Image == null)
                    {
                        //TODO:Codigó por miestras esta la huella, cuendo este la huella este se debe eliminar y descomentar el de abajo
                        mensaje = "Favor de cargar la imagen de la persona autorizada a recoger niño(s)";
                        if ((control as PictureBox).Name.Equals("pb_Foto"))
                        {
                            mensaje = "Favor de cargar la imagen de la persona autorizada a recoger niño(s)";
                            controlVacio = control as PictureBox;
                            respuesta = false;
                            break;
                        }

                        //TODO:Cuando se pueda capturar la huella este código será el que se utilizará
                        //if ((control as PictureBox).Name.Equals("pb_Foto"))
                        //{
                        //    mensaje = "Favor de cargar la imagen de la persona autorizada a recoger niño(s)";
                        //}
                        //else if((control as PictureBox).Name.Equals("pb_huella"))
                        //{
                        //    mensaje = "Favor de cargar la huella de la persona autorizada a recoger niño(s)";
                        //}

                        //controlVacio = control as PictureBox;
                        //respuesta = false;
                        //break;
                    }
                }
            }
            return respuesta;
        }
    }
}