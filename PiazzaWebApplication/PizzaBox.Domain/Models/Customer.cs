﻿using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CxOrder = new HashSet<CxOrder>();
        }

        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string UserPass { get; set; }
        public long? Phone { get; set; }

        public virtual ICollection<CxOrder> CxOrder { get; set; }
    }
}
