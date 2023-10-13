namespace FullStackAuth_WebAPI.Models
{
    public class UserFoodItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string UserId { get; set; }
        public bool IsGroceryItem { get; set; }
    }
}
