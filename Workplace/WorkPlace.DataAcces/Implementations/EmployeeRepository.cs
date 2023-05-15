using WorkPlace.Core.Entities;
using WorkPlace.DataAcces.Contexts;
using WorkPlace.DataAcces.Interfaces;
namespace ConsoleApp.DataAccess.Implementations;



public class EmployeeRepository : IRepository<Employee>
{
    public void Add(Employee entity)
    {
        DBContext.Employees.Add(entity);
    }

    public void Delete(Employee entity)
    {
        DBContext.Employees.Remove(entity);
    }

    public void Update(int id, Employee entity)
    {
        var employee = DBContext.Employees.Find(emp => emp.EmployeeId == id);

        employee.EmployeeName = entity.EmployeeName;
        employee.EmployeeSurname = entity.EmployeeSurname;
        employee.DepartmentId = entity.DepartmentId;
        employee.Salary = entity.Salary;

    }


    public Employee? GetById(int id)
    {
        return DBContext.Employees.Find(emp => emp.EmployeeId == id);
    }

    public Employee? GetByName(string name)
    {
        return DBContext.Employees.Find(emp => emp.EmployeeName == name);
    }

    public List<Employee>? GetAll()
    {
        return DBContext.Employees;
    }
}