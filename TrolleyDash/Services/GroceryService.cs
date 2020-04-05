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
                            .Where(g => !g.Fetched)
                            .ToListAsync();
        }

        public async Task<bool> Add(Grocery grocery)
        {
            if (grocery == null)
                throw new ArgumentNullException("grocery");

            grocery.Id = Guid.NewGuid();
            grocery.DueFor = DateTime.Now.AddDays(3);

            _context.Groceries.Add(grocery);
            var save = await _context.SaveChangesAsync();

            return save == 1;
        }

        public async Task<bool> MarkDone(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("Id");

            var grocery = await _context.Groceries
                                    .FirstOrDefaultAsync(g => g.Id == id);

            grocery.Fetched = true;

            var save = await _context.SaveChangesAsync();
            return save == 1;
        }

        #endregion
    }
}