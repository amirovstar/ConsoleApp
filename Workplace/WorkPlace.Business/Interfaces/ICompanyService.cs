using WorkPlace.Business.DTOs;
using WorkPlace.Core.Entities;

namespace WorkPlace.Business.Interfaces
{
    public interface ICompanyService
	{
		void Create(CompanyDto company);
		void Remove(int id);
		void Update(int id, CompanyDto company);
		Company GetById(int id);
		Company GetByName(string name);
		List<Company> GetAll();
	}
}

