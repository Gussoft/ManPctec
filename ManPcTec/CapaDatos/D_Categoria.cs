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
    public class D_Categoria
    {
        //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
        SqlConnection conn = new SqlConnection("Server=.;database=Mantenimiento;Integrated Security=True");
        public List<E_Categoria> ListarCategoria(string buscar)
        {
           
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCARCATEGORIA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);
            LeerFilas = cmd.ExecuteReader();
            List<E_Categoria> Listar = new List<E_Categoria>();
            while (LeerFilas.Read())
            {
                Listar.Add(new E_Categoria
                {
                    IdCat = LeerFilas.GetInt32(0),
                    CodigoCat = LeerFilas.GetString(1),
                    NombreCat = LeerFilas.GetString(2),
                    DescripcionCat = LeerFilas.GetString(3)
                });
            }
            conn.Close();
            LeerFilas.Close();

            return Listar;
        }

        public void InsertarCategoriaa(E_Categoria categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTARCATEGORIA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            cmd.Parameters.AddWithValue("@NOMBRE", categoria.NombreCat);
            cmd.Parameters.AddWithValue("@DESCRIPCION", categoria.DescripcionCat);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void EditarCategoria(E_Categoria categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITARCATEGORIA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            cmd.Parameters.AddWithValue("@IDCATEGORIA", categoria.IdCat);
            cmd.Parameters.AddWithValue("@NOMBRE", categoria.NombreCat);
            cmd.Parameters.AddWithValue("@DESCRIPCION", categoria.DescripcionCat);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void EliminarCategoria(E_Categoria categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINARCATEGORIA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            cmd.Parameters.AddWithValue("@IDCATEGORIA", categoria.IdCat);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
