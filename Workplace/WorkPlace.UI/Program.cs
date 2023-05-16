using WorkPlace.Business.DTOs;
using WorkPlace.Business.Services;
EmployeeService empservice = new EmployeeService();
DepartmentService depservice = new DepartmentService();
CompanyService compservice = new CompanyService();
EmployeeDto empdto = new EmployeeDto(19999, "Furkan", "Amirli", 123);
DepartmentDto depdto = new DepartmentDto("Furkan's Department",16,123);
CompanyDto compdto = new CompanyDto("Furkan's Company");
empservice.Create(empdto);
depservice.Create(depdto);
compservice.Create(compdto);

