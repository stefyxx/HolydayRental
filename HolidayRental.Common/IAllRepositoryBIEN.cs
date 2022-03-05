using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayRental.Common
{
    public interface IAllRepositoryBIEN<TEntity>: IGetRepository<TEntity>, IRepository<TEntity>
    {
        IEnumerable<TEntity> GetLibreSP(DateTime dateDebut, DateTime dateFin);
        IEnumerable<TEntity> GetAllBiensParMembreSP(int idMembro);
        IEnumerable<TEntity> GetMeilleurBienV();
        IEnumerable<TEntity> GetMeilleur15BienV();
        IEnumerable<TEntity> GetDernier5BienV();
        IEnumerable<TEntity> GetBienParPaysV();


    }
}
