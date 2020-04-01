using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrolleyDash.Models;

namespace TrolleyDash.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        #region Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        #endregion

        #region Properties

        public DbSet<Grocery> Groceries { get; set; }

        #endregion
    }
}
