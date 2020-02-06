namespace Locadora.Interfaces
{
    using Locadora.Entities;
    using System.Collections.Generic;
    using System.Linq;

    public interface IRepository<T> where T : BaseEntity
    {

        void Insert(T obj);

        void Update(T obj);

        void Delete(long id);

        T SelectById(long id);

        IList<T> SelectAll();

        IQueryable<T> GetQuery();
    }
}
