using ProyectoFinal_JoanDamia.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoFinal_JoanDamia.ADO.NET
{
    public static class ADO_Venta
    {
        public static string ConnectionString = "Server=DESKTOP-54ASCEE\\MSSQLSERVER01;Database=SistemaGestion;Trusted_Connection=true;";

        public static List<Venta> GetVentas(int id)
        {
            List<Venta> ventas = new List<Venta>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Connection.Open();
                    sqlCommand.CommandText = @"select * from Venta
                                                where IdUsuario = @idUsuario;";

                    sqlCommand.Parameters.AddWithValue("@idUsuario", id);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = sqlCommand;
                    DataTable table = new DataTable();
                    dataAdapter.Fill(table);

                    foreach (DataRow row in table.Rows)
                    {
                        Venta venta = new Venta();
                        venta.Id = Convert.ToInt32(row["Id"]);
                        venta.Comentarios = row["Comentarios"].ToString();
                        venta.IdUsuario = Convert.ToInt32(row["IdUsuario"]);

                        ventas.Add(venta);
                    }
                    sqlCommand.Connection.Close();
                }
            }
            return ventas;
        }

        public static void InsertVenta(List<Producto> productos, int IdUsuario)
        {
            Venta venta = new Venta();

            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Connection.Open();
            sqlCommand.CommandText = @"INSERT INTO Venta
                                ([Comentarios]
                                ,[IdUsuario])
                                VALUES
                                (@Comentarios,
                                    @IdUsuario)";

            sqlCommand.Parameters.AddWithValue("@Comentarios", "");
            sqlCommand.Parameters.AddWithValue("@IdUsuario", IdUsuario);

            sqlCommand.ExecuteNonQuery();
            venta.Id = ADO_GetId.Get(sqlCommand);
            venta.IdUsuario = IdUsuario;

            foreach (Producto producto in productos)
            {
                sqlCommand.CommandText = @"INSERT INTO ProductoVendido
                                ([Stock]
                                ,[IdProducto]
                                ,[IdVenta])
                                VALUES
                                (@Stock,
                                @IdProducto,
                                @IdVenta)";

                sqlCommand.Parameters.AddWithValue("@Stock", producto.Stock);
                sqlCommand.Parameters.AddWithValue("@IdProducto", producto.Id);
                sqlCommand.Parameters.AddWithValue("@IdVenta", venta.Id);

                sqlCommand.ExecuteNonQuery();
                sqlCommand.Parameters.Clear();

                sqlCommand.CommandText = @" UPDATE Producto
                                                SET 
                                                Stock = Stock - @Stock
                                                WHERE id = @IdProducto";

                sqlCommand.Parameters.AddWithValue("@Stock", producto.Stock);
                sqlCommand.Parameters.AddWithValue("@IdProducto", producto.Id);

                sqlCommand.ExecuteNonQuery();
                sqlCommand.Parameters.Clear();
            }
            sqlCommand.Connection.Close();
        }

        public static bool EliminarVenta(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Connection.Open();

                    sqlCommand.CommandText = @" DELETE 
                                                    Venta
                                                WHERE 
                                                    Id = @ID
                                            ";

                    int recordsAffected = sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    if (recordsAffected != 1)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }
    }
}
    
