using Microsoft.AspNetCore.Identity;
namespace NPlay.Data.Enitites

{
    public class ApplicationUser : IdentityUser
    {
        //public string VippsSub { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
