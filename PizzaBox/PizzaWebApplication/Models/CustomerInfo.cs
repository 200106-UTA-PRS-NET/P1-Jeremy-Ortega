using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebApplication.Models
{
    public class CustomerInfo
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        public string storeName { get; set; }
        public int Id { get; set; }

    }
}
