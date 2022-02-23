﻿using HolidayRental.Common;
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
        private readonly IAllRepositoryBASE<HolidayRental.BLL.Models.Pays> _serviceP;
        private readonly IGetRepository<HolidayRental.BLL.Models.BienAvecNomPAYS> _serviceBP;

        public BienEchangeController(IAllRepositoryBIEN<HolidayRental.BLL.Models.BienEchange> service, IGetRepository<HolidayRental.BLL.Models.BienAvecNomPAYS> serviceBP, IAllRepositoryBASE<HolidayRental.BLL.Models.Pays> serviceP, IAllRepositoryBASE<HolidayRental.BLL.Models.Membre> serviceM)
        {
            this._service = service;
            this._serviceBP = serviceBP;
            this._serviceM = serviceM;
            this._serviceP = serviceP;
        }

        public ActionResult Index()
        {
            //IEnumerable<BienEchangeList> model = this._service.Get().Select(bien => bien.ToListBien());

            //.SelectMany(bien => bien.Pays);
            //_serviceP.Get(bien.Pays).libelle

            IEnumerable<BienAvecPAYS> model = _serviceBP.Get().Select(d => d.ToListBienPAYS());
            return View(model);
        }

        public ActionResult Details(int id)
        {
            //BienEchangeDetails model = _serviceBP.Get(id).ToDetailsBien();

            BienEchangeDetails model = _service.Get(id).ToDetBienSansPay();
            Pays pays = _serviceP.Get(model.idBien).ToPays();
            model.libellePays = pays.Libelle;

            return View(model);
        }


        public ActionResult Create()
        {
            //label Pays
            //label idMembre
            //DateTime DateCreation = DateTime.Now;
            //isEnabled = true;

            BienCreate model = new BienCreate();

            IEnumerable<Pays> listPays = _serviceP.Get().Select(d => d.ToPays());
            model.PaysPossible = listPays;
            //IEnumerable<MembreNomId> listClients = _serviceM.Get().Select(d => d.ToLabeMembre());
            //model.listMembre = listClients;

            model.DateCreation = DateTime.Now;
            model.isEnabled = true;

            return View(model);
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
