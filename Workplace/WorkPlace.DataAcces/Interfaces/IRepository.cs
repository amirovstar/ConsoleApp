using WorkPlace.Core.Interfaces;

namespace WorkPlace.DataAcces.Interfaces
{
    public interface IRepository<T> where T:IEntity
	{
		void Add(T entity);
		void Remove(int id);
		void Update(T entity);
		T GetById(int id);
		List<T> GetAll(int skip, int take);
	}
}

