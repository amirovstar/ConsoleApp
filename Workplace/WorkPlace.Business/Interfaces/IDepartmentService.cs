using WorkPlace.Business.DTOs;
using WorkPlace.Core.Entities;

namespace WorkPlace.Business.Interfaces
{
    public interface IDepartmentService
	{
		void Create(DepartmentDto department);
		void Remove(int id);
		void Update(int id, DepartmentDto department);
		Department GetById(int id);
		Department GetByName(string name);
		List<Department> GetAll();


	}
}

