using System;
using System.Data.SqlClient;

namespace ProyectoFinal_JoanDamia.ADO.NET
{
    public static class ADO_GetId
    {
        public static int Get(SqlCommand sqlCommand)
        {
            sqlCommand.CommandText = "Select @@IDENTITY";
            sqlCommand.Parameters.Clear();

            object objID = sqlCommand.ExecuteScalar();

            int id = Convert.ToInt32(objID);

            return id;
        }
    }
}
