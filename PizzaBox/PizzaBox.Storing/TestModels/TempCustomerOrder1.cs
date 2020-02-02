using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PizzaBox.Storing.TestModels
{
    public class TempCustomerOrder1
    {
        //[Key]
        //[Column(Order=2)]
        public int PizzaId { get; set; }

        //[Key]
        //[Column(Order=1)]
        public int CustId { get; set; }

        public int Toppings { get; set; }
        public string Crust { get; set; }
        public decimal Price { get; set; }
        public int Size { get; set; }
        public int StoreId { get; set; }
        
    }
}
