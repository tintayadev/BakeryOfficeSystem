using System.Collections.Generic;

namespace BakeryProject.Domain.Entities
{
    public class MilkBread : Bread
    {
        public MilkBread()
        {
            Name = "Milk Bread";
            Price = 4.50m;
            CookingTime = 15;
            RestingTime = 10;
            FermentTime = 240;
            CookingTemperature = 180;
            BaseIngredients.Add(new Ingredient { Name = "Flour", Unit = "g", Quantity = 55 });
            BaseIngredients.Add(new Ingredient { Name = "Water", Unit = "g", Quantity = 25 });
            BaseIngredients.Add(new Ingredient { Name = "Salt", Unit = "g", Quantity = 1 });
            BaseIngredients.Add(new Ingredient { Name = "Yeast", Unit = "g", Quantity = 3 });
            BaseIngredients.Add(new Ingredient { Name = "Sugar", Unit = "g", Quantity = 6 });
            BaseIngredients.Add(new Ingredient { Name = "Egg", Unit = "g", Quantity = 10 });
            BaseIngredients.Add(new Ingredient { Name = "Milk", Unit = "g", Quantity = 20 });
            BaseIngredients.Add(new Ingredient { Name = "Butter", Unit = "g", Quantity = 10 });
            BaseIngredients.Add(new Ingredient { Name = "Honey", Unit = "g", Quantity = 2 });
            BaseIngredients.Add(new Ingredient { Name = "Lemon zest", Unit = "g", Quantity = 1 });
            BaseIngredients.Add(new Ingredient { Name = "Vanilla essence", Unit = "g", Quantity = 1 });
        }

        public override List<string> GetPreparationSteps(int quantity)
        {
            var steps = new List<string>
            {
                MixIngredients()
            };

            if (quantity > 1)
            {
                steps.Add(CutDough());
            }
            steps.Add("Let the dough rest for 10 min.");
            steps.Add(Shape());
            steps.Add("Let the dough ferment for 4 hrs.");
            steps.Add(Cook());
            return steps;
        }
    }
}
