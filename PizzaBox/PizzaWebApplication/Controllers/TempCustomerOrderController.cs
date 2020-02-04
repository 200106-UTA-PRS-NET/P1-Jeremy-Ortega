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
    public class TempCustomerOrderController : Controller
    {

        private IRepositoryTempCustomerOrder<TempCustomerOrder1> _repo;
        public TempCustomerOrderController(IRepositoryTempCustomerOrder<TempCustomerOrder1> repo)
        {
            _repo = repo;
        }


        // GET: TempCustomerOrder
        public ActionResult Index(int Id)
        {
            var currentOrder = _repo.ReadInOrder(Id).ToList();

            List<TempCustomerOrder> CurOrd = new List<TempCustomerOrder>();
            foreach (var Cx in CurOrd)
            {
                TempCustomerOrder CxOrd = new TempCustomerOrder();
                CxOrd.PizzaId = Cx.PizzaId;
                CxOrd.Price = Cx.Price;
                CxOrd.Toppings = Cx.Toppings;
                CxOrd.CustId = Cx.CustId;
                CxOrd.Crust = Cx.Crust;
                CxOrd.Size = Cx.Size;
                CurOrd.Add(Cx);
            }
  

        //[Key]
        ////[Column(Order=1)]
        //public int CustId { get; set; }

        //public int Toppings { get; set; }
        //public string Crust { get; set; }
        //public decimal Price { get; set; }
        //public int Size { get; set; }
        //public int StoreId { get; set; }
            return View(CurOrd);
        }

        // GET: TempCustomerOrder/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TempCustomerOrder/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TempCustomerOrder/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TempCustomerOrder/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TempCustomerOrder/Edit/5
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

        // GET: TempCustomerOrder/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TempCustomerOrder/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            
            try
            {
                // TODO: Add delete logic here
                _repo.DeleteOrder(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}