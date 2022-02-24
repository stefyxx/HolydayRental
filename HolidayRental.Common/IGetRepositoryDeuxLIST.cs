using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayRental.Common
{
    public interface IGetRepositoryDeuxLIST<TEntity>
    {
        IEnumerable<TEntity> GetOneList(int id);
        IEnumerable<TEntity> GetALLlist();
    }
}
