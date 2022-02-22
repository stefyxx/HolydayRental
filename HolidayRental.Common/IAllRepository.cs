using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayRental.Common
{
    public interface IAllRepository<TEntity>:IGetRepository<TEntity>, IRepository<TEntity>
    {

    }
}
