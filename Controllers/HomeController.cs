using Microsoft.AspNetCore.Mvc;
using TP09.Models;

namespace TP09.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Juego juego;
            if(HttpContext.Session.GetString("juego") == null)
            {
                juego = new Juego();
                HttpContext.Session.SetString("juego", Objeto.ObjectToString<Juego>(juego));
            }else
            {
                juego = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("juego"));
            }
            ViewBag.Jugadores = juego.DevolverListaUsuarios();
            return View();
        }

        [HttpPost]
        public IActionResult Comenzar(string username, int dificultad)
        {
            Juego juego = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("juego"));
            juego.InicializarJuego(username, dificultad);
            HttpContext.Session.SetString("juego", Objeto.ObjectToString<Juego>(juego));
            ViewBag.Username = juego.JugadorActual.Nombre;
            ViewBag.Palabra = juego.PalabraActual;
            ViewBag.Intentos = juego.JugadorActual.CantidadIntentos;
            return View("Juego");
        }
        [HttpPost]
        public IActionResult FinJuego(int intentos)
        {
            Juego juego = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("juego"));
            juego.JugadorActual.ActualizarCantidadIntentos(intentos);
            juego.FinJuego();
            HttpContext.Session.SetString("juego", Objeto.ObjectToString<Juego>(juego));
            return RedirectToAction("Index");
        }
    }
}