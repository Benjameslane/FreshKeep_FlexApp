
namespace FullStackAuth_WebAPI.Dtos
{
    public class FoodItemDto
    {
        public string Name { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsCloseToExpiry { get; set; }
    }
}
