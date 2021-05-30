using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class N_Categoria
    {
        D_Categoria Categoria = new D_Categoria();

        public List<E_Categoria> ListarCategoria(string buscar)
        {
            return Categoria.ListarCategoria(buscar);
        }

        public void InsertarCategoria(E_Categoria categoria)
        {
            Categoria.InsertarCategoriaa(categoria);
        }

        public void EditarCategoria(E_Categoria categoria)
        {
            Categoria.EditarCategoria(categoria);
        }

        public void EliminarCategoria(E_Categoria categoria)
        {
            Categoria.EliminarCategoria(categoria);
        }
    }
}
