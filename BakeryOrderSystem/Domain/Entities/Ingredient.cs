using Microsoft.EntityFrameworkCore;

namespace BakeryProject.Domain.Entities
{
    [Owned]
    public class Ingredient
    {
        public string Name { get; set; }
        public string Unit { get; set; }
        public decimal Quantity { get; set; }
    }
}
