using Microsoft.AspNetCore.Mvc;
using pontinhos.Grafos;

namespace pontinhos.Controllers
{
    public class PontinhosController : Controller
    {
        public IActionResult Index() => View();

        public Grafo Random()
        {
            return new Grafo(new Random().Next(2, 30));
        }
    }
}