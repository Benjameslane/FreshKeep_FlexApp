using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq; // Import this namespace
using FullStackAuth_WebAPI.DataTransferObjects;

namespace FullStackAuth_WebAPI.Controllers
{
    [ApiController]
    [Route("api/lookup-barcode")]
    public class LookupBarcodeController : ControllerBase
    {
        private readonly UPCLookupService _upcLookupService;

        public LookupBarcodeController(UPCLookupService upcLookupService)
        {
            _upcLookupService = upcLookupService;
        }

        [HttpPost]
        public async Task<IActionResult> LookupBarcodeAsync([FromBody] BarcodeRequestDto requestData)
        {
            try
            {

                var barcode = requestData.Barcode;

                // Call the UPC lookup service
                var result = await _upcLookupService.LookupBarcodeAsync(barcode);

                // Return the result as JSON
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an error response
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
