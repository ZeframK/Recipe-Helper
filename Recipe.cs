using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace recipe_helper
{
    public class Recipe
    {
        public Recipe(string name, string summary, List<Ingredient> ingredient)
        {
            this.Name = name;
            this.Summary = summary;
            this.Ingredients = ingredient;
        }

        public Recipe(string name, string summary)
        {
            this.Name = name;
            this.Summary = summary;
        }
        
        // This should not be necessary
        public Recipe(){}
        
        public string Name { get; set; }
        public string Summary { get; set; }
        
        
        public virtual ICollection<Ingredient> Ingredients
        {
            get; set;
        }

        [System.ComponentModel.DataAnnotations.Key]
        public int Id {
            get;
            set;
        }
        public void AddToIngredients(int amount, string food)
        {
            var ingredient = new Ingredient(amount, food);
            
            this.Ingredients.Add(ingredient);
        }
    }
}