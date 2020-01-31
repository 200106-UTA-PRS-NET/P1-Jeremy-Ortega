﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Storing.Abstractions;
using PizzaBox.Storing.TestModels;
using PizzaWebApplication.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaWebApplication.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerViewModel _Cust;
        private readonly IRepositoryCustomer<Customer1> _repo;

        public CustomerController(IRepositoryCustomer<Customer1> repo, CustomerViewModel cust)
        {
            _repo = repo;
            _Cust = cust;
        }


        // GET: /<controller>/
        [Route("Customer")]
        [Route("Customer/Index")]
        public IActionResult Index()
        {
            var customer = _repo.ReadInCustomer();

            List<CustomerViewModel> cvm = new List<CustomerViewModel>();
            foreach (var cus in customer)
            {
                CustomerViewModel cx = new CustomerViewModel();
                cx.Id = cus.Id;
                cx.Fname = cus.Fname;
                cx.Lname = cus.Lname;
                cx.Email = cus.Email;
                cx.Phone = cus.Phone;
                cx.UserPass = cus.UserPass;
                cvm.Add(cx);
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
                    Customer1 cx = new Customer1()
                    {
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