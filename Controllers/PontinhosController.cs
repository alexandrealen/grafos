using Microsoft.AspNetCore.Mvc;
using pontinhos.Grafos;

namespace pontinhos.Controllers
{
    public class PontinhosController : Controller
    {
        public PontinhosController() 
        {

        }
        public IActionResult Index()
        {
            return View();
        }

        public Grafo Random()
        {
            var random = new Random();

            var verticesQty = random.Next(2, 30);

            var grafo = new Grafo(verticesQty);

            return grafo;
        }
    }
}