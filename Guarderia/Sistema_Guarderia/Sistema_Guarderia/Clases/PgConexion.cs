﻿using Devart.Data.PostgreSql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Guarderia.Clases
{
    class PgConexion
    {
        //Variables Globales
        private string sConexion = string.Empty;

        public PgConexion()
        {
            try
            {
                this.sConexion = ConfigurationManager.ConnectionStrings["connPg"].ConnectionString;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta a la Bd y retorna la información en un DataSet
        /// </summary>
        /// <param name="sCadenaConexion">Cadena de conexion</param>
        /// <param name="ds">recibe de referencia un dataset</param>
        public DataSet ConsultaSqlDataSet(string sConsulta)
        {
            DataSet dts = new DataSet();
            try
            {
                using (PgSqlConnection cn = new PgSqlConnection(this.sConexion))
                {
                    PgSqlDataAdapter da = new PgSqlDataAdapter();//instanciando adaptador
                    da.SelectCommand = new PgSqlCommand();//instanciando comando
                    da.SelectCommand.CommandText = sConsulta;//asignando consulta
                    da.SelectCommand.CommandTimeout = 0;//asigando timeout en 0 
                    da.SelectCommand.CommandType = CommandType.Text;//tipo del comando
                    da.SelectCommand.Connection = cn;
                    da.Fill(dts);//llenando el dataset
                }
            }
            catch (Exception)
            {
                throw;
            }

            return dts;
        }

        /// <summary>
        /// Regresa un DataTable con la información de la tabla consultada.
        /// </summary>
        /// <param name="consulta">Querey Select</param>
        /// <param name="nombreTabla">Nombre del DataTable a retornar</param>
        /// <returns>DataTable con la información consultada</returns>
        public DataTable Consulta(string consulta)
        {
            DataTable dt = new DataTable();
            try
            {
                using (PgSqlConnection cn = new PgSqlConnection(this.sConexion))
                {
                    PgSqlDataAdapter puente = new PgSqlDataAdapter(consulta, cn);
                    puente.Fill(dt);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }

        /// <summary>
        /// Utilizar para insertar, actualizar o eliminar registros
        /// </summary>
        /// <param name="consulta">Insert, Update o Delete</param>
        /// <returns>Cantidad de registros afectados</returns>
        public int NonQuery(string consulta)
        {
            int registrosAfectados = 0;
            try
            {
                using (PgSqlConnection connection = new PgSqlConnection(this.sConexion))
                {
                    PgSqlCommand command = new PgSqlCommand(consulta, connection);
                    command.Connection.Open();
                    registrosAfectados = command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return registrosAfectados;
        }

        /// <summary>
        /// Consulta que retorna in valor del tipo que se defina en su ejecución
        /// </summary>
        /// <param name="sConsulta">Query</param>
        /// <returns>valor de tipo que fue declarado en la ejecución del método</returns>
        public T ConsultaEscalar<T>(string sConsulta)
        {
            T valorDeRetorno = default(T);

            try
            {
                using (PgSqlConnection Con = new PgSqlConnection(this.sConexion))
                {
                    Con.Open();
                    PgSqlCommand cmd = new PgSqlCommand(sConsulta, Con);
                    cmd.CommandType = CommandType.Text;
                    object valor = cmd.ExecuteScalar();
                    TryParse(valor, out valorDeRetorno);
                    Con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return valorDeRetorno;
        }

        ///<summary>
        ///Intenta castear el tipo de dato recibido al tipo de daton que se intenta contener.
        ///</summary>
        ///<typeparam name="T"></typeparam>
        ///<param name="input">objeto a castear</param>
        ///<param name="parsedValue">contenedor con tipo de dato definido</param>
        ///<param name="defaultValue">tipo de dato default</param>
        ///<returns></returns>
        private bool TryParse<T>(object input, out T parsedValue, T defaultValue = default(T))
        {
            parsedValue = defaultValue;
            bool isParsed = false;
            try
            {
                if (input != null && !string.IsNullOrWhiteSpace(input.ToString()) && input != DBNull.Value)
                {
                    var converter = TypeDescriptor.GetConverter(typeof(T));
                    if (converter != null)
                    {
                        parsedValue = (T)converter.ConvertFromString(input.ToString());
                        isParsed = true;
                    }
                }
            }
            catch (NotSupportedException)
            {
                parsedValue = defaultValue;
            }
            return isParsed;
        }

        /// <summary>
        /// Guarda la información de alta de un autorizado
        /// </summary>
        /// <param name="autorizado">Datos de la persona a registrar</param>
        /// <param name="idFoto">id de su foto en la tabla reg_fotos</param>
        /// <param name="idNinio">id de el o los niños que se ligaran a la persona</param>
        /// <returns></returns>
        public int GuardaImformacionAutorizadosConexion(CPersona autorizado, int idFoto, int idNinio)
        {
            int registrosAfectados = 0;
            try
            {
                using (PgSqlConnection connection = new PgSqlConnection(this.sConexion))
                {
                    PgSqlCommand command = new PgSqlCommand(@"INSERT INTO reg_autorizado (cnombres, capellidopat,capellidomat, id_foto, bactivo, dfechaultimaactualizacion, id_ninio, huella)
                                VALUES (@cnombres, @capellidopat, @capellidomat, @id_foto, @bactivo, @dfechaultimaactualizacion, @id_ninio, @huella)", connection);
                    command.Parameters.Add("@cnombres", PgSqlType.VarChar, autorizado.nombre.Length).Value = autorizado.nombre;
                    command.Parameters.Add("@capellidopat", PgSqlType.VarChar, autorizado.apellidoPaterno.Length).Value = autorizado.apellidoPaterno;
                    command.Parameters.Add("@capellidomat", PgSqlType.VarChar, autorizado.apellidoMaterno.Length).Value = autorizado.apellidoMaterno;
                    command.Parameters.Add("@id_foto", PgSqlType.Int).Value = idFoto;
                    command.Parameters.Add("@bactivo", PgSqlType.Bit).Value = true;
                    command.Parameters.Add("@dfechaultimaactualizacion", PgSqlType.TimeStamp).Value = DateTime.Now;
                    command.Parameters.Add("@id_ninio", PgSqlType.Int).Value = idNinio;
                    command.Parameters.Add("@huella", PgSqlType.ByteA, autorizado.imagenHuellaArray.Length).Value = autorizado.imagenHuellaArray;
                    command.Connection.Open();
                    registrosAfectados = command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return registrosAfectados;
        }

        /// <summary>
        /// Guardar la imagen en la tabla reg_fotos y regresa su id generado
        /// </summary>
        /// <param name="imagen">Imagen a guardar</param>
        /// <returns>Id generado en la tabla destino</returns>
        public int GuardaImagenConexion(byte[] imagen)
        {
            int idFoto = 0;

            try
            {
                using (PgSqlConnection connection = new PgSqlConnection(this.sConexion))
                {
                    connection.Open();
                    PgSqlCommand command = new PgSqlCommand(@"INSERT INTO reg_fotos (imagen) VALUES (@imagen) RETURNING id_foto", connection);
                    command.Parameters.Add("@imagen", PgSqlType.ByteA, imagen.Length).Value = imagen;
                    command.CommandType = CommandType.Text;
                    idFoto = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return idFoto;
        }

        public int ActualizaImagenConexion(CPersona autorizado)
        {
            int registros = 0;
            try
            {
                using (PgSqlConnection connection = new PgSqlConnection(this.sConexion))
                {
                    connection.Open();
                    PgSqlCommand command = new PgSqlCommand(@"UPDATE reg_fotos SET imagen = @imagen WHERE id_foto = @id_foto", connection);
                    command.Parameters.Add("@imagen", PgSqlType.ByteA, autorizado.imagenHuellaArray.Length).Value = autorizado.imagenHuellaArray;
                    command.Parameters.Add("@id_foto", PgSqlType.Int).Value = autorizado.id_foto;
                    command.CommandType = CommandType.Text;
                    registros = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return registros;
        }

        public byte[] ConsultaImagen(string sConsulta)
        {
            byte[] valor;
            try
            {
                using (PgSqlConnection Con = new PgSqlConnection(this.sConexion))
                {
                    Con.Open();
                    PgSqlCommand cmd = new PgSqlCommand(sConsulta, Con);
                    cmd.CommandType = CommandType.Text;
                    valor = cmd.ExecuteScalar() as byte[];
                    Con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return valor;
        }
    }
}
