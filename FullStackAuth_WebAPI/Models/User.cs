using Microsoft.AspNetCore.Identity;

namespace FullStackAuth_WebAPI.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserType Type { get; set; } // Enum for UserType (Regular/Homeowner or StoreOwner)
        // ... additional properties if needed
    }

    public enum UserType
    {
        Homeowner,
        StoreOwner
        
    }
}
