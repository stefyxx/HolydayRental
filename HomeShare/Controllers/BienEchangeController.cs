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
        private readonly IGetRepository<HolidayRental.BLL.Models.Options> _serviceO;
        public BienEchangeController(IAllRepositoryBIEN<HolidayRental.BLL.Models.BienEchange> service, IGetRepository<HolidayRental.BLL.Models.BienAvecNomPAYS> serviceBP, IAllRepositoryBASE<HolidayRental.BLL.Models.Pays> serviceP, IAllRepositoryBASE<HolidayRental.BLL.Models.Membre> serviceM, IGetRepository<HolidayRental.BLL.Models.Options> serviceO)
        {
            this._service = service;
            this._serviceBP = serviceBP;
            this._serviceM = serviceM;
            this._serviceP = serviceP;
            this._serviceO = serviceO;
        }

        public ActionResult Index()
        {
            //IEnumerable<BienEchangeList> model = this._service.Get().Select(bien => bien.ToLastFiveBien()); //mapper modificato x un altro obj, questo non esiste piu'

            //.SelectMany(bien => bien.Pays);
            //_serviceP.Get(bien.Pays).libelle

            IEnumerable<BienAvecPAYS> model = _serviceBP.Get().Select(d => d.ToListBienPAYS());
            return View(model);
        }

        public ActionResult Details(int id)
        {
            //BienEchangeDetails model = _serviceBP.Get(id).ToDetailsBien();

            BienEchangeDetails model = _service.Get(id).ToDetBienSansPay();
            Pays pays = _serviceP.Get(model.Pays).ToPays();
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
            // il get(id) ha già il suo idMembre che non deve essere modificato
            IEnumerable<Pays> listPays = _serviceP.Get().Select(d => d.ToPays());
            model.PaysPossible = listPays;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BienEdite collection)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                if (!collection.isValide) throw new Exception("Il faut valider le formulair!");

                //collection.idMembre = _service.Get(id).idMembre;
                //collection.DateCreation = _service.Get(id).DateCreation;

                //BienEdite ->in BLL.Bien:
                HolidayRental.BLL.Models.BienEchange result = new HolidayRental.BLL.Models.BienEchange()
                {
                    idBien = collection.idBien,
                    titre = collection.titre,
                    DescCourte = collection.DescCourte,
                    DescLong = collection.DescLong,
                    NombrePerson = collection.NombrePerson,
                    Pays = collection.Pays,
                    Ville = collection.Ville,
                    Rue = collection.Rue,
                    Numero = collection.Numero,
                    CodePostal = collection.CodePostal,
                    Photo = collection.Photo,
                    AssuranceObligatoire = collection.AssuranceObligatoire,
                    isEnabled = collection.isEnabled,
                    DisabledDate = collection.DisabledDate,
                    Latitude = collection.Latitude,
                    Longitude = collection.Longitude,
                    idMembre = _service.Get(id).idMembre,
                    DateCreation = _service.Get(id).DateCreation
                };
                this._service.Update(id,result);
                return RedirectToAction(nameof(Index),"Home");
            }
            catch(Exception e)
            {
                ViewBag.Error = e.Message;
                //riempio di nuovo il select:
                IEnumerable<Pays> listPays = _serviceP.Get().Select(d => d.ToPays());
                collection.PaysPossible = listPays;

                return View(collection);
            }
        }

        public ActionResult Delete(int id)
        {
            BienDelete model = _service.Get(id).ToDeleteBien();
            model.Pays = _serviceP.Get((int)model.idPays).ToPays();
            model.membre = _serviceM.Get((int)model.idMembre).ToLabeMembre();
            return View(model);
        }

        // POST: BienEchangeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, BienDelete collection)
        {
            //e se un pirata non passa x l'interfaccia ma dall'url?
            HolidayRental.BLL.Models.BienEchange result = this._service.Get(id);

            try
            {
                if (!ModelState.IsValid) throw new Exception();
                if (!collection.isValide) throw new Exception("Il faut valider le formulair!");
                if (result is null) throw new Exception("Nessun developer con questo identificante");

                this._service.Delete(id);
                return RedirectToAction(nameof(Index),"Home");
            }
            catch(Exception e)
            {
                ViewBag.Error = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        public ActionResult ViewOk()
        {
            return View();
        }

        public ActionResult Test()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Test(IFormCollection collection)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                return Json(collection);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return Json(e);
            }
        }
    }
}
