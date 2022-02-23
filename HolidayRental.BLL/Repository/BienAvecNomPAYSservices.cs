using HolidayRental.BLL.Handlers;
using HolidayRental.BLL.Models;
using HolidayRental.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HolidayRental.BLL.Repository
{
    public class BienAvecNomPAYSservices : IGetRepository<BLL.Models.BienAvecNomPAYS>
    {
        private readonly IAllRepositoryBASE<DAL.Models.BienAvecNomPAYS> _repository;
        public BienAvecNomPAYSservices(IAllRepositoryBASE<DAL.Models.BienAvecNomPAYS> repository)
        {
            _repository = repository;
        }
        public BienAvecNomPAYS Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }

        public IEnumerable<BienAvecNomPAYS> Get()
        {
            return _repository.Get().Select(d => d.ToBLL());
        }
    }
}
