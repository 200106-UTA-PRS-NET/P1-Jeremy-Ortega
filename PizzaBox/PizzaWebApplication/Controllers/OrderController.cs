using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Storing.Abstractions;
using PizzaBox.Storing.TestModels;
using PizzaWebApplication.Models;
using PizzaWebApplication.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaWebApplication.Controllers
{
    public class OrderController : Controller
    {

        private readonly IRepositoryOrders<Order1> _repo;
        private readonly CustomerViewModel _CVM;
        private readonly IRepositoryTempCustomerOrder<TempCustomerOrder1> _tco;
        private readonly IRepositoryPizza<Pizza1> _pizza;

        public OrderController(IRepositoryOrders<Order1> repo, CustomerViewModel CVM, 
            IRepositoryTempCustomerOrder<TempCustomerOrder1> TCO,
            IRepositoryPizza<Pizza1> Pizza)
        {
            _CVM = CVM;
            _repo = repo;
            _tco = TCO;
            _pizza = Pizza;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            var order = _repo.ReadInOrder().OrderByDescending(e=>e.OrderDate).ToList();

            List<OrderViewModel> ovm = new List<OrderViewModel>();
            foreach (var ord in order)
            {
                if (ord.StoreId == FullOrder.storeID) {
                    OrderViewModel ox = new OrderViewModel();
                    ox.OrderId = ord.OrderId;
                    ox.CustId = ord.CustId;
                    ox.OrderDate = ord.OrderDate;
                    ox.Price = ord.Price;
                    ox.StoreId = ord.StoreId;
                    ovm.Add(ox);
                }
            }
            return View(ovm);
        }


        public IActionResult MyOrder()
        {
            var order = _repo.ReadInOrder().OrderByDescending(e => e.OrderDate).ToList();

            List<OrderViewModel> ovm = new List<OrderViewModel>();
            foreach (var ord in order)
            {
                if (ord.StoreId == FullOrder.storeID && ord.CustId == FullOrder.UserID)
                {
                    OrderViewModel ox = new OrderViewModel();
                    ox.OrderId = ord.OrderId;
                    ox.CustId = ord.CustId;
                    ox.OrderDate = ord.OrderDate;
                    ox.Price = ord.Price;
                    ox.StoreId = ord.StoreId;
                    ovm.Add(ox);
                }
            }
            return View(ovm);
        }

        // Creates Order
        public IActionResult Create()
        {
            List<TempCustomerOrder> TCO = new List<TempCustomerOrder>();
            var fulOrder = _tco.ReadInOrder(FullOrder.UserID).ToList();
            decimal Tot = 0;
            foreach (var ord in fulOrder)
            {
                TempCustomerOrder tco = new TempCustomerOrder();
                tco.Crust = ord.Crust;
                tco.Price = ord.Price;
                tco.PizzaId = ord.PizzaId;
                Tot += ord.Price;
                tco.Size = ord.Size;
                TCO.Add(tco);
            }
            ViewBag.total = Tot;
            return View(TCO);
        }


        public IActionResult viewOrder(PizzaViewModel OVM)
        {
            // created object from _repo database object
            var order = _tco.ReadInOrder(FullOrder.UserID).ToList();
            int OrderID = Convert.ToInt32(new Random().Next(1000000, 10000000));
            // Check each of the orders in the database 
            // get the full sum of all orders placed.
            var sum = _tco.ReadInOrder(FullOrder.UserID).Select(e=>e.Price).Sum();

            Order1 o = new Order1();
            o.OrderId = OrderID;
            o.Price = sum;
            o.StoreId = FullOrder.storeID;
            o.CustId = FullOrder.UserID;
            o.OrderDate = DateTime.Now;
            _repo.CreateOrder(o);

            foreach (var ord in order)
            {
                Pizza1 p = new Pizza1();
                p.Crust = ord.Crust;
                p.Price = ord.Price;
                p.Size = ord.Size;
                p.Toppings = ord.Toppings;
                p.OrderId = OrderID;
                p.PizzaId = Convert.ToInt32(new Random().Next(1000000, 10000000));
                _pizza.CreatePizza(p);
            }


            // delete all temp orders once placed into the database
            _tco.DeleteOrder(FullOrder.UserID);

            return View();
        }

        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // redirect here to do some deletion logic before rerouting back to the order page again
        public ActionResult Delete()
        {
            _tco.DeleteOrder(FullOrder.UserID);
            return View();
        }

        public ActionResult DeletePizza(int id)
        {
            _tco.DeletePie(id);
            return RedirectToAction("Create", "Order");
        }
    }
}
