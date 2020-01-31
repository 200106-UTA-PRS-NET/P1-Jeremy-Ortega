using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebApplication.Models
{
    public class PizzaViewModel
    {
        public int PizzaId { get; set; }
        public int OrderId { get; set; }
        public int Toppings { get; set; }
        public string Crust { get; set; }
        public int Size { get; set; }
        public decimal Price { get; set; }
    }
}
