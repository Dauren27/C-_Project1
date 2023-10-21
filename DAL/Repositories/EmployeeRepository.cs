using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Common.Models;

namespace DAL.Repositories
{
    public class EmployeeRepository
    {
        private readonly string _dataFilePath = "../DataAccess/employees.json";

        public List<Employee> GetEmployees()
        {
            using (StreamReader reader = new StreamReader(_dataFilePath))
            {
                string json = reader.ReadToEnd();
                return JsonSerializer.Deserialize<List<Employee>>(json);
            }
        }

        public Employee GetEmployeeById(Guid id)
        {
            var employees = GetEmployees();
            return employees.FirstOrDefault(e => e.Id == id);
        }

        public void CreateEmployee(Employee employee)
        {
            var employees = GetEmployees();
            employee.Id = Guid.NewGuid();
            employees.Add(employee);
            SaveEmployeesToJson(employees);
        }

        public void UpdateEmployee(Employee employee)
        {
            var employees = GetEmployees();
            var existingEmployee = employees.FirstOrDefault(e => e.Id == employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.FirstName = employee.FirstName;
                existingEmployee.LastName = employee.LastName;
                existingEmployee.MiddleName = employee.MiddleName;
                existingEmployee.Email = employee.Email;

                SaveEmployeesToJson(employees);
            }
        }

        public void DeleteEmployee(Guid id)
        {
            var employees = GetEmployees();
            var employeeToDelete = employees.FirstOrDefault(e => e.Id == id);
            if (employeeToDelete != null)
            {
                employees.Remove(employeeToDelete);
                SaveEmployeesToJson(employees);
            }
        }

        private void SaveEmployeesToJson(List<Employee> employees)
        {
            string json = JsonSerializer.Serialize(employees);
            File.WriteAllText(_dataFilePath, json);
        }
    }
}
