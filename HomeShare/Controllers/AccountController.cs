using HolidayRental.Common;
using HoliDayRental.Handlers;
using HoliDayRental.Infrastructure.Helpers;
using HoliDayRental.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace HoliDayRental.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IAllRepositoryBASE<HolidayRental.BLL.Models.Membre> _serviceM;
        private readonly IAllRepositoryBASE<HolidayRental.BLL.Models.Pays> _serviceP;

        public AccountController(ILogger<AccountController> logger, IHttpContextAccessor httpContext, IAllRepositoryBASE<HolidayRental.BLL.Models.Membre> serviceM, IAllRepositoryBASE<HolidayRental.BLL.Models.Pays> serviceP)
        {
            _logger = logger;
            _httpContext = httpContext;
            this._serviceM = serviceM;
            this._serviceP = serviceP;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            MembreCreate model = new MembreCreate();
            model.Payses = _serviceP.Get().Select(p => p.ToPays());
            //model.Login = "";
            return View(model);
        }

        //Exemple d'ajout de valeur pour une session permettant de spécifier que l'utilisateur est connecté
        //[HttpPost]
        //public IActionResult Register()
        //{
        //    _httpContext.HttpContext.Session.SetObjectAsJson("IsLogged", true);
        //    return View();
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(MembreCreate collection)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                if (!collection.isValide) throw new Exception("Il faut valider le formulair!");

                //collection.Login assegnare o recuperare perche in set only 
                //dire al membre che il suo login e" P.Nommm
                _httpContext.HttpContext.Session.SetObjectAsJson("IsLogged", true);
                HolidayRental.BLL.Models.Membre result = new HolidayRental.BLL.Models.Membre()
                {

                    Nom = collection.Nom,
                    Prenom = collection.Prenom,
                    Email = collection.Email,
                    Pays = collection.idPays,
                    Telephone = collection.Telephone,
                    Login = collection.Login,
                    Password = collection.Password
                };
                result.idMembre = this._serviceM.Insert(result);
                return RedirectToAction(nameof(Index));
                //return View();
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                collection.Payses = _serviceP.Get().Select(p => p.ToPays());
                return View(collection);
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(IFormCollection collection)
        {
            try
            {

                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
