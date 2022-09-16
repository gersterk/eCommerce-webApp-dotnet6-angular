using AppAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAPI.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid CustomerId { get; set; } //each order will hold an id of a customer
        public string Description { get; set; }

        public string Address { get; set; } //could be a value object too, because an address has very micro details, county, city, street

        public ICollection<Product> Products { get; set; } //many to many

        public Customer Customer { get; set; } //one to many 
    }
}
