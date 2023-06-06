using System.Data;
using MySql.Data.MySqlClient;

namespace Repositories
{
    internal class DAO
    {
        private MySqlConnection _connection;
        private MySqlCommand _command;
        private string _connectionString = "Server=localhost;Database=test;Uid=root;Pwd=Ignacio2014;";
        public DAO()
        {
            _command = new MySqlCommand();
            _connection = new MySqlConnection(_connectionString);
        }

        public DataTable Read(string query, MySqlParameter[]? parameters = default)
        {
            Connect();
            _command.Connection = _connection;
            _command.CommandText = query;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = _command;
            if(parameters != null )
            {
                adapter.SelectCommand.Parameters.Clear();
                adapter.SelectCommand.Parameters.AddRange(parameters);
            }
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            Disconnect();
            return dt;
        }

        public int Write(string query, MySqlParameter[] parameters)
        {
            Connect();
            _command.Connection = _connection;
            _command.CommandText = query;
            _command.Parameters.Clear();
            _command.Parameters.AddRange(parameters);
            var rowsAffected = _command.ExecuteNonQuery();
            Disconnect();
            return rowsAffected;
        }
        private void Connect()
        {
            if( _connection.State != ConnectionState.Closed)
            {
                _connection.Close();
            }
            _connection.Open();
        }
        private void Disconnect()
        {
            _connection.Close();
        }
    }
}
