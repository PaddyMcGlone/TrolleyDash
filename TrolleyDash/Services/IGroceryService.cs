using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TrolleyDash.Models;

namespace TrolleyDash.Services
{
    public interface IGroceryService
    {
        Task<List<Grocery>> GetAllGroceriesToBeFetchedAsync(IdentityUser currentUser);

        Task<bool> Add(Grocery grocery);

        Task<bool> MarkDone(Guid id);
    }
}