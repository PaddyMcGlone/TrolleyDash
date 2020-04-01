using System;
using System.Collections.Generic;
using TrolleyDash.Models;

namespace TrolleyDash.Services
{
    public class FakeGroceryService : IGroceryService
    {
        public IEnumerable<Grocery> GetAllGroceriesToBeFetched()
        {
            return new List<Grocery>
            {
                new Grocery("Bread", 2, DateTime.Today),
                new Grocery("Milk", 1, DateTime.Today),
                new Grocery("Chopped Tomatoes", 4, DateTime.Today.AddDays(4))
            };
        }
    }
}