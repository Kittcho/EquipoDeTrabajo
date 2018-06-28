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

        /// <summary>
        /// Convierte una imagen en arreglo de bytes
        /// </summary>
        /// <param name="path">Ruta de la imagen</param>
        /// <returns>La imagen convertida en arreglo de bytes</returns>
        public byte[] ConvierteImagenEnArregloBytes(string path)
        {
            try
            {
                Image imagen = Image.FromFile(path);
                using (var ms = new MemoryStream())
                {
                    imagen.Save(ms, imagen.RawFormat);
                    return ms.GetBuffer();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public byte[] ConvierteImagenEnArregloBytes(Image imagen)
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    imagen.Save(ms, imagen.RawFormat);
                    return ms.GetBuffer();
                }
            }
            catch (Exception)
            {
                throw;
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

            try
            {
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
            }
            catch (Exception)
            {
                throw;
            }
            return respuesta;
        }

        /// <summary>
        /// Guarda la foto del autorizado y posteriormente registra ala persona en la tabla de Autorizados
        /// </summary>
        /// <param name="autorizado">Datos de la persona a registrar</param>
        /// <param name="listaNinios">Nino(s) seleccionado(s)</param>
        /// <returns>Completado = si pudo guardar la foto  y registrar ala persona ó el mensaje de error generado</returns>
        public string GuardaImformacionAutorizados(ref CPersona autorizado, List<CNinio> listaNinios)
        {
            string respuesta = "Completado";
            int cantidadNinios = listaNinios.Count;
            int cantidadDeInsert = 0;

            try
            {
                int idFoto = GuardaImagen(autorizado.fotografiaArray);

                if (idFoto != -1)
                {
                    foreach (var item in listaNinios)
                    {
                        cantidadDeInsert += conexion.GuardaImformacionAutorizadosConexion(autorizado, idFoto, Convert.ToInt32(item.id_ninio));
                    }

                    if (cantidadDeInsert != cantidadNinios)
                    {
                        respuesta = "Ocurrio un problema al intentar guardar la información, por favor comuníquese con el administrador del sistema.";
                    }
                }
                else
                {
                    respuesta = "No fue posible guardar la fotografia de la persona a registrar, por favor comuníquese con el administrador del sistema.";
                }
            }
            catch (Exception)
            {
                
                throw;
            }

            return respuesta;
        }

        /// <summary>
        /// Guarda y regresa el id generado en la tabla de fotos
        /// </summary>
        /// <param name="imagen">Imagen a guardar</param>
        /// <returns>id generado</returns>
        private int GuardaImagen(byte[] imagen)
        {
            int idFoto = -1;
            try
            {
                idFoto = conexion.GuardaImagenConexion(imagen);
            }
            catch (Exception)
            {
                throw;
            }
            return idFoto;
        }

        /// <summary>
        /// Obtiene el listado de niños registrados y activos
        /// </summary>
        /// <returns>Listado de niños con si id y nombre de su padre registrado</returns>
        public DataTable ConsultaNinios()
        {
            try
            {
                return conexion.Consulta(@"SELECT ninios.id_ninio, ninios.cnombres||' '||ninios.capellidopat||' '||ninios.capellidomat AS NombreNinio, 
                                     padres.cnombres||' '||padres.capellidopat||' '||padres.capellidomat AS NombreTutor 
                                     FROM reg_ninios ninios 
                                     INNER JOIN reg_personas padres 
                                     ON ninios.id_persona = padres.id_persona 
                                     WHERE ninios.bactivo = '1' 
                                     ORDER BY ninios.id_ninio;");
            }
            catch (Exception)
            {   
                throw;
            }
        }

        /// <summary>
        /// Consulta todos loa autorizados activos y sus ninos registrados
        /// </summary>
        /// <returns>Información de los Autorizados</returns>
        public DataTable ConsultaAutorizados()
        {
            try
            {
                return conexion.Consulta(@"SELECT autorizado.id_autorizado
                                              ,ninio.id_ninio
                                              ,autorizado.id_foto
                                              ,autorizado.cnombres
                                              ,autorizado.capellidopat
                                              ,autorizado.capellidomat
                                              ,autorizado.bactivo
                                              ,autorizado.cnombres || ' ' || autorizado.capellidopat || ' ' || autorizado.capellidomat AS NombreAutorizadoCompleto
                                              ,ninio.cnombres || ' ' || ninio.capellidopat || ' ' || ninio.capellidomat AS NombreNinio
                                              ,CASE WHEN autorizado.bactivo = '1' THEN 'Activo' ELSE 'Baja' END  AS estatus                                            
                                              ,autorizado.dfechaultimaactualizacion
                                       FROM reg_autorizado autorizado
                                       INNER JOIN reg_ninios ninio
                                       ON autorizado.id_ninio = ninio.id_ninio
                                       ORDER BY autorizado.bactivo desc, autorizado.capellidopat");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta la imagen ligada al id proporcionado
        /// </summary>
        /// <param name="id">Id a consultar</param>
        /// <returns>Imagen</returns>
        public Image ObtieneImagenPorId(int id)
        {
            try
            {
                var imagenEnBytes = conexion.ConsultaImagen(string.Format("SELECT imagen FROM reg_fotos WHERE id_foto = {0}", id));
                MemoryStream ms = new MemoryStream(imagenEnBytes);
                Image devolverImagen = Image.FromStream(ms);
                return devolverImagen;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int CambiaEstatusAutorizados(int idFoto, bool activo)
        {
            try
            {
                return conexion.NonQuery(string.Format("UPDATE reg_autorizado SET bactivo = '{0}' WHERE id_foto = {1}", Convert.ToInt16(activo), idFoto));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ActualizaInformacionBasica(CPersona autorizado)
        {
            return conexion.NonQuery(string.Format(@"UPDATE reg_autorizado SET cnombres = '{0}', capellidopat = '{1}', capellidomat = '{2}', dfechaultimaactualizacion = now()
                                                     WHERE id_foto = {3}",autorizado.nombre, autorizado.apellidoPaterno, autorizado.apellidoMaterno,autorizado.id_foto));
        }

        public int ActualizaImagen(CPersona autorizado)
        {
            return conexion.ActualizaImagenConexion(autorizado);
        }
    }
}