using BakeryProject.Domain.Entities;

namespace BakeryProject.Domain.Interfaces
{
    public interface IBreadFactory
    {
        Bread CreateBread(int choice);
    }
}
