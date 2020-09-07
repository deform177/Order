using Order.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Domains.Order
{
    public class User : EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Balance { get; set; }
    }
}
