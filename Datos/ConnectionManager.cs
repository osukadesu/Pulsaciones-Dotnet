using System;
using System.Data.SqlClient;

namespace Datos
{
    public class ConnectionManager
    {
        public SqlConnection _conexion;
        public ConnectionManager(string _connection)
        {
            _conexion = new SqlConnection(_connection);
        }
        public void Open()
        {
            _conexion.Open();
        }
        public void Close()
        {
            _conexion.Close();
        }
    }

}
