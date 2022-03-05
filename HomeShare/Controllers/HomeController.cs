using HolidayRental.Common;
using HoliDayRental.Handlers;
using HoliDayRental.Infrastructure.Helpers;
using HoliDayRental.Models;
using HoliDayRental.Models.BienOptions;
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

        private readonly IAllRepositoryBIEN<HolidayRental.BLL.Models.BienEchange> _service; //qui' ho i methods di V et SP
        private readonly IAllRepositoryBASE<HolidayRental.BLL.Models.Pays> _serviceP;
        private readonly IRepoOptionsONEbien<HolidayRental.BLL.Models.OptionsBienWithLabel_forONEBien> _serviceAllOptionsONEbien; //qui' recupero tutte les options di UN bene

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContext, IAllRepositoryBIEN<HolidayRental.BLL.Models.BienEchange> service, IAllRepositoryBASE<HolidayRental.BLL.Models.Pays> serviceP, IRepoOptionsONEbien<HolidayRental.BLL.Models.OptionsBienWithLabel_forONEBien> serviceAllOptionsONEbien)
        {
            _logger = logger;
            _httpContext = httpContext;

            this._service = service;
            this._serviceP = serviceP;
            this._serviceAllOptionsONEbien = serviceAllOptionsONEbien;
        }
        //trucchetto per far apparire la parola sotto la foto
        public List<string> mots = new List<string> { "Pépite", "Sold", "New", "" };
        public Random random = new Random();
        public IActionResult Index()
        {
            //_httpContext.HttpContext.Session.SetObjectAsJson("Titre", "Welcome");

            /*creare un Model che ingloba le 3 view , 2 parziali
            * tener presente di IEnumerable<BienEchangeList> model = this._service.GetDernier5BienV().Select(bien => bien.ToLastFiveBien());
            */


            HomeIndex model = new HomeIndex();

            //NEL CORPO : lista di tutti i beni
            model.BienList = _service.Get().Select(b => b.TOPbien());
            //riempio la nazione, cosi' ho il 'libelle'
            model.BienList = model.BienList.Select(p => { p.payses = _serviceP.Get((int)p.Pays).ToPays(); return p; });

            //NEL CAROSELLO:i 15 migliori
            model.BienMeilleurs15Avis = _service.GetMeilleur15BienV().Select(bien => bien.ToBienDet());
            model.BienMeilleurs15Avis = model.BienMeilleurs15Avis.Select(bien =>
             {
                 bien.options = (IEnumerable<ONEoptionsForONEbien>)_serviceAllOptionsONEbien.AllOptionsForONEBien((int)bien.idBien).Select(opt => opt.ToOptionsForONEbien());
                 return bien;
             });
            model.BienMeilleurs15Avis = model.BienMeilleurs15Avis.Select(bien =>
            {
                bien.mot = mots[random.Next(mots.Count - 1)];
                return bien;
            });

            //NEL PIEDE : gli ultimi 5 inseriti
            model.BiensDerniers5 = _service.GetDernier5BienV().Select(bien => bien.ToLastFiveBien());

            return View(model);
        }

    }
}
