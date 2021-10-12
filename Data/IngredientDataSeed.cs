using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace recipe_helper
{
    public class IngredientDataSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            SeedIngredientData(builder);
        }

        private static void SeedIngredientData(ModelBuilder builder)
        {
            builder.Entity<Ingredient>().HasData(
                new Ingredient
                {
                    Id = 1, Amount = 2, Food = "tbs curry powder", RecipeId = 1
                });
            builder.Entity<Ingredient>().HasData(
                new Ingredient
                {
                    Id = 2, Amount = 5, Food = "cups of rice", RecipeId = 1
                });
            builder.Entity<Ingredient>().HasData(
                new Ingredient
                {
                    Id = 3, Amount = 2, Food = "pounds of chicken", RecipeId = 1
                });
            builder.Entity<Ingredient>().HasData(
                new Ingredient
                {
                    Id = 4, Amount = 1, Food = "tsp of salt", RecipeId = 1
                });
            builder.Entity<Ingredient>().HasData(
                new Ingredient
                {
                    Id = 5, Amount = 1, Food = "vanilla bean", RecipeId = 2
                });
            builder.Entity<Ingredient>().HasData(
                new Ingredient
                {
                    Id = 6, Amount = 3, Food = "soy beans", RecipeId = 2
                });
            builder.Entity<Ingredient>().HasData(
                new Ingredient
                {
                    Id = 7, Amount = 68, Food = "coffee beans", RecipeId = 2
                });
            builder.Entity<Ingredient>().HasData(
                new Ingredient
                {
                    Id = 8, Amount = 1, Food = "cup of water", RecipeId = 2
                });
            builder.Entity<Ingredient>().HasData(
                new Ingredient
                {
                    Id = 9, Amount = 1, Food = "frozen pizza", RecipeId = 3
                });
        }
    }
}