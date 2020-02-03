using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebApplication.Models
{
    public class TempCustomerOrder
    {
        //[Key]
        //[Column(Order = 2)]
        public int Size { get; set; }
        public int PizzaId { get; set; }
        public int Toppings { get; set; }
        public bool sauce { get; set; } = true;
        public bool cheese { get; set; } = true;
        public bool pepperoni { get; set; } = false;
        public bool sausage { get; set; } = false;
        public bool pineapple { get; set; } = false;

        public string Crust { get; set; }
        public decimal Price { get; set; }
        public int CustId { get; set; }
        public int StoreId { get; set; }
    }
}
