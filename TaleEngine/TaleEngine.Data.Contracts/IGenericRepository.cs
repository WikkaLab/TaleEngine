using System.Collections.Generic;

namespace TaleEngine.Data.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int entityId);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int entityId);
        void Save();

    }
}
