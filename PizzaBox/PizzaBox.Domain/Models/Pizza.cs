using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public partial class Pizza
    {
        public int PizzaId { get; set; }
        public int OrderId { get; set; }
        public int Toppings { get; set; }
        public string Crust { get; set; }
        public int Size { get; set; }
        public decimal Price { get; set; }

        public virtual CxOrder Order { get; set; }
    }
}
