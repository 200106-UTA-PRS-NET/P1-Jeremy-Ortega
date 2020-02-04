using PizzaBox.Domain.Models;
using PizzaBox.Storing.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using PizzaBox.Storing.Mappings;
using System.Linq;
using PizzaBox.Storing.TestModels;

namespace PizzaBox.Storing.Repositories
{
    public class TempCustomerOrderRepo : IRepositoryTempCustomerOrder<TestModels.TempCustomerOrder1>
    {

        PizzaProjectDbContext PCO;

        public TempCustomerOrderRepo()
        {
            PCO = new PizzaProjectDbContext();
        }

        public TempCustomerOrderRepo(PizzaProjectDbContext PC)
        {
            // Directly taken from the aformentioned model by Pushpinder Kaur.
            this.PCO = PC ?? throw new ArgumentNullException(nameof(PC));
        }




        public void CreateOrder(TempCustomerOrder1 Order)
        {
            PCO.TempCustomerOrder.Add(MapTempCustomerOrder.Map(Order));
            PCO.SaveChanges();
        }

        /// <summary>
        /// Read in Customer ID and Any pizza number associated with their current order and delete all their pizzas.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="pizza"></param>
        public void DeleteOrder(int Id)
        {
            var Cus = PCO.TempCustomerOrder.OrderByDescending(CxTempOrd => CxTempOrd.CustId == Id);
            foreach (var C in Cus) {
                PCO.Remove(C);
                PCO.SaveChanges();
            }
        }

        public IEnumerable<TempCustomerOrder1> ReadInOrder(int Id)
        {

            var getPizza = from P in PCO.TempCustomerOrder
                               //where P.CustId == Id
                               select MapTempCustomerOrder.Map(P);

            return getPizza;


        }

        public void UpdateOrder(TestModels.TempCustomerOrder1 Order)
        {
            throw new NotImplementedException();
        }
    }
}

