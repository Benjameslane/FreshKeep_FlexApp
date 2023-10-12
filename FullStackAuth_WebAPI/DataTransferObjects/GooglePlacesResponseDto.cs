namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class GooglePlacesResponseDto
    {
        public List<PlaceResultDto> results { get; set; }
        public string next_page_token { get; set; }
    }
}
