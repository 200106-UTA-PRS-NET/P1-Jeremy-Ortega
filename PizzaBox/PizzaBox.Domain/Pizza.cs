﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace PizzaBox.Domain
{
    public class Pizza
    {

        /// <summary>
        /// Size of pizza, choice by customer with properties
        /// </summary>
        public Size size { get; set; }
        public enum Size
        {
            twelveInch, fifteenInch, twentyInch,
        }


        /// <summary>
        /// Toppings choice given to customer using list to store
        /// up to 5 choices
        /// </summary>
        public List<Toppings> toppings;
       public enum Toppings
        {
            sauce, cheese, pepperoni, sausage, pineapple
        }


        /// <summary>
        /// Crust choice will be a multiplicative addition based on size of pizza.
        /// </summary>
        public Crust crust;
        public enum Crust
        {
            deepdish, thin, cheesefilled,
        }


        /// <summary>
        /// Pizza requires at least cheese and pepperoni
        /// </summary>
        private void defaultToppings()
        {
            toppings = new List<Toppings>();
            toppings.Add(Toppings.cheese);
            toppings.Add(Toppings.sauce);
        }


        /// <summary>
        /// Add more toppings, limited to no more than 5.
        /// </summary>
        /// <param name="top"></param>
        public void addToppings(Toppings top)
        {
            if (toppings.Count >= 5)
            {
                Console.WriteLine("Topping Limit is reached");
            }
            else
            {
                toppings.Add(top);
            }
        }


        /// <summary>
        /// Customer chooses their crust
        /// </summary>
        /// <param name="c"></param>
        public void chooseCrust(Crust c)
        {
            crust = c;
        }


        /// <summary>
        /// Calculate the total price of the pizza.
        /// </summary>
        /// <returns></returns>
        public double getPrice()
        {
            double ToppingsPrice = 0.0;
            double CrustMultiplier = 0.0;
            double pizzaSizeCost = 0.0;

            // Chosen Size
            Size size = this.size;
            switch (size)
            {
                case Size.twelveInch:
                    pizzaSizeCost = 5.0;
                    break;
                case Size.fifteenInch:
                    pizzaSizeCost = 8.0;
                    break;
                case Size.twentyInch:
                    pizzaSizeCost = 11.0;
                    break;
                default:
                    Console.WriteLine("no pizza size chosen.");
                    Thread.Sleep(3000);
                    break;
            }

            // Chosen crust
            Crust crust = this.crust;
            switch (crust)
            {
                case Crust.cheesefilled:
                    CrustMultiplier = 1.5;
                    break;
                case Crust.deepdish:
                    CrustMultiplier = 1.3;
                    break;
                case Crust.thin:
                    CrustMultiplier = 1.1;
                    break;
                default:
                    Console.WriteLine("No crust was chosen.");
                    Thread.Sleep(3000);
                    break;
            }

            // Chosen Toppings
            if (toppings.Contains(Toppings.cheese))
            {
                ToppingsPrice += 1.50;
            }
            if (toppings.Contains(Toppings.sauce))
            {
                ToppingsPrice += 1.25;
            }
            if (toppings.Contains(Toppings.pepperoni))
            {
                ToppingsPrice += 1.60;
            }
            if (toppings.Contains(Toppings.sausage))
            {
                ToppingsPrice += 1.70;
            }
            if (toppings.Contains(Toppings.pineapple))
            {
                ToppingsPrice += 1.75;
            }

            // return total cost of pizza
            return pizzaSizeCost*CrustMultiplier + ToppingsPrice;

        }

    }
}
