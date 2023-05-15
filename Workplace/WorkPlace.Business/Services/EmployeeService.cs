using ConsoleApp.DataAccess.Implementations;
using WorkPlace.Business.DTOs;
using WorkPlace.Business.Exceptions;
using WorkPlace.Business.Helpers;
using WorkPlace.Business.Interfaces;
using WorkPlace.Core.Entities;

namespace WorkPlace.Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        public EmployeeRepository employeeRepository { get; }


        public EmployeeService()
        {
            employeeRepository = new EmployeeRepository();
        }

        public void Create(EmployeeDto employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException();
            }
            if (employee.salary < 200)
            {
                throw new MinimumWageException(Helper.Errors["InvalidFormatException"]);
            }
            if (employee.name.Length < 2)
            {
                throw new SizeException(Helper.Errors["SizeException"]);
            }

            if (employee.name.isOnlyLetters() && employee.surname.isOnlyLetters())
            {
                throw new InvalidFormatException(Helper.Errors["InvalidFormatException"]);
            }
            Employee emp = new Employee(employee.name, employee.surname, employee.salary, employee.deparmentId);

            if (employeeRepository.GetAll().Contains(emp))
            {
                throw new AlreadyExistsException(Helper.Errors["AlreadyExistsException"]);
            }
            employeeRepository.Add(emp);

        }

        public void Remove(int id)
        {
            if (id < 0)
            {
                throw new SizeException(Helper.Errors["SizeException"]);
            }
            var emp = employeeRepository.GetById(id);
            if (emp == null)
            {
                throw new NotFoundException(Helper.Errors["NotFoundException"]);
            }
            employeeRepository.Delete(emp);
        }

        public void Update(int id, EmployeeDto employee)
        {
            if (id < 0)
            {
                throw new SizeException(Helper.Errors["SizeException"]);
            }
            if (employee == null)
            {
                throw new NullReferenceException();
            }
            var emp = new Employee(employee.surname, employee.surname, employee.deparmentId);
            if (employeeRepository.GetById(id) == null)
            {
                throw new NotFoundException(Helper.Errors["NotFoundException"]);
            }
            employeeRepository.Update(id, emp);
        }

        public List<Employee> GetAll()
        {
            var empList = employeeRepository.GetAll();
            if (empList == null)
            {
                throw new NotFoundException(Helper.Errors["NotFoundException"]);
            }
            return empList;
        }

        public Employee GetById(int id)
        {
            if (id<0)
            {
                throw new SizeException(Helper.Errors["SizeException"]);
            }
            var emp = employeeRepository.GetById(id);
            if (emp == null)
            {
                throw new NotFoundException(Helper.Errors["NotFoundException"]);
            }
            return emp;
        }

        public Employee GetByName(string name)
        {
            if (name.isOnlyLetters())
            {
                throw new InvalidFormatException(Helper.Errors["InvalidFormatException"]);
            }
            var emp = GetByName(name);
            if (emp==null)
            {
                throw new NotFoundException(Helper.Errors["NotFoundException"]);
            }
            return emp;
        }

    }
}
