using WorkPlace.Core.Entities;
using WorkPlace.DataAcces.Contexts;
using WorkPlace.DataAcces.Interfaces;

namespace WorkPlace.DataAcces.Implementations
{
    public class EmployeeRepository : IRepository<Employee>
    {
        public void Add(Employee entity)
        {
            DBContext.Employees.Add(entity);
        }


        public void Remove(int id)
        {
            var employee = DBContext.Employees.Find(empl => empl.DepartmentId == id);
            DBContext.Employees.Remove(employee);
        }

        public void Update(Employee entity)
        {
            var employee = DBContext.Employees.Find(empl => empl.DepartmentId == entity.EmployeeId);
            employee.EmployeeName = entity.EmployeeName;
            employee.EmployeeSurname = entity.EmployeeSurname;
            employee.Salary = entity.Salary;
        }

        public Employee GetById(int id)
        {
            return DBContext.Employees.Find(empl => empl.EmployeeId == id);
        }

        public List<Employee> GetAll(int skip, int take)
        {
            return DBContext.Employees.GetRange(skip, take);
        }
    }
}

