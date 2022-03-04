using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayRental.Common
{
    public interface IRepoOptionsONEbien<TEntity>
    {
        IEnumerable<TEntity> AllOptionsForONEBien(int idBien);
    }
}
