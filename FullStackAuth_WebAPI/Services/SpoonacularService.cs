using System;

using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FullStackAuth_WebAPI.Models;
using Newtonsoft.Json;

public class SpoonacularService
{
    private readonly string _apiKey;
    private readonly HttpClient _httpClient;

    public SpoonacularService(string apiKey)
    {
        _apiKey = apiKey;
        _httpClient = new HttpClient();
    }

    public async Task<List<SpoonacularRecipe>> SearchRecipesByIngredientsAsync(string ingredients)
    {
        try
        {
            
            string apiUrl = $"https://api.spoonacular.com/recipes/findByIngredients?ingredients={ingredients}&apiKey={_apiKey}";

           
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
               
                string content = await response.Content.ReadAsStringAsync();
                List<SpoonacularRecipe> recipes = JsonConvert.DeserializeObject<List<SpoonacularRecipe>>(content);

                return recipes;
            }
            else
            {
             
                throw new Exception($"Spoonacular API request failed with status code {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
           
            throw ex;
        }
    }
}
