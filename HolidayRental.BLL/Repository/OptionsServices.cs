using HolidayRental.BLL.Handlers;
using HolidayRental.BLL.Models;
using HolidayRental.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HolidayRental.BLL.Repository
{
    public class OptionsServices : IGetRepository<HolidayRental.BLL.Models.Options>
    {
        private readonly IGetRepository<HolidayRental.DAL.Models.Options> _repository;
        public OptionsServices(IGetRepository<HolidayRental.DAL.Models.Options> repository)
        {
            _repository = repository;
        }

        public Options Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }

        public IEnumerable<Options> Get()
        {
            return _repository.Get().Select(d => d.ToBLL());
        }
    }
}
