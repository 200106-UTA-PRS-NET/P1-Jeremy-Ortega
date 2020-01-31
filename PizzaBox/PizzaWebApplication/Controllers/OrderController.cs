﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Domain;
using PizzaBox.Storing.Abstractions;
using PizzaBox.Storing.TestModels;
using PizzaWebApplication.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaWebApplication.Controllers
{
    public class OrderController : Controller
    {

        private readonly IRepositoryOrders<Order1> _repo;
        private readonly CustomerViewModel _CVM;

        public OrderController(IRepositoryOrders<Order1> repo, CustomerViewModel CVM)
        {
            _CVM = CVM;
            _repo = repo;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            var order = _repo.ReadInOrder();

            List<OrderViewModel> ovm = new List<OrderViewModel>();
            foreach (var ord in order)
            {
                OrderViewModel ox = new OrderViewModel();
                ox.OrderId = ord.OrderId;
                ox.CustId = ord.CustId;
                ox.OrderDate = ord.OrderDate;
                ox.Price = ord.Price;
                ox.StoreId = ord.StoreId;
                ovm.Add(ox);
            }
            return View(ovm);
        }

        public IActionResult Create()
        {
            return View();
        }


        public IActionResult Create(OrderViewModel order)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Order1 ox = new Order1()
                    {
                        OrderId = order.OrderId,
                        CustId = order.CustId,
                        OrderDate=order.OrderDate,
                        Price=order.Price,
                        StoreId=order.StoreId
                    };
                    _repo.CreateOrder(ox);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }


        public IActionResult viewOrder(OrderViewModel OVM)
        {
            // created object from _repo database object
            var order = _repo.ReadInOrder();

            // Create new list of order objects, We need just the Ones related to the customer.
            List<OrderViewModel> ovm = new List<OrderViewModel>();

            // Create a customer object that has access to all customers in tthe table
            var cus = new PizzaBox.Storing.Repositories.CustomerRepository();

            // Check each of the orders in the database 
            foreach (var ord in order.OrderByDescending(e=>e.OrderDate))
            {
                 // If the order id matches the OVM 
                 if (ord.CustId == _CVM.Id)
                 {
                     // 
                     ovm.Add(OVM);
                 }
                
            }
            return View(ovm);
            //return View();
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

        public ActionResult Delete()
        {
            return View();
        }

        public ActionResult Delete(int id, IFormCollection collection)
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

    }
}
