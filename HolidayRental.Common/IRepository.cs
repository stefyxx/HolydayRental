using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayRental.Common
{
    public interface IRepository<TEntity>
    {
        int Insert(TEntity entity);
        void Delete(int id);
        void Update(int id, TEntity entity);
    }
}
