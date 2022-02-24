using HolidayRental.BLL.Handlers;
using HolidayRental.BLL.Models;
using HolidayRental.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HolidayRental.BLL.Repository
{
    public class OptionBienServices : IGetRepositotyTwoInt<HolidayRental.BLL.Models.OptionsBien, int, int>
    {
        private readonly IGetRepositotyTwoInt<HolidayRental.DAL.Models.OptionsBien, int, int>  _repository;
        public OptionBienServices(IGetRepositotyTwoInt<HolidayRental.DAL.Models.OptionsBien, int, int> repository)
        {
            _repository = repository;
        }

        public OptionsBien Get(int idOption, int idBien)
        {
            return _repository.Get(idOption, idBien).ToBLL();
        }

        public IEnumerable<OptionsBien> Get()
        {
            return _repository.Get().Select(d => d.ToBLL());
        }
    }
}
