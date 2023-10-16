using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using FullStackAuth_WebAPI.Models;
using FullStackAuth_WebAPI.DataTransferObjects;

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/recipes")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly SpoonacularService _spoonacularService;

        public RecipeController(SpoonacularService spoonacularService)
        {
            _spoonacularService = spoonacularService;
        }

        [HttpPost("search")]
        public async Task<IActionResult> SearchRecipes([FromBody] IngredientsRequestDto ingredientsRequestDto)
        {
            try
            {
               
                var ingredients = string.Join(",", ingredientsRequestDto.Ingredients);
                var recipes = await _spoonacularService.SearchRecipesByIngredientsAsync(ingredients);

                return Ok(recipes);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
