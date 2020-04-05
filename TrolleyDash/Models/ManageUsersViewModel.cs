using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TrolleyDash.Models
{
    public class ManageUsersViewModel
    {
        public IdentityUser[] Administrators { get; set; }

        public IdentityUser[] Everyone { get; set; }
    }
}