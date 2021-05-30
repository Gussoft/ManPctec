using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class E_Categoria
    {
        private int _idCat;
        private string _codigoCat;
        private string _nombreCat;
        private string _descripcionCat;

        public int IdCat { get => _idCat; set => _idCat = value; }
        public string CodigoCat { get => _codigoCat; set => _codigoCat = value; }
        public string NombreCat { get => _nombreCat; set => _nombreCat = value; }
        public string DescripcionCat { get => _descripcionCat; set => _descripcionCat = value; }
    }
}
