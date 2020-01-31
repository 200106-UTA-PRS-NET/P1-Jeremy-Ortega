using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Storing.TestModels;
using PizzaBox.Storing.Abstractions;
using PizzaWebApplication.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaWebApplication.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IRepositoryPizza<Pizza1> _repo;
        public PizzaController(IRepositoryPizza<Pizza1> repo)
        {
            _repo = repo;
        }

        // GET: /<controller>/
        //[Route("")]
        [Route("Pizza")]
        [Route("Pizza/Index")]
        public IActionResult Index()
        {
            var pizza = _repo.ReadInPizza();

            List<PizzaViewModel> pvm = new List<PizzaViewModel>();
            foreach (var piz in pizza)
            {
                PizzaViewModel px = new PizzaViewModel();
                px.PizzaId = piz.PizzaId;
                px.Price = piz.Price;
                px.Toppings = piz.Toppings;
                px.OrderId = piz.OrderId;
                px.Crust = piz.Crust;
                px.Size = piz.Size;
                pvm.Add(px);
            }
            return View(pvm);
        }

        public IActionResult Create()
        {
            return View();
        }

        /*
        public ActionResult Details(int id = 1)
        {
            var pi = _repo.GetPizzaById(id);
            PizzaViewModel evm = new PizzaViewModel()
            {
                Size = pizza.Size,
                Price = pizza.Price,
                OrderId = pizza.OrderId,
                Crust = pizza.Crust,
                PizzaId = pizza.PizzaId,
                Toppings = pizza.Toppings
            };

            return View(evm);
        }
        */

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaViewModel pizza)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Pizza1 px = new Pizza1()
                    {
                        Size = pizza.Size,
                        Crust = pizza.Crust,
                        Toppings = pizza.Toppings,
                        //PizzaId = pizza.PizzaId,
                        //Price = pizza.Price,
                        //OrderId = pizza.OrderId
                    };
                    _repo.CreatePizza(px);
                   // return View();
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
