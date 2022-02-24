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

        //private readonly IGetRepository<HolidayRental.BLL.Models.BienAvecNomPAYS> _serviceBP;
        private readonly IAllRepositoryBIEN<HolidayRental.BLL.Models.BienEchange> _service; //qui' ho i methods di V et SP
        private readonly IAllRepositoryBASE<HolidayRental.BLL.Models.Pays> _serviceP;
        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContext, IAllRepositoryBIEN<HolidayRental.BLL.Models.BienEchange> service, IAllRepositoryBASE<HolidayRental.BLL.Models.Pays> serviceP)
        {
            _logger = logger; 
            _httpContext=httpContext;
            this._service = service;
            _serviceP = serviceP;
            //this._serviceBP = serviceBP;
        }

        public IActionResult Index()
        {
            //_httpContext.HttpContext.Session.SetObjectAsJson("Titre", "Welcome");

            /*creare un Model che ingloba le 2 view , una parziale
            * tener presente di IEnumerable<BienEchangeList> model = this._service.GetDernier5BienV().Select(bien => bien.ToListBien());
            */

            HomeIndex model = new HomeIndex();
            model.BienList = _service.GetDernier5BienV().Select(bien => bien.ToListBien());
            model.Payses = _serviceP.Get().Select(p => p.ToPays());
            model.BienList = model.BienList.Select(m => { m.PaysLibelle = _serviceP.Get((int)m.Pays).Libelle; return m; });

            return View(model);
        }        

    }
}
