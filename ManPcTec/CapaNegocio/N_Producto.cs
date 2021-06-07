using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class N_Producto
    {
        D_Producto pro = new D_Producto();
        E_Producto epro = new E_Producto();
        public DataTable ListarProductos()
        {
            return pro.ListarProductos();
        }

        public DataTable BuscarProducto(string buscar)
        {
            epro.Buscar = buscar;
            return pro.BuscarProducto(epro);
        }

        public void InsertarProducto(E_Producto producto)
        {
            pro.InsertarProducto(producto);
        }

        public void EditarProducto(E_Producto producto)
        {
            pro.EditarProducto(producto);
        }

        public void EliminarProducto(int id)
        {
            pro.EliminarProducto(id);
        }
    }
}
