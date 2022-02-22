using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayRental.Common
{
    public interface IGetRepositotyTwoInt<TEntity, Tint, T2int>
    {
        TEntity Get(int id1, int id2 );
        IEnumerable<TEntity> Get();
    }
}
