using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing.Mappings
{
    public class MapTempCustomerOrder
    {
        public static TestModels.TempCustomerOrder1 Map(Domain.Models.TempCustomerOrder P)
        {
            return new TestModels.TempCustomerOrder1()
            {
                PizzaId = P.PizzaId,
                Toppings = P.Toppings,
                Crust = P.Crust,
                Size = P.Size,
                Price = P.Price,
                CustId = P.CustId,
                StoreId = P.StoreId
            };
        }

        public static Domain.Models.TempCustomerOrder Map(TestModels.TempCustomerOrder1 P)
        {
            return new Domain.Models.TempCustomerOrder()
            {
                PizzaId = P.PizzaId,
                Toppings = P.Toppings,
                Crust = P.Crust,
                Size = P.Size,
                Price = P.Price,
                CustId = P.CustId,
                StoreId = P.StoreId
            };
        }
    }
}
