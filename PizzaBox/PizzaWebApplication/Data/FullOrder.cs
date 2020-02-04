using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaWebApplication.Models;
using static PizzaBox.Domain.Pizza;

namespace PizzaWebApplication.Data
{
    public static class FullOrder
    {
        // don't touch until adding a pizz or submitting an order
        public static List<PizzaOrderCypher> currOrder { get; set; } = new List<PizzaOrderCypher>();

        public static string userName { get; set; }
        public static int UserID { get; set; }
        public static string storeName { get; set; }
        public static int storeID { get; set; }
        public static int orderID { get; set; }
    }
}
