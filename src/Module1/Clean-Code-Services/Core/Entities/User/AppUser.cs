using Microsoft.AspNetCore.Identity;

namespace Clean_Code_Services.Core.Entities.User
{
    public class AppUser : IdentityUser
    {
        public bool Deactivated { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public Guid? ModifiedBy { get; set; }
        public Guid? CreatedBy { get; set; }
    }
}
