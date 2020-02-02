using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing.Abstractions
{
    public interface IRepositoryTempCustomerOrder<T>
    {
        // Create , Read, Update, Delete
        IEnumerable<T> ReadInOrder(int Id);
        void CreateOrder(T Order);
        void UpdateOrder(T Order);
        void DeleteOrder(int Id);
    }
}
