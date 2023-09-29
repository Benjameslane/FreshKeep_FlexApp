using Microsoft.AspNetCore.Identity;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsStoreOwner { get; set; }  // true = StoreOwner, false = HomeOwner
}
