using WorkPlace.Core.Entities;
using WorkPlace.DataAcces.Contexts;
using WorkPlace.DataAcces.Interfaces;

namespace WorkPlace.DataAcces.Implementations
{
    public class DepartmentRepository : IRepository<Department>
    {
        public void Add(Department entity)
        {
            DBContext.Departments.Add(entity);
        }


        public void Remove(int id)
        {
            var department = DBContext.Departments.Find(dep => dep.DepartmentId == id);
            DBContext.Departments.Remove(department);
        }

        public void Update(Department entity)
        {
            var department = DBContext.Departments.Find(dep => dep.DepartmentId == entity.DepartmentId);
            department.DepartmentName = entity.DepartmentName;
            department.EmployeeLimit = entity.EmployeeLimit;
        }

        public Department GetById(int id)
        {
            return DBContext.Departments.Find(dep => dep.DepartmentId == id);
        }

        public Department GetByName(string name)
        {
            return DBContext.Departments.Find(dep => dep.DepartmentName == name);
        }

        public List<Employee> GetAllEmployees(int depaId)
        {
           return DBContext.Employees.FindAll(emp => emp.DepartmentId == depaId);
        }

        public List<Department> GetAll(int skip, int take)
        {
            return DBContext.Departments.GetRange(skip, take);
        }
    }
}

