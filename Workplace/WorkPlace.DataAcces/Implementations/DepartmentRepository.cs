using WorkPlace.Core.Entities;
using WorkPlace.DataAcces.Contexts;
using WorkPlace.DataAcces.Interfaces;
namespace ConsoleApp.DataAccess.Implementations;

public class DepartmentRepository : IRepository<Department>
{
    public void Add(Department entity)
    {
        DBContext.Departments.Add(entity);
    }

    public void Delete(Department entity)
    {
        DBContext.Departments.Remove(entity);
    }
    public void Update(int id, Department entity)
    {
        var department = DBContext.Departments.Find(dep => dep.DepartmentId == id);

        department.DepartmentName = entity.DepartmentName;
        department.EmployeeLimit = entity.EmployeeLimit;
        department.CompanyId = entity.CompanyId;

    }


    public Department? GetById(int id)
    {
        return DBContext.Departments.Find(dep => dep.DepartmentId == id);
    }

    public Department? GetByName(string name)
    {
        return DBContext.Departments.Find(dep => dep.DepartmentName == name);
    }

    public List<Department>? GetAll()
    {
        return DBContext.Departments;
    }
}

