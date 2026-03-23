// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using GymApp.Database;
using GymApp.Repository;
using GymApp.Services;
using GymApp.Screens;

class Program
{
    static void Main()
    {
        var db = new DbContext();
        IMiembroRepository repo = new MiembroRepository(db);
        IMiembroService service = new MiembroService(repo);

        var menu = new MenuScreen(service);
        menu.Mostrar();
    }
}

