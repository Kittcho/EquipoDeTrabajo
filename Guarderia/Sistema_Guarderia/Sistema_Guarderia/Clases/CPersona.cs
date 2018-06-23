using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Guarderia.Clases
{
    class CPersona
    {
        public byte estado { get; set; }//1 = autorizado/nuevo, 0 = bloqueado
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public long telefono { get; set; }
        public string calle { get; set; }
        public int numeroCasa { get; set; }
        public string colonia { get; set; }
        public int codigoPostal { get; set; }
        public string ciudad { get; set; }
        public byte[] fotografia { get; set; }
        public byte[] imagenHuella { get; set; }
    }
}
