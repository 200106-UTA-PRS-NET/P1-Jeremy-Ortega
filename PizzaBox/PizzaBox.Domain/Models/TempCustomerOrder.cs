using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public partial class TempCustomerOrder
    {
        public int PizzaId { get; set; }
        public int Toppings { get; set; }
        public string Crust { get; set; }
        public int Size { get; set; }
        public decimal Price { get; set; }
        public int CustId { get; set; }
        public int StoreId { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual Store Store { get; set; }
    }
}
