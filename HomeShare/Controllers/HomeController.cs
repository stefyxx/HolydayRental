using HolidayRental.Common;
using HoliDayRental.Handlers;
using HoliDayRental.Infrastructure.Helpers;
using HoliDayRental.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContext;

        private readonly IAllRepositoryBIEN<HolidayRental.BLL.Models.BienEchange> _service;
        //private readonly IGetRepository<HolidayRental.BLL.Models.BienAvecNomPAYS> _serviceBP;
        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContext, IGetRepository<HolidayRental.BLL.Models.BienAvecNomPAYS> serviceBP, IAllRepositoryBIEN<HolidayRental.BLL.Models.BienEchange> service)
        {
            _logger = logger; 
            _httpContext=httpContext;
            this._service = service;
            //this._serviceBP = serviceBP;
        }

        public IActionResult Index()
        {
            _httpContext.HttpContext.Session.SetObjectAsJson("Titre", "Welcome");

            IEnumerable<BienEchangeList> model = this._service.GetDernier5BienV().Select(bien => bien.ToListBien());
            return View();
        }        

    }
}
