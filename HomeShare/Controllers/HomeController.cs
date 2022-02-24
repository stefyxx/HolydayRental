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
        private readonly IGetRepository<HolidayRental.BLL.Models.Options> _serviceO;
        private readonly IGetRepositotyTwoInt<HolidayRental.BLL.Models.OptionsBien, int, int> _serviceOB;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContext, IAllRepositoryBIEN<HolidayRental.BLL.Models.BienEchange> service, IAllRepositoryBASE<HolidayRental.BLL.Models.Pays> serviceP, IGetRepository<HolidayRental.BLL.Models.Options> serviceO, IGetRepositotyTwoInt<HolidayRental.BLL.Models.OptionsBien, int, int> serviceOB)
        {
            _logger = logger; 
            _httpContext=httpContext;
            this._service = service;
            _serviceP = serviceP;
            _serviceO = serviceO;
            _serviceOB = serviceOB;
            //this._serviceBP = serviceBP;
        }

        public IActionResult Index()
        {
            //_httpContext.HttpContext.Session.SetObjectAsJson("Titre", "Welcome");

            /*creare un Model che ingloba le 2 view , una parziale
            * tener presente di IEnumerable<BienEchangeList> model = this._service.GetDernier5BienV().Select(bien => bien.ToListBien());
            */

            HomeIndex model = new HomeIndex();
            model.Payses = _serviceP.Get().Select(p => p.ToPays());

            //NEL CAROSELLO: gli ultimi 5 inseriti
            model.BienListDernier5 = _service.GetDernier5BienV().Select(bien => bien.ToListBien());
            model.BienListDernier5 = model.BienListDernier5.Select(m => { m.PaysLibelle = _serviceP.Get((int)m.Pays).Libelle; return m; });

            //NEL CORPO : i 5 migliori
            model.BienListTopList = _service.Get().Select(b => b.TOPbien());
            model.BienListTopList = model.BienListTopList.Select(m => { m.options = _serviceOB.Get((int)(m.options.), (int)m.idBien); return m });
            //_serviceOB.Get( 2 interi 1idOption et 1 idBien
            //model.BienListTopList = _service.GetMeilleurBienV().Select(b => b.ToListBien());



            return View(model);
        }        

    }
}
