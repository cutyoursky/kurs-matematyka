using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace kurs_matematyki.Core.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpirationDateTime { get; set; }
    }
}
