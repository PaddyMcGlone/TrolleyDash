using System;
using System.ComponentModel.DataAnnotations;

namespace TrolleyDash.Models
{
    class Grocery
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset? DueFor { get; set; }
        public bool Fetched { get; set; }
    }
}