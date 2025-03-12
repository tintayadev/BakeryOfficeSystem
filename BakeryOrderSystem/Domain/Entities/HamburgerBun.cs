using System.Collections.Generic;

namespace BakeryProject.Domain.Entities
{
    public class HamburgerBun : Bread
    {
        public HamburgerBun()
        {
            Name = "Hamburger Bun";
            Price = 2.50m;
            CookingTime = 15;
            RestingTime = 30;
            FermentTime = 240;
            CookingTemperature = 180;
            BaseIngredients.Add(new Ingredient { Name = "Flour", Unit = "g", Quantity = 100 });
            BaseIngredients.Add(new Ingredient { Name = "Water", Unit = "g", Quantity = 25 });
            BaseIngredients.Add(new Ingredient { Name = "Salt", Unit = "g", Quantity = 2 });
            BaseIngredients.Add(new Ingredient { Name = "Yeast", Unit = "g", Quantity = 4 });
            BaseIngredients.Add(new Ingredient { Name = "Sugar", Unit = "g", Quantity = 6 });
            BaseIngredients.Add(new Ingredient { Name = "Egg", Unit = "g", Quantity = 10 });
            BaseIngredients.Add(new Ingredient { Name = "Milk", Unit = "g", Quantity = 5 });
            BaseIngredients.Add(new Ingredient { Name = "Butter", Unit = "g", Quantity = 6 });
            BaseIngredients.Add(new Ingredient { Name = "Sweet potato", Unit = "g", Quantity = 25 });
            BaseIngredients.Add(new Ingredient { Name = "Sesame seed", Unit = "g", Quantity = 10 });
            BaseIngredients.Add(new Ingredient { Name = "Gilding", Unit = "g", Quantity = 5 });
        }

        public override List<string> GetPreparationSteps(int quantity)
        {
            List<string> steps = new List<string>
            {
                MixIngredients()
            };
            if (quantity > 1)
                steps.Add(CutDough());
            steps.Add("Let the dough rest for 0.5 hr.");
            steps.Add(Shape());
            steps.Add("Let the dough ferment for 4 hrs.");
            steps.Add("Place sesame seed and gilding on top.");
            steps.Add(Cook());
            return steps;
        }
    }
}
