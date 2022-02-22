﻿using HolidayRental.BLL.Handlers;
using HolidayRental.BLL.Models;
using HolidayRental.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HolidayRental.BLL.Repository
{
    public class BienEchangeServices : IAllRepositoryBASE<BLL.Models.BienEchange>
    {
        private readonly IAllRepositoryBASE<DAL.Models.BienEchange> _repository;
        public BienEchangeServices(IAllRepositoryBASE<DAL.Models.BienEchange> repository)
        {
            _repository = repository;
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public BienEchange Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }

        public IEnumerable<BienEchange> Get()
        {
            return _repository.Get().Select(d => d.ToBLL());
        }

        public int Insert(BienEchange entity)
        {
            return _repository.Insert(entity.ToDAL());
        }

        public void Update(int id, BienEchange entity)
        {
            _repository.Update(id, entity.ToDAL());
        }

        public IEnumerable<BienEchange> GetLibreSP(DateTime dateDebut, DateTime dateFin)
        {
            return _repository.Get().Select(d => d.ToBLL());
        }

        public IEnumerable<BienEchange> GetAllBiensParMembreSP(int idMembro)
        {
            return _repository.Get().Select(d => d.ToBLL());
        }

        public IEnumerable<BienEchange> GetMeilleurBienV()
        {
            return _repository.Get().Select(d => d.ToBLL());
        }

        public IEnumerable<BienEchange> GetDernier5BienV()
        {
            return _repository.Get().Select(d => d.ToBLL());
        }

        public IEnumerable<BienEchange> GetBienParPaysV()
        {
            return _repository.Get().Select(d => d.ToBLL());
        }

        //per usare sp_recupToutesInfosBien DEVO creare un'entity ad OK
    }
}
