using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Storing.Abstractions;
using PizzaBox.Storing.TestModels;
using PizzaWebApplication.Models;
using PizzaWebApplication.Data;
using System.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaWebApplication.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerViewModel _Cust;
        private readonly IRepositoryCustomer<Customer1> _repo;
        private readonly IRepositoryOrders<Order1> _ord;

        public CustomerController(IRepositoryCustomer<Customer1> repo, CustomerViewModel cust, IRepositoryOrders<Order1> ord)
        {
            _repo = repo;
            _Cust = cust;
            _ord = ord;
        }


        // GET: /<controller>/
        [Route("Customer")]
        [Route("Customer/Index")]
        public IActionResult Index()
        {
            var customer = _repo.ReadInCustomer().ToList();
            var ord = _ord.ReadInOrder().ToList();

            List<CustomerViewModel> cvm = new List<CustomerViewModel>();

            foreach (var cus in customer)
            {
                foreach (var o in ord) {
                    if (FullOrder.storeID == o.StoreId && cus.Id == o.CustId) {
                        CustomerViewModel cx = new CustomerViewModel();
                        cx.Id = cus.Id;
                        cx.Fname = cus.Fname;
                        cx.Lname = cus.Lname;
                        cx.Email = cus.Email;
                        cx.Phone = cus.Phone;
                        cx.UserPass = cus.UserPass;
                        cvm.Add(cx);
                    }
                }
            }
            return View(cvm);
        }



        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // right clicking here creates a form atomagically.
        public IActionResult Create(CustomerViewModel customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Random random = new Random();
                    Customer1 cx = new Customer1()
                    {
                        Id = random.Next(1000000000, 2000000000),
                        Fname = customer.Fname,
                        Lname = customer.Lname,
                        Email = customer.Email,
                        Phone = customer.Phone,
                        UserPass = customer.UserPass
                    };
                    _repo.CreateCustomer(cx);
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

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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

        [HttpPost]
        [ValidateAntiForgeryToken]
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
