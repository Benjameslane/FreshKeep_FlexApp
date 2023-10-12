using Microsoft.AspNetCore.Mvc;
using FullStackAuth_WebAPI.DataTransferObjects;

namespace GooglePlacesIntegration.Controllers
{
    [ApiController]
    [Route("api/places")]
    public class PlacesController : ControllerBase
    {
        private readonly GooglePlacesService _googlePlacesService;

        public PlacesController(GooglePlacesService googlePlacesService)
        {
            _googlePlacesService = googlePlacesService;
        }

        [HttpGet("nearby")]
        public async Task<IActionResult> GetNearbyPlacesAsync([FromQuery] LocationRequestDto requestData)
        {
            try
            {
                double latitude = requestData.Latitude;
                double longitude = requestData.Longitude;

                // Call the Google Places service
                var googlePlacesResponse = await _googlePlacesService.GetNearbyPlacesAsync(latitude, longitude);

                return Ok(googlePlacesResponse);
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an error response
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}


