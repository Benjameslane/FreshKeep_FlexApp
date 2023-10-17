namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class DiscountedItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ExpirationDate { get; set; }
        public double OriginalPrice { get; set; }
        public double DiscountedPrice { get; set; }
        public double DiscountAmount { get; set; }
        public string StoreOwnerId { get; set; }

        // Additional properties if needed.
    }
}
