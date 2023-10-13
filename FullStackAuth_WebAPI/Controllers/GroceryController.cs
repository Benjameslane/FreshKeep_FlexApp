using Microsoft.AspNetCore.Mvc;
using FullStackAuth_WebAPI.Models;
using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceryController : ControllerBase
    {
        private readonly ApplicationDbContext _context; 

        public GroceryController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> CreateGroceryItem([FromBody] UserFoodItem userFoodItem)
        {
            if (userFoodItem == null)
            {
                return BadRequest("Invalid data. Please provide valid grocery item data.");
            }

            try
            {
                _context.UserFoodItems.Add(userFoodItem);
                await _context.SaveChangesAsync();

                return Ok("Grocery item created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("user/{userId}")]
        public IActionResult GetFoodItemsForUser(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("Invalid user ID.");
            }

            var currentDate = DateTime.UtcNow;
            var oneWeekFromNow = currentDate.AddDays(7);

            var expiringFoodItems = _context.UserFoodItems
                .Where(item => item.UserId == userId && item.ExpirationDate >= currentDate && item.ExpirationDate <= oneWeekFromNow)
                .ToList();

            return Ok(expiringFoodItems);
        }


    }
}



    
