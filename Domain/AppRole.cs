using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class AppRole: IdentityRole<int>
    {
        public int Id { get; set; }
    }
}