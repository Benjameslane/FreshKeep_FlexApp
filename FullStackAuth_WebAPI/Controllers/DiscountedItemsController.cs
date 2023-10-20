using Microsoft.AspNetCore.Mvc;
using FullStackAuth_WebAPI.Models;
using FullStackAuth_WebAPI.DataTransferObjects;
using System;
using System.Collections.Generic;
using FullStackAuth_WebAPI.Data;

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/discounteditems")]
    [ApiController]
    public class DiscountedItemController : ControllerBase
    {
        private readonly ApplicationDbContext _context; 

        public DiscountedItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateDiscountedItem([FromBody] DiscountedItemDto discountedItemDto)
        {
            if (discountedItemDto == null)
            {
                return BadRequest("Invalid data. Please provide valid discounted item data.");
            }

            try
            {
                var discountedItem = new DiscountedItem
                {
                    Name = discountedItemDto.Name,
                    ExpirationDate = discountedItemDto.ExpirationDate,
                    OriginalPrice = discountedItemDto.OriginalPrice,
                    DiscountedPrice = discountedItemDto.DiscountedPrice,
                    DiscountAmount = discountedItemDto.DiscountAmount,
                    StoreOwnerId = discountedItemDto.StoreOwnerId
                };

                _context.DiscountedItems.Add(discountedItem);
                _context.SaveChanges();

                return Ok("Discounted item created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
        [HttpGet("nearingexpiration")]
        public IActionResult GetDiscountedItemsNearingExpiration()
        {
            try
            {
                var currentDate = DateTime.Now;
                var nearingExpirationItems = _context.DiscountedItems
                    .Where(item => item.ExpirationDate >= currentDate && item.ExpirationDate <= currentDate.AddDays(7))
                    .ToList();

                return Ok(nearingExpirationItems);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDiscountedItem(int id)
        {
            try
            {
                var discountedItem = _context.DiscountedItems.Find(id);

                if (discountedItem == null)
                {
                    return NotFound("Discounted item not found.");
                }

                // Implement logic to delete the discounted item.
                _context.DiscountedItems.Remove(discountedItem);
                _context.SaveChanges();

                return Ok("Discounted item deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


    }
}


