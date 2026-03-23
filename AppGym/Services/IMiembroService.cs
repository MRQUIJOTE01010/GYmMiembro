using GymApp.Models;

namespace GymApp.Services
{
    public interface IMiembroService
    {
        void Crear(Miembro miembro);
        List<Miembro> ObtenerTodos();
        Miembro Buscar(string cedula);
        void ActualizarTelefono(string cedula, string telefono);
        void Eliminar(string cedula);
    }
}
