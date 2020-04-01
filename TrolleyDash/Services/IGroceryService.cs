using System;
using System.Collections.Generic;
using TrolleyDash.Models;

namespace TrolleyDash.Services
{
    public interface IGroceryService
    {
        IEnumerable<Grocery> GetAllGroceriesToBeFetched();
    }
}