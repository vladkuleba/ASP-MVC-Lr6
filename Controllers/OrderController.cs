using ASP_MVC_Lr6.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC_Lr6.Controllers
{
    public class OrderController : Controller
    {
        private List<Product> AvailableProducts = new List<Product>
        {
            new Product { Id = 1, Name = "Маргарита", Price = 100, Ingredients = "Томатний соус, моцарела, базилік", Size = "Середня" },
            new Product { Id = 2, Name = "Пепероні", Price = 120, Ingredients = "Томатний соус, моцарела, пепероні", Size = "Середня" },
            new Product { Id = 3, Name = "Гавайська", Price = 130, Ingredients = "Томатний соус, моцарела, шинка, ананас", Size = "Середня" }
        };

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (user.Age < 16)
            {
                return View("Error", new ErrorViewModel { RequestId = "Вибачте, але вам має бути 16 років або більше, щоб замовити піцу." });
            }

            return RedirectToAction("Order", new { name = user.Name, age = user.Age });
        }

        [HttpGet]
        public IActionResult Order()
        {
            var viewModel = new OrderViewModel { Products = AvailableProducts };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SelectPizza(int quantity)
        {
            var pizzaOptions = new List<Product>
            {
                new Product { Id = 1, Name = "Маргарита", Price = 100, Ingredients = "томатний соус, моцарела, базилік", Size = "Середній" },
                new Product { Id = 2, Name = "Пепероні", Price = 120, Ingredients = "томатний соус, моцарела, пепероні", Size = "Середній" },
                new Product { Id = 3, Name = "Гавайська", Price = 130, Ingredients = "томатний соус, моцарела, шинка, ананас", Size = "Середній" }
            };

            ViewBag.Quantity = quantity;
            ViewBag.PizzaOptions = pizzaOptions;

            return View();
        }


        [HttpPost]
        public IActionResult CompleteOrder(int[] selectedPizzas)
        {
            var allPizzaOptions = new List<Product>
    {
        new Product { Id = 1, Name = "Маргарита", Price = 100, Ingredients = "томатний соус, моцарела, базилік", Size = "Середній" },
        new Product { Id = 2, Name = "Пепероні", Price = 120, Ingredients = "томатний соус, моцарела, пепероні", Size = "Середній" },
        new Product { Id = 3, Name = "Гавайська", Price = 130, Ingredients = "томатний соус, моцарела, шинка, ананас", Size = "Середній" }
    };

            var orderedPizzas = allPizzaOptions.Where(p => selectedPizzas.Contains(p.Id)).ToList();

            return View(orderedPizzas);
        }

    }
}
