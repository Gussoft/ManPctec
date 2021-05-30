using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidad;

namespace CapaDatos
{
    public class D_Marca
    {
        SqlConnection conn = new SqlConnection("Server=.;database=Mantenimiento;Integrated Security=True");

        public List<E_Marca> ListarMarca(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCARMARCA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);
            LeerFilas = cmd.ExecuteReader();
            List<E_Marca> Listar = new List<E_Marca>();
            while (LeerFilas.Read())
            {
                Listar.Add(new E_Marca
                {
                    IdMar = LeerFilas.GetInt32(0),
                    CodigoMar = LeerFilas.GetString(1),
                    NombreMar = LeerFilas.GetString(2),
                    DescripcionMar = LeerFilas.GetString(3)
                });
            }
            conn.Close();
            return Listar;
        }
        public void InsertarMarca(E_Marca marca)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTARMARCA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            cmd.Parameters.AddWithValue("@NOMBRE", marca.NombreMar);
            cmd.Parameters.AddWithValue("@DESCRIPCION", marca.DescripcionMar);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void EditarMarca(E_Marca marca)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITARMARCA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            cmd.Parameters.AddWithValue("@IDMARCA", marca.IdMar);
            cmd.Parameters.AddWithValue("@NOMBRE", marca.NombreMar);
            cmd.Parameters.AddWithValue("@DESCRIPCION", marca.DescripcionMar);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void EliminarMarca(E_Marca marca)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINARMARCA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            cmd.Parameters.AddWithValue("@IDMARCA", marca.IdMar);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
