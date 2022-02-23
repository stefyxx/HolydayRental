using HolidayRental.BLL.Handlers;
using HolidayRental.BLL.Models;
using HolidayRental.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HolidayRental.BLL.Repository
{
    public class PaysServices : IAllRepositoryBASE<BLL.Models.Pays>
    {
        private readonly IAllRepositoryBASE<DAL.Models.Pays> _repository;
        public PaysServices(IAllRepositoryBASE<DAL.Models.Pays> repository)
        {
            _repository = repository;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Pays Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }

        public IEnumerable<Pays> Get()
        {
            return _repository.Get().Select(d => d.ToBLL());
        }

        public int Insert(Pays entity)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Pays entity)
        {
            throw new NotImplementedException();
        }
    }
}
