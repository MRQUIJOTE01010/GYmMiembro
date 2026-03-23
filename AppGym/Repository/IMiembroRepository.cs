using GymApp.Models;

namespace GymApp.Repository
{
    public interface IMiembroRepository
    {
        void Add(Miembro miembro);
        List<Miembro> GetAll();
        Miembro GetByCedula(string cedula);
        void UpdateTelefono(string cedula, string telefono);
        void Delete(string cedula);
    }
}
