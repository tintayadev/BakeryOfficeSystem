using System.Collections.Generic;

namespace BakeryProject.Domain.Entities
{
    public class WhiteBread : Bread
    {
        public WhiteBread()
        {
            Name = "White Bread";
            Price = 4.00m;
            CookingTime = 30;
            RestingTime = 60;
            FermentTime = 240;
            CookingTemperature = 180;
            BaseIngredients.Add(new Ingredient { Name = "Flour", Unit = "g", Quantity = 1000 });
            BaseIngredients.Add(new Ingredient { Name = "Water", Unit = "g", Quantity = 280 });
            BaseIngredients.Add(new Ingredient { Name = "Salt", Unit = "g", Quantity = 20 });
            BaseIngredients.Add(new Ingredient { Name = "Yeast", Unit = "g", Quantity = 20 });
            BaseIngredients.Add(new Ingredient { Name = "Sugar", Unit = "g", Quantity = 80 });
            BaseIngredients.Add(new Ingredient { Name = "Milk", Unit = "g", Quantity = 60 });
            BaseIngredients.Add(new Ingredient { Name = "Butter", Unit = "g", Quantity = 100 });
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
            steps.Add("Let the dough ferment for 4 hrs.");
            steps.Add(Shape());
            steps.Add("Let the dough rest for 1 hr.");
            steps.Add(Cook());
            return steps;
        }
    }
}
