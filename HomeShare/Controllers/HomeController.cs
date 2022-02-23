using HolidayRental.Common;
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

        private readonly IGetRepository<HolidayRental.BLL.Models.BienAvecNomPAYS> _serviceBP;
        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContext , IGetRepository<HolidayRental.BLL.Models.BienAvecNomPAYS> serviceBP)
        {
            _logger = logger; 
            _httpContext=httpContext;

            this._serviceBP = serviceBP;
        }

        public IActionResult Index()
        {
            _httpContext.HttpContext.Session.SetObjectAsJson("Titre", "Welcome");

            return View();
        }        

    }
}
