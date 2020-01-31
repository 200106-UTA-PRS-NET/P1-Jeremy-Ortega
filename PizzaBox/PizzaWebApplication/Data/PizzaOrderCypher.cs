using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebApplication.Data
{
    public class PizzaOrderCypher
    {
        public List<string> toppings { get; } = new List<string>();
        public string size { get; private set; }
        public string crust { get; private set; }


        public void setSize(int check)
        {
            string str = "";
            if (check == 1)
            {
                str = "Twelve inch";
            }
            if (check == 2)
            {
                str = "Fifteen inch";
            }
            if (check == 3)
            {
                str = "Twenty Inch";
            }
            size = str;
        }

        public void setCrust(string check)
        {
            string str = "";
            if (check.Equals('1'))
            {
                str = "Thin";
            }
            if (check.Equals('2'))
            {
                str = "Deep Dish";
            }
            if (check.Equals('3'))
            {
                str = "Cheese Filled";
            }
            crust = str;
        }


        public void setToppings(char[] boolBits)
        {
            if (boolBits[0] == 1)
            {
                toppings.Add("sauce");
            }
            if (boolBits[1] == 1)
            {
                toppings.Add("cheese");
            }
            if (boolBits[2] == 1)
            {
                toppings.Add("pepperoni");
            }
            if (boolBits[3] == 1)
            {
                toppings.Add("sausage");
            }
            if (boolBits[4] == 1)
            {
                toppings.Add("pineapple");
            }
        }
    }
}
