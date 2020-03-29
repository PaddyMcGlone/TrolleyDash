using System;
using System.Collections.Generic;
using TrolleyDash.Models;

namespace TrolleryDash.Services
{
    public interface IGroceryService
    {
        IEnumerable<Grocery> GetAllGroceriesToBeFetched();
    }
}