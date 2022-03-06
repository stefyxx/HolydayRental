using HolidayRental.Common;
using HoliDayRental.Handlers;
using HoliDayRental.Models.BienOptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Controllers
{
    public class BienOptionController : Controller
    {
        private readonly IAllRepositoryBASE<HolidayRental.BLL.Models.Membre> _serviceM;
        private readonly IAllRepositoryBIEN<HolidayRental.BLL.Models.BienEchange> _service;
        private readonly IAllRepositoryBASE<HolidayRental.BLL.Models.Pays> _serviceP;
        private readonly IRepoOptionsONEbien<HolidayRental.BLL.Models.OptionsBienWithLabel_forONEBien> _serviceAllOptionsONEbien;
        private readonly IGetRepository<HolidayRental.BLL.Models.Options> _serviceO;

        public BienOptionController(IAllRepositoryBIEN<HolidayRental.BLL.Models.BienEchange> service, IAllRepositoryBASE<HolidayRental.BLL.Models.Pays> serviceP, IAllRepositoryBASE<HolidayRental.BLL.Models.Membre> serviceM, IRepoOptionsONEbien<HolidayRental.BLL.Models.OptionsBienWithLabel_forONEBien> serviceAllOptionsONEbien, IGetRepository<HolidayRental.BLL.Models.Options> serviceO)
        {
            this._service = service;
            this._serviceM = serviceM;
            this._serviceP = serviceP;
            this._serviceAllOptionsONEbien = serviceAllOptionsONEbien;
            this._serviceO = serviceO;

        }
        // GET: BienOption
        public ActionResult Index()
        {
            return View();
        }

        // GET: /BienOption/Details/2
        public ActionResult Details(int id)
        {
            BienOptionsDetails model = _service.Get(id).ToBienDet();
            model.payses = _serviceP.Get((int)model.idPays).ToPays();

            model.options = _serviceAllOptionsONEbien.AllOptionsForONEBien(id).Select(bOp => bOp.ToOptionsForONEbien());

            return View(model);
        }

        // GET: /BienOption/Create
        public ActionResult Create()
        {
            /*model: recuperare lista Pays
             *       recuperare Loggin ->idMembre => per ora seleziono io il 'Membre'
             *       recuperare opzioni possibili   */
            BienOptionsCreate model = new BienOptionsCreate();
            model.PaysPossible = _serviceP.Get().Select(p => p.ToPays());
            model.listaOptions = _serviceO.Get().Select(o => o.ToOption());

            //verrà modofocato LOGGIN -> mi darà idMembre
            model.listMembre = _serviceM.Get().Select(m => m.ToLabeMembre());
            model.DateCreation = DateTime.Now;
            model.isEnabled = true;

            return View(model);
        }

        // POST: BienOption/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BienOption/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BienOption/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BienOption/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BienOption/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
