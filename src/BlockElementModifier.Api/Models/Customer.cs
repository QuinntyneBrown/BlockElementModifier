using System;

namespace BlockElementModifier.Api.Models
{
    public class Customer
    {
        public Guid CustomerId { get; private set; }

        public DateTime? Deleted { get; set; }
        public Customer Remove()
        {
            Deleted = DateTime.UtcNow;

            return this;
        }
    }
}
