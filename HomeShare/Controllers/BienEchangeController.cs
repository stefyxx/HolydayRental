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
        private readonly IAllRepositoryBASE<HolidayRental.BLL.Models.Pays> _serviceP;
        private readonly IGetRepository<HolidayRental.BLL.Models.BienAvecNomPAYS> _serviceBP;
        //J'ai oublié les OPTIONS a ajouter aprés
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
            /*per il futuro: a modificare:
            *perché posso creare un bene se LOGGATO
            *posso affittare un bene se LOGGATO
             -> idMembre recuperato in CreationMembre ... da sviluppare*/ 

            //label Pays
            //label idMembre
            //DateTime DateCreation = DateTime.Now;
            //isEnabled = true;

            BienCreate model = new BienCreate();

            IEnumerable<Pays> listPays = _serviceP.Get().Select(d => d.ToPays());
            model.PaysPossible = listPays;

            IEnumerable<MembreNomId> listClients = _serviceM.Get().Select(d => d.ToLabeMembre());
            model.listMembre = listClients;

            model.DateCreation = DateTime.Now;
            model.isEnabled = true;

            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BienCreate collection)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                if (!collection.isValide) throw new Exception("Il faut valider le formulair!");
                if(collection.DisabledDate == DateTime.Now) throw new Exception("Il faut DONNER LA POSSIBILITe' DE LOUER VOTRE BIEN !");

                //BienCreate devo trasformarla in BLL.Bien:
                HolidayRental.BLL.Models.BienEchange result = new HolidayRental.BLL.Models.BienEchange() {
                    idBien = collection.idBien,
                    titre = collection.titre,
                    DescCourte = collection.DescCourte,
                    DescLong = collection.DescLong,
                    NombrePerson =collection.NombrePerson,
                    Pays= collection.Pays,
                    Ville =collection.Ville,
                    Rue =collection.Rue,
                    Numero =collection.Numero,
                    CodePostal = collection.CodePostal,
                    Photo = collection.Photo,
                    AssuranceObligatoire = collection.AssuranceObligatoire,
                    isEnabled = true,
                    DisabledDate= collection.DisabledDate,
                    Latitude = collection.Latitude,
                    Longitude = collection.Longitude,
                    idMembre = collection.idMembre,
                    DateCreation = DateTime.Now
                };
                this._service.Insert(result);
                return RedirectToAction(nameof(Index),"Home");
            }
            catch(Exception e)
            {
                ViewBag.Error = e.Message;
                //riempio di nuovo il select:
                IEnumerable<Pays> listPays = _serviceP.Get().Select(d => d.ToPays());
                IEnumerable<MembreNomId> listClients = _serviceM.Get().Select(d => d.ToLabeMembre());
                collection.PaysPossible = listPays;
                collection.listMembre = listClients;

                collection.DateCreation = DateTime.Now;
                collection.isEnabled = true;

                return View(collection);
            }
        }

        public ActionResult Edit(int id)
        {
            BienEdite model = this._service.Get(id).ToEditeBien();

            IEnumerable<Pays> listPays = _serviceP.Get().Select(d => d.ToPays());
            model.PaysPossible = listPays;
            return View(model);
        }

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
