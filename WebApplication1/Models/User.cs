using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "Driving license is required!")]
        [StringLength(255, ErrorMessage = "Driving license cannot exceed 255 characters")]
        public string DrivingLicense { get; set; }

        [Required(ErrorMessage = "Phone is required!")]
        [StringLength(13, ErrorMessage = "Phone cannot exceed 13 characters!")]
        public string PhoneNumber { get; set; }

        public async Task<ClaimsIdentity> generateUserIdentity(UserManager<User> manager)
        {
            var user = new ClaimsIdentity(await manager.GetClaimsAsync(this));
            return user;
        }
    }
}
