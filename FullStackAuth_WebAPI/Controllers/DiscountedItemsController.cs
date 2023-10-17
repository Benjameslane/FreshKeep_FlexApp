using Microsoft.AspNetCore.Mvc;
using FullStackAuth_WebAPI.Models;
using FullStackAuth_WebAPI.DataTransferObjects;
using System;
using System.Collections.Generic;

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/discounteditems")]
    [ApiController]
    public class DiscountedItemController : ControllerBase
    {
        // You'll need a data context to interact with your database.

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

              

             
                return Ok("Discounted item created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

      
    }
}


