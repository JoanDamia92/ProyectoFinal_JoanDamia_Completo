using ProyectoFinal_JoanDamia.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoFinal_JoanDamia.ADO.NET
{
    public static class ADO_ProductoVendido
    {
        public static string ConnectionString = "Server=DESKTOP-54ASCEE\\MSSQLSERVER01;Database=SistemaGestion;Trusted_Connection=true;";

        public static List<ProductoVendido> GetProductosVendidos(int id)
        {
            List<ProductoVendido> listProductosVendidos = new List<ProductoVendido>();
            List<Producto> listProductos = ADO_Producto.GetProductos(id);

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {

                    
                    foreach (Producto producto in listProductos)
                    {
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.Connection.Open();
                        sqlCommand.CommandText = @"select* from ProductoVendido
                                                where IdProducto = @idProducto";
                        
                        sqlCommand.Parameters.AddWithValue("@idProducto", producto.Id);
                        

                        SqlDataAdapter dataAdapter = new SqlDataAdapter();
                        dataAdapter.SelectCommand = sqlCommand;
                        DataTable table = new DataTable();
                        dataAdapter.Fill(table);
                        sqlCommand.Parameters.Clear();

                        foreach (DataRow row in table.Rows)
                        {
                            ProductoVendido productoVendido = new ProductoVendido();
                            productoVendido.Id = Convert.ToInt32(row["Id"]);
                            productoVendido.Stock = Convert.ToInt32(row["Stock"]);
                            productoVendido.IdProducto = Convert.ToInt32(row["IdProducto"]);
                            productoVendido.IdVenta = Convert.ToInt32(row["IdVenta"]);

                            listProductosVendidos.Add(productoVendido);
                        }
                        sqlCommand.Connection.Close();
                    }
                    
                }
            }
            return listProductosVendidos;
        }
    }
    
}
