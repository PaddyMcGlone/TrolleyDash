using System;
using System.ComponentModel.DataAnnotations;

namespace TrolleyDash.Models
{
    public class Grocery
    {
        #region Properties
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset? DueFor { get; set; }
        public bool Fetched { get; set; }
        #endregion

        #region Helper Properties
        public string GroceryItem { get { return string.Format("[{0}] {1}", Quantity, Name); } }

        #endregion
    }
}