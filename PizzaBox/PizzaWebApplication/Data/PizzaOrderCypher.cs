using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebApplication.Data
{
    public class PizzaOrderCypher
    {
        public List<string> toppings { get; } = new List<string>();
        public int size { get; private set; }
        public string crust { get; private set; }
        public double price{get; private set;}

        public void setSize(int check)
        {
            if (check == 1)
            {
               size = 12;
            }
            else if (check == 2)
            {
                size = 15;
            }
            else if (check == 3)
            {
                size = 20;
            }
            else
            {
                size = 12;
            }
        }

        public void setCrust(int check)
        {
            string str;
            if (check == 1)
            {
                str = "Thin";
            }
            else if (check == 2)
            {
                str = "Deep Dish";
            }
            else if (check == 3)
            {
                str = "Cheese Filled";
            }
            else
            {
                str = "Thin";
            }
            crust = str;
        }

        public void setToppings(char[] boolBits)
        {
            if (boolBits[0] == 1)
            {
                toppings.Add("sauce");
            }
            else if (boolBits[1] == 1)
            {
                toppings.Add("cheese");
            }
            else if (boolBits[2] == 1)
            {
                toppings.Add("pepperoni");
            }
            else if (boolBits[3] == 1)
            {
                toppings.Add("sausage");
            }
            else if (boolBits[4] == 1)
            {
                toppings.Add("pineapple");
            }
            else
            {
                toppings.Add("sauce");
                toppings.Add("cheese");
            }
        }


        /// <summary>
        /// returns total price of pizza ordered.
        /// </summary>
        /// <returns></returns>
        public void getPriceOfPizza()
        {
            double ToppingsPrice = 0.0;
            double CrustMultiplier = 0.0;
            double pizzaSizeCost = 0.0;

            // Chosen Size
            if (size == 1)
            {
                price += 8.0;
            }
            else if (size == 2)
            {
                price += 9.5;
            }
            else if (size == 3)
            {
                price += 10.5;
            }

            // Chosen crust
            if (crust.Equals("Thin"))
            {
                 CrustMultiplier= 1.1;
            }
            if (crust.Equals("Deep Dish"))
            {
                CrustMultiplier= 1.2;
            }
            if (crust.Equals("Cheese Filled"))
            {
                CrustMultiplier= 1.5;
            }


            // Chosen Toppings
            if (toppings[0].Equals("sauce"))
            {
                ToppingsPrice= 1;
            }
            if (toppings[0].Equals("chees"))
            {
                ToppingsPrice=1;
            }
            if (toppings[0].Equals("pepperoni"))
            {
                ToppingsPrice=3;
            }
            if (toppings[0].Equals("sausage"))
            {
                ToppingsPrice=4;
            }
            if (toppings[0].Equals("pineapple"))
            {
                ToppingsPrice= 3;
            }


            // return total cost of pizza
            price= pizzaSizeCost * CrustMultiplier + ToppingsPrice;

        }
    }
}
