using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ManageUsersViewModel
{
    public class ManageUsersViewModel
    {
        public IdentityUser[] Administrator { get; set; }

        public IdentityUser[] Everyone { get; set; }
    }
}