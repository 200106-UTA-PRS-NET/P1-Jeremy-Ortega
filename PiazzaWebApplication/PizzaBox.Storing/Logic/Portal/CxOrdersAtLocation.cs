﻿using System;
using System.Collections.Generic;
using PizzaBox.Domain;
using System.Text;
using PizzaBox.Storing.Repositories;
using System.Threading;

namespace PizzaBox.Storing.Logic.Portal
{
    public class CxOrdersAtLocation
    {
       //ZZ_PrintLoggedInHeader PH;
        public CxOrdersAtLocation()
        {
            //PH = new ZZ_PrintLoggedInHeader();
        }
        /// <summary>
        /// Call this method to print all Cx Pizza's in their current order
        /// </summary>
        /// <param name="username"></param>
        /// <param name="stores"></param>
        /// <param name="locationChoice"></param>
        /// <param name="currentOrder"></param>
        public static int printCxPrevOrdersAtCurrLoc(string username, string storeName, CurrentOrder curOrd)
        {
            Console.Clear();
            ZZ_PrintLoggedInHeader.printStoreHeaderLoggedIn(username, storeName);

            // At each order location write all the pizza sizes, crust and price's in each order
            Console.WriteLine(" | user: <{0}> order totalled: <${1}> |", curOrd.userName, curOrd.currOrderTotal);
            Console.WriteLine(" |----------------------------------------");
            // At each order give brief description of the pizza's ordered
            int pizzaLineCounter = 1;
            foreach (Pizza pOrd in curOrd.pizzasInOrder)
            {
                // give toppings
                Console.Write(" |{0}: {1} {2} pizza with", pizzaLineCounter, pOrd.pizzaSize, pOrd.getCrustChoice());
                List<string> tops = pOrd.getChosenToppings();
                foreach (string pTop in tops)
                {
                    Console.Write(" <{0}>", pTop);
                }
                Console.WriteLine();
                Console.WriteLine(" | ---- Pizza Cost ---- <{0}>", pOrd.getPriceOfPizza());
                Console.WriteLine(" |");
                pizzaLineCounter++;
            }
            Console.WriteLine(" |_________________________________________________________\n");
            Console.WriteLine("1.<accept>  2.<deny>");
            
            int res = -1;
            while (res < 1 || res > 2)
            {
                res = IntCheck.IntChecker();
                if (res == -1) { continue; }

            }
            return res;
        }
    }
}
