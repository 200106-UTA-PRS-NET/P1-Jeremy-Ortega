using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Storing.Abstractions;
using PizzaBox.Storing.TestModels;
using PizzaWebApplication.Models;

namespace PizzaWebApplication.Controllers
{
    public class LoginController : Controller
    {

        private readonly IRepositoryCustomer<Customer1> _repo;
        public LoginController(IRepositoryCustomer<Customer1> repo)
        {
            _repo = repo;
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoginViewModel collection)
        {

            foreach (var cr in _repo.ReadInCustomer())
            {
                if (collection.Email == cr.Email)
                {
                    RedirectToAction("create", "StoreController");
                }
            }

            try
            {
                // RedirectToAction("Action", "Controller");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewUser(LoginViewModel collection)
        {

            foreach (var cr in _repo.ReadInCustomer())
            {
                if (collection.Email == cr.Email)
                {
                    RedirectToAction("create", "StoreController");
                }
            }

            try
            {
                // RedirectToAction("Action", "Controller");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}