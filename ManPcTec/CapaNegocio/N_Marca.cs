using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class N_Marca
    {
        D_Marca Marca = new D_Marca();

        public List<E_Marca> ListarMarca(string buscar)
        {
            return Marca.ListarMarca(buscar);
        }

        public void InsertarMarca(E_Marca marca)
        {
            Marca.InsertarMarca(marca);
        }

        public void EditarMarca(E_Marca marca)
        {
            Marca.EditarMarca(marca);
        }

        public void EliminarMarca(E_Marca marca)
        {
            Marca.EliminarMarca(marca);
        }
    }
}
