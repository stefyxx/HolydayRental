using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayRental.Common
{
    public interface IGetRepositotyTwoInt<TEntity, Tint, T2int, T3date, T4date>
    {
        TEntity Get(int id1, int id2, DateTime id3, DateTime id4);
        IEnumerable<TEntity> Get();
    }
}
