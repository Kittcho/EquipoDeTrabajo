using Devart.Data.PostgreSql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sistema_Guarderia.Conexion
{
    class CConexionPg
    {
        //Variables Globales
        private string sConexion = string.Empty;
        public String sDataBase;

        public CConexionPg()
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
    }
}
