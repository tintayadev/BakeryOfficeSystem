using System.Collections.Generic;

namespace BakeryProject.Domain.Entities
{
    public class PastryChef
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Specialties { get; set; } = new List<string>();
    }
}
