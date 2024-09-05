using InMemoryCRUDEmployeeOperationDhiki.Models;
using System.Collections.Generic;
using System.Linq;

namespace InMemoryCRUDEmployeeOperationDhiki.Services
{
    public class EmployeeService : IEmployeeService
    {
        private List<Employee> _employees = new List<Employee>();

        
        public void AddEmployee(Employee employee) //Untuk Menambahkan Employee
        {
            _employees.Add(employee);
        }

        public List<Employee> GetAllEmployees() //Mendapatkan semua employee yang telah diimput
        {
            return _employees;
        }

        public Employee GetEmployeeById(string id) //Mendapatkan employee berdasarkan id
        {
            return _employees.FirstOrDefault(e => e.EmployeeID == id);
        }

        public void UpdateEmployee(Employee employee) //Update data employe
        {
            var existingEmployee = GetEmployeeById(employee.EmployeeID);
            if (existingEmployee != null)
            {
                existingEmployee.FullName = employee.FullName;
                existingEmployee.BirthDate = employee.BirthDate;
            }
        }

        public void DeleteEmployee(string id) //Delete Employee
        {
            var employee = GetEmployeeById(id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
        }
    }
}