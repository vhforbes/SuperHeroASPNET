using Microsoft.AspNetCore.Mvc;
using FirstMVC.Models;

namespace FirstMVC.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            PersonViewModel Victor = new PersonViewModel()
            {
                name = "Victor",
                age = 26
            };

            return View(Victor);
        }

        public string World()
        {
            return "Hello World!";
        }
    }
}
