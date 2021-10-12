using System.ComponentModel.DataAnnotations;
using Castle.Components.DictionaryAdapter;

namespace recipe_helper
{
    public class Ingredient
    {
        public Ingredient(int Amount, string Food)
        { 
            this.Amount = Amount;
            this.Food = Food;
            
        }

        public Ingredient()
        {
        }

        public int Amount { get; set; }
        public string Food { get; set; }
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        
        public int RecipeId { get; set; }
        
        public virtual Recipe Recipe { get; set; }
        
    }
}