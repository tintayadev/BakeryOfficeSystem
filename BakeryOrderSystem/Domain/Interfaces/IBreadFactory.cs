using BakeryProject.Domain.Entities;

namespace BakeryProject.Domain.Interfaces
{
    public interface IBreadFactory
    {
        Bread CreateBread(string breadName);
    }
}
