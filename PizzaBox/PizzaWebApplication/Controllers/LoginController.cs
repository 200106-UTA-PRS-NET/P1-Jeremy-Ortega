using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Storing.Abstractions;
using PizzaBox.Storing.TestModels;
using PizzaWebApplication.Models;
using PizzaWebApplication.Data;

namespace PizzaWebApplication.Controllers
{
    public class LoginController : Controller
    {

        private readonly IRepositoryCustomer<Customer1> _repo;
        private readonly IRepositoryOrders<Order1> _order;
        private readonly IRepositoryStore<Store1> _store;


        const string SessionName = "_Name";
        const string SessionPassword = "_Password";


        public LoginController(IRepositoryCustomer<Customer1> repo, 
            IRepositoryOrders<Order1> orderRepo,
            IRepositoryStore<Store1> store)
        {
            _repo = repo;
            _order = orderRepo;
            _store = store;
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
        public ActionResult LoggedIn(LoginViewModel collection)
        {
            var v = _repo.ReadInCustomer().FirstOrDefault(e => e.Email.Equals(collection.Email) && e.UserPass.Equals(collection.Password));
            var o = _order.ReadInOrder().ToList();  // Super imprtant to convert to list to close connection
            var stor = _store.ReadInStore().ToList(); // ned to close connection by first creating a list
            if (v != null && o != null)
            {

                CustomerInfo.Fname = v.Fname;
                CustomerInfo.Id = v.Id;
                CustomerInfo.Lname = v.Lname;
                CustomerInfo.email = v.Email;

                FullOrder.userName = v.Fname;
                FullOrder.UserID = v.Id;
                



                //List<StoreViewModel> svm = new List<StoreViewModel>();
                // RedirectToAction("Action", "Controller");
                StoreOfSpecificCustomerModel _Main = new StoreOfSpecificCustomerModel
                {
                    CVM = new CustomerViewModel(),
                    LOS = new List<StoreViewModel>()
                };
                _Main.CVM.Email = v.Email;
                _Main.CVM.Fname = v.Fname;
                _Main.CVM.Id = v.Id;
                _Main.CVM.Lname = v.Lname;
                DateTime dt = DateTime.Now;
                double time = 25;
                double date2 = 25;
                //For each order go through and check if store id and customer id match
                foreach (var _stor in stor)
                {
                    foreach (var _ord in o.OrderByDescending(e => e.CustId))
                    {
                        if (v.Id == _ord.CustId && _ord.StoreId == _stor.Id)
                        {
                            TimeSpan ts2 = (TimeSpan)(dt - _ord.OrderDate);
                            date2 = ts2.TotalMinutes / 60;
                            if (date2 < time)
                            {
                                time = date2;
                            }
                        }
                    }
                    if (time >= 24)
                    {
                        StoreViewModel stm = new StoreViewModel();
                        stm.Id = _stor.Id;
                        stm.StoreLocation = _stor.StoreLocation;
                        stm.StoreName = _stor.StoreName;
                        _Main.LOS.Add(stm);
                        // TODO: Add Location 
                    }
                }
                return View(_Main);
            }
            return RedirectToAction("Index", "Login");
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