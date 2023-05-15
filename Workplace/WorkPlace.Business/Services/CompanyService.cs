using System;
using ConsoleApp.DataAccess.Implementations;
using WorkPlace.Business.DTOs;
using WorkPlace.Business.Exceptions;
using WorkPlace.Business.Helpers;
using WorkPlace.Business.Interfaces;
using WorkPlace.Core.Entities;

namespace WorkPlace.Business.Services
{
    public class CompanyService : ICompanyService
    {
        public CompanyRepository companyRepository { get; }
        public CompanyService()
        {
            companyRepository = new CompanyRepository();
        }
        public void Create(CompanyDto company)
        {
            if (company == null)
            {
                throw new DataNullException(Helper.Errors["DataNullException"]);
            }

            if (company.name.Length < 2)
            {
                throw new SizeException(Helper.Errors["SizeException"]);
            }
            if (company.name.isOnlyLetters())
            {
                throw new InvalidFormatException(Helper.Errors["InvalidFormatException"]);
            }
            Company comp = new Company(company.name);
            if (!companyRepository.GetAll().Contains(comp))
            {
                throw new AlreadyExistsException(Helper.Errors["AlreadyExistsException"]);
            }
            companyRepository.Add(comp);


        }


        public void Remove(int id)
        {
            if (id < 0)
            {
                throw new SizeException(Helper.Errors["SizeException"]);
            }
            var comp = companyRepository.GetById(id);
            if (comp == null)
            {
                throw new DataNullException(Helper.Errors["DataNullException"]);
            }
            companyRepository.Delete(comp);
        }

        public void Update(int id, CompanyDto employee)
        {
            if (id < 0)
            {
                throw new SizeException(Helper.Errors["SizeException"]);
            }
            if (employee == null)
            {
                throw new DataNullException(Helper.Errors["DataNullException"]);
            }
            var comp = new Company(employee.name);
            if (companyRepository.GetById(id) == null)
            {
                throw new DataNullException(Helper.Errors["DataNullException"]);
            }
            companyRepository.Update(id, comp);

        }

        public Company GetById(int id)
        {
            if (id < 0)
            {
                throw new SizeException(Helper.Errors["SizeException"]);
            }
            var comp = companyRepository.GetById(id);
            if (comp == null)
            {
                throw new DataNullException(Helper.Errors["DataNullException"]);
            }
            return comp;
        }

        public Company GetByName(string name)
        {
            if (name.isOnlyLetters())
            {
                throw new InvalidFormatException(Helper.Errors["InvalidFormatException"]);
            }
            var comp = companyRepository.GetByName(name);
            if (comp == null)
            {
                throw new DataNullException(Helper.Errors["DataNullException"]);
            }
            return comp;
        }
        public List<Company> GetAll()
        {
            var comp = companyRepository.GetAll();
            if (comp == null)
            {
                throw new DataNullException(Helper.Errors["DataNullException"]);
            }
            return comp;
        }
    }

}

