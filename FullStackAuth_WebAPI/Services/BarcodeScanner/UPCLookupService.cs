using System;
using System.Net.Http;
using System.Threading.Tasks;

public class UPCLookupService
{
    private readonly HttpClient _httpClient;

    public UPCLookupService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> LookupBarcodeAsync(string barcode)
    {
        try
        {
            // Replace this with your actual API endpoint URL
            var apiUrl = "https://api.upcitemdb.com/prod/v1/lookup";
            var requestUrl = $"{apiUrl}?upc={barcode}";

            // Send the GET request
            var response = await _httpClient.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                // Parse and return the successful response as a string
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                // Handle the error response (you can throw an exception or return an error message)
                throw new Exception($"Error from UPCitemdb API: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions
            throw new Exception($"Error while processing UPC lookup: {ex.Message}");
        }
    }
}
