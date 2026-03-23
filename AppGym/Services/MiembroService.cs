using GymApp.Models;
using GymApp.Repository;

namespace GymApp.Services
{
    public class MiembroService : IMiembroService
    {
        private readonly IMiembroRepository _repo;

        public MiembroService(IMiembroRepository repo)
        {
            _repo = repo;
        }

        public void Crear(Miembro miembro) => _repo.Add(miembro);

        public List<Miembro> ObtenerTodos() => _repo.GetAll();

        public Miembro Buscar(string cedula) => _repo.GetByCedula(cedula);

        public void ActualizarTelefono(string cedula, string telefono)
            => _repo.UpdateTelefono(cedula, telefono);

        public void Eliminar(string cedula)
            => _repo.Delete(cedula);
    }
}
