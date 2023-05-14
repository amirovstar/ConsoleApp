﻿using System.Xml.Linq;
using WorkPlace.Core.Interfaces;

namespace WorkPlace.Core.Entities
{
    public class Employee:IEntity
	{
        private static int _count = 1;
        public int EmployeeId { get; }
        public decimal Salary { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public int DepartmentId { get; set; }
        public Employee(string name, string surname, decimal salary,int departmentId)
        {
            EmployeeId = _count;
            _count++;
            EmployeeName = name;
            EmployeeSurname = surname;
            Salary = salary;
            DepartmentId = departmentId;
        }
        public override string ToString()
        {
            return $"{EmployeeId}, {EmployeeName}, {EmployeeSurname}";
        }
    }
}

