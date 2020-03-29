using System;
using System.Collections.Generic;
using TrolleryDash.Services;
using TrolleyDash.Models;

namespace TrolleyDash.Services
{
    public class FakeGroceryService : IGroceryService
    {
        public IEnumerable<Grocery> GetAllGroceriesToBeFetched()
        {
            return new List<Grocery>
            {
                new Grocery
                {
                    Name     = "Bread",
                    Quantity = 2,
                    DueFor   = DateTime.Today
                },
                new Grocery
                {
                    Name     = "Milk",
                    Quantity = 1,
                    DueFor   = DateTime.Today
                },
                new Grocery
                {
                    Name     = "Chopped Tomatoes",
                    Quantity = 4,
                    DueFor   = DateTime.Today.AddDays(4)
                }
            };
        }
    }
}