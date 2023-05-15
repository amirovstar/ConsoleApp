using WorkPlace.Core.Interfaces;

namespace WorkPlace.DataAcces.Interfaces
{
    public interface IRepository<T> where T:IEntity
	{
        void Add(T entity);
        void Update(int id, T entity);
        void Delete(T entity);
        T? GetById(int id);
        List<T>? GetAll();
        T? GetByName(string name);
    }
}

