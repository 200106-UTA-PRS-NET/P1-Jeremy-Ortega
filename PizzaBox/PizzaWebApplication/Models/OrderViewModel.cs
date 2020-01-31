using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebApplication.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public int CustId { get; set; }
        public int StoreId { get; set; }
        public decimal Price { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
