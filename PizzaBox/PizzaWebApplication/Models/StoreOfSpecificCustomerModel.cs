using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebApplication.Models
{
    public class StoreOfSpecificCustomerModel
    {
        public List<StoreViewModel> LOS { get; set; }
        public CustomerViewModel CVM { get; set; }
    }
}
