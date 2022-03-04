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
        public BienOptionController(IAllRepositoryBIEN<HolidayRental.BLL.Models.BienEchange> service, IAllRepositoryBASE<HolidayRental.BLL.Models.Pays> serviceP, IAllRepositoryBASE<HolidayRental.BLL.Models.Membre> serviceM, IRepoOptionsONEbien<HolidayRental.BLL.Models.OptionsBienWithLabel_forONEBien> serviceAllOptionsONEbien)
        {
            this._service = service;
            this._serviceM = serviceM;
            this._serviceP = serviceP;
            this._serviceAllOptionsONEbien = serviceAllOptionsONEbien;

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

        // GET: BienOption/Create
        public ActionResult Create()
        {
            return View();
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
