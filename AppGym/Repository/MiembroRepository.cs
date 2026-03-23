using GymApp.Models;
using GymApp.Database;
using System.Data.SQLite;

namespace GymApp.Repository
{
    public class MiembroRepository : IMiembroRepository
    {
        private readonly DbContext _context;

        public MiembroRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(Miembro miembro)
        {
            using var conn = _context.GetConnection();
            conn.Open();

            string query = "INSERT INTO Miembros (NombreCompleto, Cedula, Telefono) VALUES (@nombre, @cedula, @telefono)";

            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@nombre", miembro.NombreCompleto);
            cmd.Parameters.AddWithValue("@cedula", miembro.Cedula);
            cmd.Parameters.AddWithValue("@telefono", miembro.Telefono);

            cmd.ExecuteNonQuery();
        }

        public List<Miembro> GetAll()
        {
            var lista = new List<Miembro>();

            using var conn = _context.GetConnection();
            conn.Open();

            string query = "SELECT * FROM Miembros";

            using var cmd = new SQLiteCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Miembro
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    NombreCompleto = reader["NombreCompleto"].ToString()!,
                    Cedula = reader["Cedula"].ToString()!,
                    Telefono = reader["Telefono"].ToString()!
                });
            }

            return lista;
        }

        public Miembro GetByCedula(string cedula)
        {
            using var conn = _context.GetConnection();
            conn.Open();

            string query = "SELECT * FROM Miembros WHERE Cedula = @cedula";

            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@cedula", cedula);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Miembro
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    NombreCompleto = reader["NombreCompleto"].ToString()!,
                    Cedula = reader["Cedula"].ToString()!,
                    Telefono = reader["Telefono"].ToString()!
                };
            }

            return null;
        }

        public void UpdateTelefono(string cedula, string telefono)
        {
            using var conn = _context.GetConnection();
            conn.Open();

            string query = "UPDATE Miembros SET Telefono = @telefono WHERE Cedula = @cedula";

            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@cedula", cedula);

            cmd.ExecuteNonQuery();
        }

        public void Delete(string cedula)
        {
            using var conn = _context.GetConnection();
            conn.Open();

            string query = "DELETE FROM Miembros WHERE Cedula = @cedula";

            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@cedula", cedula);

            cmd.ExecuteNonQuery();
        }
    }
}

