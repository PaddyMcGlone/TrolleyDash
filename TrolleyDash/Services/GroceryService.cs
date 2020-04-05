using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TrolleyDash.Data;
using TrolleyDash.Models;

namespace TrolleyDash.Services
{
    public class GroceryService : IGroceryService
    {

        #region Properties
        private ApplicationDbContext _context { get; set; }
        #endregion

        #region Constructor
        public GroceryService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        #endregion

        #region Methods
        public async Task<List<Grocery>> GetAllGroceriesToBeFetchedAsync(IdentityUser currentUser)
        {
            return await _context.Groceries
                            .Where(g => !g.Fetched &&
                            g.UserId == currentUser.Id)
                            .ToListAsync();
        }

        public async Task<bool> Add(Grocery grocery, IdentityUser user)
        {
            if (grocery == null)
                throw new ArgumentNullException("grocery");

            if (user == null)
                throw new ArgumentNullException("user");

            grocery.Id = Guid.NewGuid();
            grocery.DueFor = DateTime.Now.AddDays(3);
            grocery.UserId = user.Id;

            _context.Groceries.Add(grocery);
            var save = await _context.SaveChangesAsync();

            return save == 1;
        }

        public async Task<bool> MarkDone(Guid id, IdentityUser user)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("Id");

            if (user == null)
                throw new ArgumentNullException("user");

            var grocery = await _context.Groceries
                                    .FirstOrDefaultAsync(g => g.Id == id);

            grocery.Fetched = true;
            grocery.UserId = user.Id;

            var save = await _context.SaveChangesAsync();
            return save == 1;
        }

        #endregion
    }
}