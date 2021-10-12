using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace recipe_helper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {
        
        // private readonly ILogger<RecipeController> _logger;
        // public RecipeController(ILogger<RecipeController> logger)
        // {
        //     _logger = logger;
        // }
        //
        // SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        // builder.DataSource = '<'
        
        private readonly RecipeContext _context;
        public RecipeController(RecipeContext context, ILogger<RecipeController> logger)
        {
            this._context = context;
            // _logger = logger;
        }
        // (C)
        [HttpPost]
        public async Task<IActionResult> AddRecipe(Recipe recipe)
        {
            // await ProcessFormValidations(recipe);
            // if (!ModelState.IsValid)
            // {
            //     return GetModelStateErrorResponse();
            // }
            this._context.Recipes.Add(recipe);
            await this._context.SaveChangesAsync();
            return CreatedAtAction(nameof(AddRecipe), recipe);
        }
        
        
        // (R)
        [HttpGet]
        public async Task<object> GetRecipes()
        {
            //return await _context.Recipes.Include(recipe => recipe.Ingredients).ToListAsync();

            return _context.Recipes.Select(recipe => new
            {
                recipe.Id,
                recipe.Name,
                recipe.Summary,
                Ingredients = recipe.Ingredients.Select(ingredient => new 
                    {
                        ingredient.Id,
                        ingredient.Amount,
                        ingredient.Food
                    })
            });
        }

        // GET: recipe/{id}
        [HttpGet("{id}")]
        public async Task<object> GetRecipeById(int id)
        {
            var recipe = await this._context.Recipes
                .FirstOrDefaultAsync(r => r.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }
            
            return new
            {
                recipe.Id, 
                recipe.Name, 
                recipe.Summary, 
                Ingredients = recipe.Ingredients.Select(ingredient => new
                {
                    ingredient.Id,
                    ingredient.Amount,
                    ingredient.Food
                })
            };
        }
        
        // (U) PUT: recipe/{id}
        [HttpPut]
        public async Task<IActionResult> UpdateRecipe([FromBody] Recipe recipe)
        {
            
            await ProcessRecipeValidation(recipe);
            _context.Entry(recipe).State = EntityState.Modified;
            _context.Update(recipe);

            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Problem();
            }
        }

        // (D) Delete recipe/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Recipe>> DeleteRecipe(int id)
        {
            var recipe = await _context.Recipes
                .FirstOrDefaultAsync(r => r.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();

            return Ok(recipe);
        }
        
        //TODO Complete Recipe validation
        private Task ProcessRecipeValidation(Recipe recipe)
        {
            return Task.CompletedTask;
        }
    }
}
