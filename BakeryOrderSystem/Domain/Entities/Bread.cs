using System.Collections.Generic;

namespace BakeryProject.Domain.Entities
{
    public abstract class Bread
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<Ingredient> BaseIngredients { get; set; } = new List<Ingredient>();
        public int CookingTime { get; set; }
        public int RestingTime { get; set; }
        public int FermentTime { get; set; } 
        public int CookingTemperature { get; set; } 

        public abstract List<string> GetPreparationSteps(int quantity);

        public virtual string MixIngredients() => $"Mixing ingredients for {Name}.";
        public virtual string CutDough() => $"Cutting the dough for {Name}.";
        public virtual string Rest() => $"Letting the dough rest for {Name}.";
        public virtual string Shape() => $"Shaping the dough for {Name}.";
        public virtual string Ferment() => $"Fermenting the dough for {Name}.";
        public virtual string Cook() => $"Cooking {Name} at {CookingTemperature}º for {CookingTime} minutes.";
    }
}
