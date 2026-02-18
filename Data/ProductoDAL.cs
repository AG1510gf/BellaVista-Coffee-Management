using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

using BellaVista.Web.Models; // para usar la clase Producto

namespace BellaVista.Web.Data
{
    public class ProductoDAL
    {
        private readonly string _connectionString;

        public ProductoDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // LISTAR
        public List<Producto> Listar()
        {
            var lista = new List<Producto>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_ListarProductosActivos", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Producto
                    {
                        ProductoID = Convert.ToInt32(reader["ProductoID"]),
                        NombreProducto = reader["NombreProducto"].ToString(),
                        Presentacion = reader["Presentacion"].ToString(),
                        PrecioUnitario = Convert.ToDecimal(reader["PrecioUnitario"]),
                        CategoriaID = Convert.ToInt32(reader["CategoriaID"])
                    });
                }
            }

            return lista;
        }

        // INSERTAR
        public void Insertar(Producto producto)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarProducto", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NombreProducto", producto.NombreProducto);
                cmd.Parameters.AddWithValue("@CategoriaID", producto.CategoriaID);
                cmd.Parameters.AddWithValue("@Presentacion", producto.Presentacion);
                cmd.Parameters.AddWithValue("@PrecioUnitario", producto.PrecioUnitario);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ACTUALIZAR
        public void Actualizar(Producto producto)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_ActualizarProducto", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductoID", producto.ProductoID);
                cmd.Parameters.AddWithValue("@NombreProducto", producto.NombreProducto);
                cmd.Parameters.AddWithValue("@CategoriaID", producto.CategoriaID);
                cmd.Parameters.AddWithValue("@Presentacion", producto.Presentacion);
                cmd.Parameters.AddWithValue("@PrecioUnitario", producto.PrecioUnitario);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ELIMINAR
        public void Eliminar(int productoID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarProducto", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductoID", productoID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}