using System;
using System.Collections.Generic;
using TrolleyDash.Models;

namespace TrolleyDash.Services
{
    public interface IGroceryService
    {
        IEnumerable<Grocery> GetAllGroceriesToBeFetched();

        void Add(Grocery grocery);

        void MarkDone(Guid id);
    }
}