using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace recipe_helper
{
    public class RecipeDataSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            SeedRecipeData(builder);
        }

        private static void SeedRecipeData(ModelBuilder builder)
        {
            builder.Entity<Recipe>().HasData(
                new Recipe
                {
                    Id = 1, Name = "Curry", Summary = "A yellow curry", Ingredients = new List<Ingredient>()});
            builder.Entity<Recipe>().HasData(
                new Recipe
                {
                    Id = 2, Name = "Vanilla Soy Milk Latte", Summary = "A three bean soup", Ingredients = new List<Ingredient>()});
            builder.Entity<Recipe>().HasData(
                new Recipe
                {
                    Id = 3, Name = "Pizza", Summary = "Popular Italish-American", Ingredients = new List<Ingredient>()});
        }
        
    }
}