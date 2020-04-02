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
        #endregion
    }
}