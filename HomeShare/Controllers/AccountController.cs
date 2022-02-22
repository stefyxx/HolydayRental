using HoliDayRental.Infrastructure.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HoliDayRental.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IHttpContextAccessor _httpContext;

        public AccountController(ILogger<AccountController> logger, IHttpContextAccessor httpContext)
        {
            _logger = logger;
            _httpContext = httpContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        //Exemple d'ajout de valeur pour une session permettant de spécifier que l'utilisateur est connecté
        //[HttpPost]
        //public IActionResult Register()
        //{
        //    _httpContext.HttpContext.Session.SetObjectAsJson("IsLogged", true);
        //    return View();
        //}
    }
}
