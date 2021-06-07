using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
namespace CapaDatos
{
    public class D_Producto
    {
        SqlConnection conn = new SqlConnection("Server=.;database=Mantenimiento;Integrated Security=True");

        public DataTable ListarProductos()
        {
            DataTable tabla = new DataTable();
            SqlDataReader read;
            SqlCommand cmd = new SqlCommand("SP_LISTARPRODUCTOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            read = cmd.ExecuteReader();
            tabla.Load(read);

            read.Close();
            conn.Close();
            return tabla;
        }

        public DataTable BuscarProducto(E_Producto producto)
        {
            DataTable table = new DataTable();
            SqlCommand cmd = new SqlCommand("SP_BUSCARPRODUCTOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", producto.Buscar);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);

            conn.Close();
            return table;
        }

        public void EliminarProducto(int id)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINARPRODUCTOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            cmd.Parameters.AddWithValue("@IDPRO", id);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void InsertarProducto(E_Producto producto)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTARPRODUCTOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            cmd.Parameters.AddWithValue("@NOMBRE", producto.Nombre);
            cmd.Parameters.AddWithValue("@PRECIOC", producto.Precioc);
            cmd.Parameters.AddWithValue("@PRECIOV", producto.Preciov);
            cmd.Parameters.AddWithValue("@STOCK", producto.Stock);
            cmd.Parameters.AddWithValue("@IDCAT", producto.Idcategoria);
            cmd.Parameters.AddWithValue("@IDMAR", producto.Idmarca);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void EditarProducto(E_Producto producto)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITARPRODUCTOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            cmd.Parameters.AddWithValue("@IDPRO", producto.Idproducto);
            cmd.Parameters.AddWithValue("@NOMBRE", producto.Nombre);
            cmd.Parameters.AddWithValue("@PRECIOC", producto.Precioc);
            cmd.Parameters.AddWithValue("@PRECIOV", producto.Preciov);
            cmd.Parameters.AddWithValue("@STOCK", producto.Stock);
            cmd.Parameters.AddWithValue("@IDCAT", producto.Idcategoria);
            cmd.Parameters.AddWithValue("@IDMAR", producto.Idmarca);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
