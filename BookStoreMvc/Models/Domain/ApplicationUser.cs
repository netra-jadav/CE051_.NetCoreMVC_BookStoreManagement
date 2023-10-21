using Microsoft.AspNetCore.Identity;

namespace BookStoreMvc.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        //Properties will be saved in db user table 
        public string  Name{ get; set; }
    }
}
