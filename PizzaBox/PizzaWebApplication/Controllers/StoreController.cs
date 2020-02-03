using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Storing.Abstractions;
using PizzaBox.Storing.TestModels;
using PizzaWebApplication.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace storeWebApplication.Controllers
{
    public class StoreController : Controller
    {
        private readonly IRepositoryStore<Store1> _repo;
        public StoreController(IRepositoryStore<Store1> repo)
        {
            _repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var store = _repo.ReadInStore();
            var n = TempData["Name"];
            List<StoreViewModel> svm = new List<StoreViewModel>();
            foreach (var sto in store)
            {
                StoreViewModel sx = new StoreViewModel();
                sx.Id = sto.Id;
                sx.StoreLocation = sto.StoreLocation;
                sx.StoreName = sto.StoreName;
                svm.Add(sx);
            }
            return View(svm);
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult StorePortal(string StoreName, string Fname)
        {
            StoreOptionsViewModel sovm = new StoreOptionsViewModel
            {
                Fname = Fname,
                storeName = StoreName
            };
            CustomerInfo.storeName = StoreName;
            return View(sovm);
        }

        public IActionResult Create()
        {
            return View();
        }


        public IActionResult Create(StoreViewModel store)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Store1 sx = new Store1()
                    {
                        StoreName=store.StoreName,
                        StoreLocation=store.StoreLocation
                    };
                    _repo.CreateStore(sx);
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
