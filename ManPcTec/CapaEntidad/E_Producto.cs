using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class E_Producto
    {
        private int _idproducto;
        private string _codigo;
        private string _nombre;
        private int _idcategoria;
        private int _idmarca;
        private decimal _precioc;
        private decimal _preciov;
        private int _stock;
        private string buscar;

        public int Idproducto { get => _idproducto; set => _idproducto = value; }
        public string Codigo { get => _codigo; set => _codigo = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public int Idcategoria { get => _idcategoria; set => _idcategoria = value; }
        public int Idmarca { get => _idmarca; set => _idmarca = value; }
        public decimal Precioc { get => _precioc; set => _precioc = value; }
        public decimal Preciov { get => _preciov; set => _preciov = value; }
        public int Stock { get => _stock; set => _stock = value; }
        public string Buscar { get => buscar; set => buscar = value; }
    }
}
