using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Domain;
using PizzaBox.Storing.Abstractions;
using PizzaBox.Storing.TestModels;
using PizzaWebApplication.Models;
using PizzaWebApplication.Data;
using PizzaBox.Storing;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaWebApplication.Controllers
{
    public class OrderController : Controller
    {

        private readonly IRepositoryOrders<Order1> _repo;
        private readonly CustomerViewModel _CVM;
        private readonly IRepositoryTempCustomerOrder<TempCustomerOrder1> _tco;

        public OrderController(IRepositoryOrders<Order1> repo, CustomerViewModel CVM, IRepositoryTempCustomerOrder<TempCustomerOrder1> TCO)
        {
            _CVM = CVM;
            _repo = repo;
            _tco = TCO;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            var order = _repo.ReadInOrder().OrderByDescending(e=>e.OrderDate).ToList();

            List<OrderViewModel> ovm = new List<OrderViewModel>();
            foreach (var ord in order)
            {
                if (ord.CustId == CustomerInfo.Id && ord.StoreId == CustomerInfo.StoreId) {
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
        
        public IActionResult Create()
        {
            List<TempCustomerOrder> TCO = new List<TempCustomerOrder>();
            var fulOrder = _tco.ReadInOrder(FullOrder.UserID);
            foreach (var ord in fulOrder)
            {
                TempCustomerOrder tco = new TempCustomerOrder();
                tco.Crust = ord.Crust;
                tco.Price = ord.Price;
                tco.Size = ord.Size;
                TCO.Add(tco);
            }

            return View(TCO);
        }


        //public IActionResult Create(OrderViewModel order)
        //{

        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            Order1 ox = new Order1()
        //            {
        //                OrderId = order.OrderId,
        //                CustId = order.CustId,
        //                OrderDate=order.OrderDate,
        //                Price=order.Price,
        //                StoreId=order.StoreId
        //            };
        //            _repo.CreateOrder(ox);
        //            return RedirectToAction(nameof(Index));
        //        }
        //        else
        //        {
        //            return View();
        //        }
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


        public IActionResult viewOrder(PizzaViewModel OVM)
        {
            // created object from _repo database object
            var order = _repo.ReadInOrder();

            // Check each of the orders in the database 
            //foreach (var ord in order.OrderByDescending(e=>e.OrderDate))
            //{
            // If the order id matches the OVM 
            //if (ord.CustId == _CVM.Id)
            //{
            PizzaOrderCypher ordV = new PizzaOrderCypher();
            ordV.setToppings(BitFlagConversion.convertIntToFlagArray(5, OVM.Toppings));
            ordV.setSize(OVM.Size);
            ordV.setCrust(Convert.ToInt32(OVM.Crust));
            FullOrder.currOrder.Add(ordV);
            //}
            //}

            return View(FullOrder.currOrder);
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
