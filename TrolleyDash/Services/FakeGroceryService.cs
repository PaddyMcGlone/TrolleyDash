using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TrolleyDash.Models;

namespace TrolleyDash.Services
{
    // Removed GroceryService interface definition as class no longer used.
    public class FakeGroceryService
    {
        public List<Grocery> GetAllGroceriesToBeFetchedAsync(IdentityUser currentUser)
        {
            return new List<Grocery>
            {
                new Grocery("Bread", 2, DateTime.Today),
                new Grocery("Milk", 1, DateTime.Today),
                new Grocery("Chopped Tomatoes", 4, DateTime.Today.AddDays(4))
            };
        }

        public void Add(Grocery grocery)
        {
            throw new NotImplementedException();
        }

        public void MarkDone(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}