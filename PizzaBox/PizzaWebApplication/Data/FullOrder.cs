using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaWebApplication.Models;

namespace PizzaWebApplication.Data
{
    public static class FullOrder
    {

        public static List<PizzaViewModel> currOrder { get; set; } = new List<PizzaViewModel>();
        public static string userName { get; set; }
        public static int UserID { get; set; }
        public static string storeName { get; set; }
        public static int storeID { get; set; }
        public static int orderID { get; set; }
    }
}
