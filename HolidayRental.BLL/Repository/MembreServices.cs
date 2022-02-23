using HolidayRental.BLL.Handlers;
using HolidayRental.BLL.Models;
using HolidayRental.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HolidayRental.BLL.Repository
{
    public class MembreServices : IAllRepositoryBASE<HolidayRental.BLL.Models.Membre>
    {
        private readonly IAllRepositoryBASE<HolidayRental.DAL.Models.Membre> _repository;
        public MembreServices(IAllRepositoryBASE<HolidayRental.DAL.Models.Membre> repository)
        {
            _repository = repository;
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Membre Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }

        public IEnumerable<Membre> Get()
        {
            return _repository.Get().Select(d => d.ToBLL());
        }

        public int Insert(Membre entity)
        {
            return _repository.Insert(entity.ToDAL());
        }

        public void Update(int id, Membre entity)
        {
            _repository.Update(id, entity.ToDAL());
        }
    }
}
