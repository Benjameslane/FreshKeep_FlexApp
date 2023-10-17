using System;

namespace FullStackAuth_WebAPI.Models
{
    public class DiscountedItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ExpirationDate { get; set; }
        public double OriginalPrice { get; set; }
        public double DiscountedPrice { get; set; }
        public double DiscountAmount { get; set; }
        public string StoreOwnerId { get; set; } 

      
    }
}
