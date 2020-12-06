using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.User.Entity.ValueObject
{
    public class Address
    {
        public string Province { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Street { get; set; }
    }
}
