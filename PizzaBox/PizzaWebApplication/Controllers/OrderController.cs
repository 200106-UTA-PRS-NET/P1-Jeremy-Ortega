using System;
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
        public OrderController(IRepositoryOrders<Order1> repo)
        {
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
