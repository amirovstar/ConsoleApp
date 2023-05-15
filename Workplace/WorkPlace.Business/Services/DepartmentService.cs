using ConsoleApp.DataAccess.Implementations;
using WorkPlace.Business.DTOs;
using WorkPlace.Business.Exceptions;
using WorkPlace.Business.Helpers;
using WorkPlace.Business.Interfaces;
using WorkPlace.Core.Entities;

namespace WorkPlace.Business.Services
{
    public class DepartmentService : IDepartmentService
    {
        public DepartmentRepository departmentRepository { get; }
        public EmployeeRepository employeeRepository { get; }
        public DepartmentService()
        {
            departmentRepository = new DepartmentRepository();
            employeeRepository = new EmployeeRepository();
        }
        public void Create(DepartmentDto department)
        {
            if (department == null)
            {
                throw new DataNullException(Helper.Errors["DataNullException"]);
            }
            if (department.employeeLimit < 2)
            {
                throw new SizeException(Helper.Errors["SizeException"]);
            }
            if (department.name.Length < 2)
            {
                throw new SizeException(Helper.Errors["SizeException"]);
            }
            if (department.name.isOnlyLetters())
            {
                throw new InvalidFormatException(Helper.Errors["InvalidFormatException"]);
            }
            if (department.companyId < 0)
            {
                throw new SizeException(Helper.Errors["SizeException"]);
            }

            if (employeeRepository.GetAll().Count < department.employeeLimit)
            {
                throw new EmployeeLimitNotEnough(Helper.Errors["EmployeeLimitNotEnough"]);
            }
            Department dep = new Department(department.name, department.employeeLimit, department.companyId);
            if (!departmentRepository.GetAll().Contains(dep))
            {
                throw new AlreadyExistsException(Helper.Errors["AlreadyExistsException"]);
            }
            departmentRepository.Add(dep);
        }



        public void Remove(int id)
        {
            if (id < 0)
            {
                throw new SizeException(Helper.Errors["SizeException"]);
            }
            var dep = departmentRepository.GetById(id);
            if (dep == null)
            {
                throw new DataNullException(Helper.Errors["DataNullException"]);
            }
            departmentRepository.Delete(dep);
        }

        public void Update(int id, DepartmentDto department)
        {
            if (id < 0)
            {
                throw new SizeException(Helper.Errors["SizeException"]);
            }
            if (department == null)
            {
                throw new DataNullException(Helper.Errors["DataNullException"]);
            }
            if (employeeRepository.GetAll().Count < department.employeeLimit)
            {
                throw new EmployeeLimitNotEnough(Helper.Errors["EmployeeLimitNotEnough"]);
            }
            var dep = new Department(department.name, department.employeeLimit, department.companyId);
            if (departmentRepository.GetById(id) == null)
            {
                throw new DataNullException(Helper.Errors["DataNullException"]);
            }
            departmentRepository.Update(id, dep);
        }
        public Department GetById(int id)
        {
            if (id < 0)
            {
                throw new SizeException(Helper.Errors["SizeException"]);
            }
            var dep = departmentRepository.GetById(id);
            if (dep == null)
            {
                throw new DataNullException(Helper.Errors["DataNullException"]);
            }
            return dep;
        }

        public Department GetByName(string name)
        {
            if (name.isOnlyLetters())
            {
                throw new InvalidFormatException(Helper.Errors["InvalidFormatException"]);
            }
            var dep = departmentRepository.GetByName(name);
            if (dep == null)
            {
                throw new DataNullException(Helper.Errors["DataNullException"]);
            }
            return dep;
        }
        public List<Department> GetAll()
        {
            var dep = departmentRepository.GetAll();
            if (dep == null)
            {
                throw new DataNullException(Helper.Errors["DataNullException"]);
            }
            return dep;
        }
    }
}



