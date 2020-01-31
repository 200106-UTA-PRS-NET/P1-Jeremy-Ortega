﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebApplication.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string UserPass { get; set; }
        public long? Phone { get; set; }
    }
}
