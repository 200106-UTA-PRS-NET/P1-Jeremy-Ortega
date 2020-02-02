using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public partial class Store
    {
        public Store()
        {
            CxOrder = new HashSet<CxOrder>();
            TempCustomerOrder = new HashSet<TempCustomerOrder>();
        }

        public int Id { get; set; }
        public string StoreLocation { get; set; }
        public string StoreName { get; set; }

        public virtual ICollection<CxOrder> CxOrder { get; set; }
        public virtual ICollection<TempCustomerOrder> TempCustomerOrder { get; set; }
    }
}
