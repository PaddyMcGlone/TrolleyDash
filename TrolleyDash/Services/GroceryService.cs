using System;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<Grocery> GetAllGroceriesToBeFetched()
        {
            return _context.Groceries.Where(g => !g.Fetched).ToList();
        }

        public void Add(Grocery grocery)
        {
            if (grocery == null)
                throw new ArgumentNullException("grocery");

            grocery.Id = Guid.NewGuid();
            grocery.DueFor = DateTime.Now.AddDays(3);

            _context.Groceries.Add(grocery);
            _context.SaveChanges();
        }

        public void MarkDone(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("Id");

            var grocery = _context.Groceries.FirstOrDefault(g => g.Id == id);
            grocery.Fetched = true;

            _context.SaveChanges();
        }

        #endregion
    }
}