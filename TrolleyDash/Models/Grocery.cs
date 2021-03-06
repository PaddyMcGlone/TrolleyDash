using System;
using System.ComponentModel.DataAnnotations;

namespace TrolleyDash.Models
{
    public class Grocery
    {
        #region Constructor

        public Grocery()
        {
        }

        public Grocery(string name, int quantity, DateTime? dueFor = null)
        {
            this.Name = name;
            this.Quantity = quantity;
            this.DueFor = dueFor;
        }

        #endregion

        #region Properties
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public int? Quantity { get; set; }
        public DateTimeOffset? DueFor { get; set; }
        public bool Fetched { get; set; }
        #endregion

        #region Helper Properties
        public string GroceryItem { get { return string.Format("[{0}] {1}", Quantity, Name); } }

        #endregion
    }
}