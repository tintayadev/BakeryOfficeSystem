using System.Collections.Generic;

namespace BakeryProject.Domain.Entities
{
    public class Baguette : Bread
    {
        public Baguette()
        {
            Name = "Baguette";
            Price = 3.50m;
            CookingTime = 15;
            RestingTime = 30; 
            FermentTime = 1440;
            CookingTemperature = 270;
            BaseIngredients.Add(new Ingredient { Id = 1, Name = "Flour", Unit = "g", Quantity = 280 });
            BaseIngredients.Add(new Ingredient { Id = 2, Name = "Water", Unit = "g", Quantity = 210 });
            BaseIngredients.Add(new Ingredient { Id = 3, Name = "Salt", Unit = "g", Quantity = 10 });
            BaseIngredients.Add(new Ingredient { Id = 4, Name = "Yeast", Unit = "g", Quantity = 5 });
        }

        public override List<string> GetPreparationSteps(int quantity)
        {
            List<string> steps = new List<string>
            {
                MixIngredients(),
                "Let the dough rest for 0.5 hr.",
                "Fold the dough.",
                "Let the dough rest for 0.5 hr.",
                "Fold the dough.",
                "Let the dough ferment for 1 day."
            };

            if (quantity > 1)
                steps.Add(CutDough());

            steps.Add(Shape());
            steps.Add("Let the dough rest for 0.5 hr.");
            steps.Add(Cook());
            return steps;
        }
    }
}
