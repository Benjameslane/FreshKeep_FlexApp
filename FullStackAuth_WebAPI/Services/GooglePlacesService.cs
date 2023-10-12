using FullStackAuth_WebAPI.DataTransferObjects;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

public class GooglePlacesService
{
    private readonly HttpClient _httpClient;

    public GooglePlacesService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GooglePlacesResponseDto> GetNearbyPlacesAsync(double latitude, double longitude)
    {
        try
        {
            var apiKey = "AIzaSyA5kMbLRXGf110-1JzP35CkFlcFe69lnJ0"; 

            var baseUrl = "https://maps.googleapis.com/maps/api/place/nearbysearch/json";
            var parameters = $"location={latitude},{longitude}&radius=1000&type=food&key={apiKey}";
            var requestUrl = $"{baseUrl}?{parameters}";

            var response = await _httpClient.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var googlePlacesResponse = JsonConvert.DeserializeObject<GooglePlacesResponseDto>(responseBody);
                return googlePlacesResponse;
            }
            else
            {
                throw new Exception($"Error from Google Places API: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while processing Google Places request: {ex.Message}");
        }
    }
}
