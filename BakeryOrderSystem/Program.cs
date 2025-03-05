using BakeryProject.UI;
using BakeryProject.Application.Services;
using BakeryProject.Infrastructure;
using BakeryProject.Domain.Interfaces;

namespace BakeryProject
{
    class Program
    {
        static void Main(string[] args)
        {
            IBakeryRepository repository = new InMemoryBakeryRepository();
            IBakeryService bakeryService = new BakeryService(repository);
            IBreadFactory breadFactory = new BreadFactory();
            ConsoleUI ui = new ConsoleUI(bakeryService, breadFactory);
            ui.Run();
        }
    }
}
