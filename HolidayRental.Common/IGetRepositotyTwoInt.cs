using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayRental.Common
{
    public interface IGetRepositotyTwoInt<TEntity, Tint, T2int>
    {
        TEntity Get(int idOption, int idBien );
        IEnumerable<TEntity> Get();
    }
}
