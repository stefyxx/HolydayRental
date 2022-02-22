using HolidayRental.Common;
using HoliDayRental.Handlers;
using HoliDayRental.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Controllers
{
    public class BienEchangeController : Controller
    {
        private readonly IAllRepositoryBASE<HolidayRental.BLL.Models.Membre> _serviceM;
        private readonly IAllRepositoryBIEN<HolidayRental.BLL.Models.BienEchange> _service;
        public BienEchangeController(IAllRepositoryBASE<HolidayRental.BLL.Models.Membre> serviceM, IAllRepositoryBIEN<HolidayRental.BLL.Models.BienEchange> service)
        {
            this._service = service;
            this._serviceM = serviceM;
        }

        public ActionResult Index()
        {
            IEnumerable<BienEchangeList> model = this._service.GetBienParPaysV().Select(bien => bien.ToListBien());
           
           //.SelectMany(bien => bien.Pays);

           //_servicePays.Get(bien.Pays).libelle

            return View(model);
        }

        // GET: BienEchangeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BienEchangeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BienEchangeController/Create
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

        // GET: BienEchangeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BienEchangeController/Edit/5
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

        // GET: BienEchangeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BienEchangeController/Delete/5
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
