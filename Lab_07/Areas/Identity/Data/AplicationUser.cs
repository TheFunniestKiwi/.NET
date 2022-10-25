using Microsoft.AspNetCore.Identity;

namespace Lab_07.Areas.Identity.Data
{
    public class AplicationUser : IdentityUser
    {
        public long CustomerID { get; set; }
    }
}
