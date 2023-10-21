using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Repositories;
using Common.Models;

namespace BLL.Services
{
    
    public class EmployeeService
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeService(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public List<Employee> GetEmployees()
        {
            return _employeeRepository.GetEmployees();
        }

        public Employee GetEmployeeById(Guid id)
        {
            return _employeeRepository.GetEmployeeById(id);
        }

        public void CreateEmployee(Employee employee)
        {
            _employeeRepository.CreateEmployee(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            _employeeRepository.UpdateEmployee(employee);
        }

        public void DeleteEmployee(Guid id)
        {
            _employeeRepository.DeleteEmployee(id);
        }
    }
}
