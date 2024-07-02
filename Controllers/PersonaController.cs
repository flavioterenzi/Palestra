using Microsoft.AspNetCore.Mvc;
using Palestra.Models;
using Palestra.Services;



namespace Palestra.Controllers
{
    public class PersonaController : Controller
    {
       
        private readonly PersonaService _service;

        public PersonaController(PersonaService service)
        {
            _service = service;
        }

        public IActionResult Registra()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult Salvataggio(Persona objProdotto)
        {
            if (_service.InserisciPersona(objProdotto))
                return Redirect("/Login");
            else
                return Redirect("/Index");
        }



        public IActionResult VerificaCredenziali(Persona objUtente)
        {

            if (objUtente.Email is null || objUtente.Password is null)
                return Redirect("/Autenticazione/Login");

            if (objUtente.Email == "giovanni" && objUtente.Password == "pace")
            {
                HttpContext.Response.Cookies.Append("userLogged", "ADMIN");
                return Redirect("/Autenticazione/Profiloamministratore");
            }

            if (objUtente.Email == "valeria" && objUtente.Password == "verdi")
            {
                HttpContext.Response.Cookies.Append("userLogged", "USER");
                return Redirect("/Autenticazione/Profiloutente");
            }

            return Redirect("/Autenticazione/Login");
        }

        public IActionResult Profiloamministratore()
        {
            string? valoreCookie = HttpContext.Request.Cookies["userLogged"];

            if (valoreCookie is not null && valoreCookie.Equals("ADMIN"))
                return View();

            return Redirect("/Autenticazione/Login");
        }

        public IActionResult Profiloutente()
        {
            string? valoreCookie = HttpContext.Request.Cookies["userLogged"];

            if (valoreCookie is not null && valoreCookie.Equals("USER"))
                return View();

            return Redirect("/Autenticazione/Login");
        }
    }
}
