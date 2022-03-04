using HolidayRental.BLL.Handlers;
using HolidayRental.BLL.Models;
using HolidayRental.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HolidayRental.BLL.Repository
{
    public class OptionsBienWithLabel_forONEBienServices : IRepoOptionsONEbien<HolidayRental.BLL.Models.OptionsBienWithLabel_forONEBien>
    {
        private readonly IRepoOptionsONEbien<HolidayRental.DAL.Models.OptionsBienWithLabel_forONEBien> _repository;
        public OptionsBienWithLabel_forONEBienServices(IRepoOptionsONEbien<HolidayRental.DAL.Models.OptionsBienWithLabel_forONEBien> repository)
        {
            _repository = repository;
        }
        public IEnumerable<OptionsBienWithLabel_forONEBien> AllOptionsForONEBien(int idBien)
        {
            return _repository.AllOptionsForONEBien(idBien).Select(bop => bop.ToBLL());
        }
    }
}
