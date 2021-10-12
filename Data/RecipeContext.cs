using Microsoft.EntityFrameworkCore;

namespace recipe_helper
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options)
            : base(options)
        
        {
        }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            RecipeDataSeed.Seed(builder);
            IngredientDataSeed.Seed(builder);

            
            builder.Entity<Ingredient>().HasOne<Recipe>(x => x.Recipe).WithMany(x => x.Ingredients).HasForeignKey(x => x.RecipeId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseLazyLoadingProxies();
            options.UseSqlServer(
                "Server=localhost;Integrated Security=false;Initial Catalog='RecipeHelper';User Id='sa';Password='notSuperSecret!';application name=RecipeHelper");
        }
    }
}