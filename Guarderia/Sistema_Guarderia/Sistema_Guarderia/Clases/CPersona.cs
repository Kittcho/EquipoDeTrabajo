using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Guarderia.Clases
{
    public class CPersona
    {
        public byte estado { get; set; }//1 = autorizado/nuevo, 0 = bloqueado
        public int id_persona { get; set; }
        public int id_foto { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public long telefono { get; set; }
        public string calle { get; set; }
        public int numeroCasa { get; set; }
        public string colonia { get; set; }
        public int codigoPostal { get; set; }
        public string ciudad { get; set; }
        public byte[] fotografiaArray { get; set; }
        public byte[] imagenHuellaArray { get; set; }
        public Image fotografiaImage { get; set; }
        //Datos niños
        public int id_ninio { get; set; }
    }
}
