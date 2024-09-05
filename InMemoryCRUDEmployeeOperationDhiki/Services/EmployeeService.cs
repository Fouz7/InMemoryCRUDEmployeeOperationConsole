using InMemoryCRUDEmployeeOperationDhiki.Models;

namespace InMemoryCRUDEmployeeOperationDhiki.Services;

public class EmployeeService : IEmployeeService
{
    private List<Employee> _employees = new List<Employee>();

    public void AddEmployee(Employee employee)
    {
        _employees.Add(employee);
    }

    public List<Employee> GetAllEmployees()
    {
        return _employees;
    }

    public Employee GetEmployeeById(string id)
    {
        return _employees.FirstOrDefault(e => e.EmployeeID == id);
    }

    public void UpdateEmployee(Employee employee)
    {
        var existingEmployee = GetEmployeeById(employee.EmployeeID);
        if (existingEmployee != null)
        {
            existingEmployee.FullName = employee.FullName;
            existingEmployee.BirthDate = employee.BirthDate;
        }
    }

    public void DeleteEmployee(string id)
    {
        var employee = GetEmployeeById(id);
        if (employee != null)
        {
            _employees.Remove(employee);
        }
    }
}
