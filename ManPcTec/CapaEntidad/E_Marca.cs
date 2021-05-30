using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class E_Marca
    {
        private int _idMar;
        private string _codigoMar;
        private string _nombreMar;
        private string _descripcionMar;

        public int IdMar { get => _idMar; set => _idMar = value; }
        public string CodigoMar { get => _codigoMar; set => _codigoMar = value; }
        public string NombreMar { get => _nombreMar; set => _nombreMar = value; }
        public string DescripcionMar { get => _descripcionMar; set => _descripcionMar = value; }
    }
}
