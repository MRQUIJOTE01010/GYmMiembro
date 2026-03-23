using System.Data.SQLite;

namespace GymApp.Database
{
    public class DbContext
    {
        private readonly string _connectionString;

        public DbContext()
        {
            _connectionString = "Data Source=gym.db;";
            Inicializar();
        }

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(_connectionString);
        }

        private void Inicializar()
        {
            using var connection = GetConnection();
            connection.Open();

            string query = @"CREATE TABLE IF NOT EXISTS Miembros (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            NombreCompleto TEXT,
                            Cedula TEXT,
                            Telefono TEXT)";

            using var command = new SQLiteCommand(query, connection);
            command.ExecuteNonQuery();
        }
    }
}

