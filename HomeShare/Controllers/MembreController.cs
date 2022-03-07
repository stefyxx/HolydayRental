using HolidayRental.Common;
using HoliDayRental.Handlers;
using HoliDayRental.Models;
using HoliDayRental.Models.BienOptions;
using HoliDayRental.Models.Membre;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Controllers
{
    public class MembreController : Controller
    {
        private readonly IAllRepositoryBASE<HolidayRental.BLL.Models.Membre> _serviceM;
        private readonly IAllRepositoryBASE<HolidayRental.BLL.Models.Pays> _serviceP;
        private readonly IAllRepositoryBIEN<HolidayRental.BLL.Models.BienEchange> _service;

        public MembreController(IAllRepositoryBASE<HolidayRental.BLL.Models.Membre> serviceM, IAllRepositoryBASE<HolidayRental.BLL.Models.Pays> serviceP, IAllRepositoryBIEN<HolidayRental.BLL.Models.BienEchange> service)
        {
            this._serviceM = serviceM;
            this._serviceP = serviceP;
            this._service = service;
        }

        public ActionResult Index()
        {
            //return View();
            return RedirectToAction("ListaM");
        }

        public ActionResult ListaM()
        {
            try
            {
                IEnumerable<MembreNomId> listaMembri = _serviceM.Get().Select(m => m.ToLabeMembre());

                listaMembri = listaMembri.Select(m => { m.Pays = _serviceP.Get((int)m.idPays).ToPays(); return m; });

                return View(listaMembri);
            }
            catch (Exception e)
            {
                return Json(e);
            }
        }

        //LOGGIN


        public ActionResult Details(int id)
        {
            MembreDetails model = _serviceM.Get(id).ToDetailsMembre();
            model.Pays = _serviceP.Get((int)model.idPays).ToPays(); //NomPays pre-riempito

            return View(model);
        }

        public ActionResult Create()
        {
            MembreCreate model = new MembreCreate();
            model.Payses = _serviceP.Get().Select(p => p.ToPays());
            return View(model);

            //return RedirectToAction("Register", "Account");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MembreCreate collection)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                if (!collection.conditionAccepted) throw new Exception("Il faut accepter les conditions générales!");
                if (!collection.isValide) throw new Exception("Il faut valider le formulair!");

                HolidayRental.BLL.Models.Membre result = new HolidayRental.BLL.Models.Membre()
                {

                    Nom = collection.Nom,
                    Prenom = collection.Prenom,
                    Email = collection.Email,
                    Pays = collection.idPays,
                    Telephone = collection.Telephone,
                    Login = collection.Login,
                    Password = collection.Password
                };
                //recupero l'id perché in futuro, se LOGGATO, automaticamente inserisco un bene e ho l'ID
                result.idMembre = this._serviceM.Insert(result);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                collection.Payses = _serviceP.Get().Select(p => p.ToPays());
                return View(collection);
            }
        }

        // GET: MembreController/Edit/5
        public ActionResult Edit(int id)
        {
            MembreEdit model = this._serviceM.Get(id).ToEditMembre();
            model.Payses = _serviceP.Get().Select(p => p.ToPays());

            return View(model);
        }

        // POST: MembreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MembreEdit collection)
        {
            HolidayRental.BLL.Models.Membre result = _serviceM.Get(id);

            try
            {
                if (!ModelState.IsValid) throw new Exception();
                if (!collection.isValide) throw new Exception("Il faut valider le formulair!");
                //non do la possibilità di modofocare il suo nome
                result.Email = collection.Email;
                result.Pays = collection.idPays;
                result.Telephone = collection.Telephone;
                result.Login = collection.Login;
                if (collection.Password is not null) result.Password = collection.Password;

                this._serviceM.Update(id, result);
                return RedirectToAction(nameof(Index), "Home");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                collection.Payses = _serviceP.Get().Select(p => p.ToPays());
                return View(collection);
            }
        }

        // GET: MembreController/Delete/5
        public ActionResult Delete(int id)
        {
            MembreNomId model = this._serviceM.Get(id).ToLabeMembre();
            model.Pays = _serviceP.Get((int)model.idPays).ToPays();
            return View(model);
        }

        // POST: MembreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MembreNomId collection)
        {
            HolidayRental.BLL.Models.Membre result = _serviceM.Get(id);
            try
            {
                if (result is null) throw new Exception("Pas de membre avec cet identifiant.");
                if (!ModelState.IsValid) throw new Exception();
                if (!collection.isValide) throw new Exception("Il faut valider le formulair!");

                this._serviceM.Delete(id);
                return RedirectToAction(nameof(Index), "Home");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return RedirectToAction(nameof(Index), "Home");
            }
        }

        public ActionResult VisualizzaTuttiBeniONEmembre(int id)
        {
            IEnumerable<BienForMembreList> myBiens = _service.GetAllBiensParMembreSP(id).Select(b => b.ToBienFORmembre());
            //myBiens.Select
            return View(myBiens);
        }
    }
}
