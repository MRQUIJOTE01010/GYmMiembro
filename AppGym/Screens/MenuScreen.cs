using Spectre.Console;
using GymApp.Services;
using GymApp.Models;

namespace GymApp.Screens
{
    public class MenuScreen
    {
        private readonly IMiembroService _service;

        public MenuScreen(IMiembroService service)
        {
            _service = service;
        }

        public void Mostrar()
        {
            while (true)
            {
                var opcion = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("[green]MENÚ GIMNASIO[/]")
                    .AddChoices("Registrar", "Listar", "Buscar", "Actualizar", "Eliminar", "Salir"));

                switch (opcion)
                {
                    case "Registrar":
                        Registrar();
                        break;

                    case "Listar":
                        Listar();
                        break;

                    case "Buscar":
                        Buscar();
                        break;

                    case "Actualizar":
                        Actualizar();
                        break;

                    case "Eliminar":
                        Eliminar();
                        break;

                    case "Salir":
                        return;
                }
            }
        }

        private void Registrar()
        {
            var nombre = AnsiConsole.Ask<string>("Nombre:");
            var cedula = AnsiConsole.Ask<string>("Cédula:");
            var telefono = AnsiConsole.Ask<string>("Teléfono:");

            _service.Crear(new Miembro
            {
                NombreCompleto = nombre,
                Cedula = cedula,
                Telefono = telefono
            });
        }

            private void Listar()
{
    var miembros = _service.ObtenerTodos();

    var table = new Table();

    table.Border(TableBorder.Rounded);
    table.Title("[yellow]Lista de Miembros[/]");

    table.AddColumn("[blue]Nombre[/]");
    table.AddColumn("[green]Cédula[/]");
    table.AddColumn("[red]Teléfono[/]");

    foreach (var m in miembros)
    {
        table.AddRow(
            m.NombreCompleto,
            m.Cedula,
            m.Telefono
        );
    }

    AnsiConsole.Write(table);
}

        

        private void Buscar()
        {
            var cedula = AnsiConsole.Ask<string>("Cédula:");
            var m = _service.Buscar(cedula);

            if (m != null)
                AnsiConsole.WriteLine($"{m.NombreCompleto} - {m.Telefono}");
            else
                AnsiConsole.WriteLine("No encontrado");
        }

        private void Actualizar()
        {
            var cedula = AnsiConsole.Ask<string>("Cédula:");
            var telefono = AnsiConsole.Ask<string>("Nuevo teléfono:");

            _service.ActualizarTelefono(cedula, telefono);
        }

        private void Eliminar()
        {
            var cedula = AnsiConsole.Ask<string>("Cédula:");
            _service.Eliminar(cedula);
        }
    }
}
