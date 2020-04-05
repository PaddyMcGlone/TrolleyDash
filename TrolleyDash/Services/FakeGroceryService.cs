using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TrolleyDash.Models;

namespace TrolleyDash.Services
{
    public class FakeGroceryService : IGroceryService
    {
        public async Task<List<Grocery>> GetAllGroceriesToBeFetchedAsync(IdentityUser currentUser)
        {
            return new List<Grocery>
            {
                new Grocery("Bread", 2, DateTime.Today),
                new Grocery("Milk", 1, DateTime.Today),
                new Grocery("Chopped Tomatoes", 4, DateTime.Today.AddDays(4))
            };
        }

        public async Task<bool> Add(Grocery grocery)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> MarkDone(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}