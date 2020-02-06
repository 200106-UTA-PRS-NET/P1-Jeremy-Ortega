using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Storing.TestModels;
using PizzaBox.Storing.Abstractions;
using PizzaWebApplication.Models;
using PizzaWebApplication.Data;
using PizzaBox.Domain;
using PizzaBox.Storing;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaWebApplication.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IRepositoryPizza<Pizza1> _repo;
        private readonly IRepositoryTempCustomerOrder<TempCustomerOrder1> _repo_tmp;

        public PizzaController(IRepositoryPizza<Pizza1> repo, IRepositoryTempCustomerOrder<TempCustomerOrder1> TCO)
        {
            _repo = repo;
            _repo_tmp = TCO;
        }

        // GET: /<controller>/
        //[Route("")]
        [Route("Pizza")]
        [Route("Pizza/Index")]
        public IActionResult Index()
        {
            var pizza = _repo.ReadInPizza().ToList();

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

        [HttpGet]
        public IActionResult CreateNewPizza()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateNewPizza(TempCustomerOrder tmp, 
            bool Sauce, bool Sausage, bool Pepperoni, bool Cheese, bool Pineapple,
            int Size, int Crust, int number)
        {
            if (Size > 100)
            {
                return View();
            }
            //int size = tmp.Size;
            //string crust = tmp.Crust;
            //bool sauce = tmp.sauce;
            //bool cheese = tmp.cheese;
            //bool pepperoni = tmp.pepperoni;
            //bool sausage = tmp.sausage;
            for (int i = 0; i < number; i++) {

                char[] tops = new char[5];
                if (Sauce)
                {
                    tops[0] = '1';
                }
                else
                {
                    tops[0] = '0';
                }
                if (Cheese)
                {
                    tops[1] = '1';
                }
                else
                {
                    tops[1] = '0';
                }
                if (Pepperoni)
                {
                    tops[2] = '1';
                }
                else
                {
                    tops[2] = '0';
                }
                if (Sausage)
                {
                    tops[3] = '1';
                }
                else
                {
                    tops[3] = '0';
                }
                if (Pineapple)
                {
                    tops[4] = '1';
                }
                else
                {
                    tops[4] = '0';
                }

                // add pizza cypher to format code into database model
                PizzaOrderCypher POC = new PizzaOrderCypher();
                POC.setCrust(Crust);
                POC.setSize(Size);
                POC.setToppings(tops);
                POC.getPriceOfPizza();

                // Add Full Order to POC current Customer order.
                ViewBag.id = tmp.PizzaId + 1;
                FullOrder.storeID = CustomerInfo.StoreId;
                FullOrder.UserID = CustomerInfo.Id;
                FullOrder.currOrder.Add(POC);

                TempCustomerOrder1 TCO = new TempCustomerOrder1();

                TCO.Toppings = BitFlagConversion.convertFlagArrayToInt(tops);
                TCO.Size = POC.size;
                TCO.Crust = POC.crust;
                TCO.CustId = CustomerInfo.Id;
                TCO.StoreId = CustomerInfo.StoreId;
                TCO.PizzaId = new Random().Next(10000000, 100000000);
                TCO.Price = POC.price;

                _repo_tmp.CreateOrder(TCO);
            }
            return View();
        }









        [HttpPost]
        public IActionResult CompleteOrder(IEnumerable<bool> Pepperoni)
        {
            if (Pepperoni != null)
            {

            }

            //                < div class="form-check form-check-inline">
            //    <input class="form-check-input" type="checkbox" id="inlineCheckbox5" value="option5">
            //    <label class="form-check-label" for="inlineCheckbox5">Pineapple</label>
            //</div>
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




        [HttpGet]
        public IActionResult OrderPremadePizza()
        {
            return View();
        }
        [HttpPost]
        public IActionResult OrderPremadePizza(TempCustomerOrder tmp,
            string pizza, int Size, int Crust, int number)
        {
            //int size = tmp.Size;
            //string crust = tmp.Crust;
            //bool sauce = tmp.sauce;
            //bool cheese = tmp.cheese;
            //bool pepperoni = tmp.pepperoni;
            //bool sausage = tmp.sausage;
            for (int i = 0; i < number; i++)
            {

                char[] tops = new char[5];
                tops[0] = '1';
                tops[1] = '1';
 
                if (pizza[2].Equals("Pepperoni") || pizza[2].Equals("Meat Lovers"))
                {
                    tops[2] = '1';
                }
                else
                {
                    tops[2] = '0';
                }
                if (pizza[3].Equals("Sausage") || pizza[3].Equals("MeatLovers"))
                {
                    tops[3] = '1';
                }
                else
                {
                    tops[3] = '0';
                }
                if (pizza[4].Equals("Hawaiian"))
                {
                    tops[4] = '1';
                }
                else
                {
                    tops[4] = '0';
                }

                // add pizza cypher to format code into database model
                PizzaOrderCypher POC = new PizzaOrderCypher();
                POC.setCrust(Crust);
                POC.setSize(Size);
                POC.setToppings(tops);
                POC.getPriceOfPizza();

                // Add Full Order to POC current Customer order.
                ViewBag.id = tmp.PizzaId + 1;
                FullOrder.storeID = CustomerInfo.StoreId;
                FullOrder.UserID = CustomerInfo.Id;
                FullOrder.currOrder.Add(POC);

                TempCustomerOrder1 TCO = new TempCustomerOrder1();

                TCO.Toppings = BitFlagConversion.convertFlagArrayToInt(tops);
                TCO.Size = POC.size;
                TCO.Crust = POC.crust;
                TCO.CustId = CustomerInfo.Id;
                TCO.StoreId = CustomerInfo.StoreId;
                TCO.PizzaId = new Random().Next(10000000, 100000000);
                TCO.Price = POC.price;

                _repo_tmp.CreateOrder(TCO);
            }
            return View();
        }
    }
}
