using WorkPlace.Core.Entities;
using WorkPlace.DataAcces.Contexts;
using WorkPlace.DataAcces.Interfaces;

namespace WorkPlace.DataAcces.Implementations
{
    public class CompanyRepository : IRepository<Company>
    {
        public void Add(Company entity)
        {
            DBContext.Companies.Add(entity);
        }

        public void Remove(int id)
        {
            var company = DBContext.Companies.Find(comp => comp.CompanyId == id);
            DBContext.Companies.Remove(company);
        }
        public void Update(Company entity)
        {
            var company = DBContext.Companies.Find(comp => comp.CompanyId == entity.CompanyId);
            company.CompanyName = entity.CompanyName;
        }

        public Company GetById(int id)
        {
            return DBContext.Companies.Find(comp => comp.CompanyId == id);
        }


        public Company GetByName(string name)
        {
            return DBContext.Companies.Find(comp => comp.CompanyName == name);
        }

        public List<Company> GetAll(int skip, int take)
        {
            return DBContext.Companies.GetRange(skip, take);
        }

        public List<Department> GetAllDepartments(int companId)
        {
            return DBContext.Departments.FindAll(dep => dep.CompanyId == companId);

        }
    }
}

