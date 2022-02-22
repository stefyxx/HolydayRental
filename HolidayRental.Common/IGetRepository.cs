using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayRental.Common
{
    public interface IGetRepository<TEntity>
    {
       TEntity Get(int id);
       IEnumerable<TEntity> Get();
    }
}
