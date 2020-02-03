using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebApplication.Models
{
    public static class CustomerInfo
    {
        public static string Fname { get; set; }
        public static string Lname { get; set; }
        public static string email { get; set; }
        public static string storeName { get; set; }
        public static int StoreId { get; set; }
        public static int Id { get; set; }

    }
}
