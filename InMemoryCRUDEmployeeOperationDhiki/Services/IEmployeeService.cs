using InMemoryCRUDEmployeeOperationDhiki.Models;

namespace InMemoryCRUDEmployeeOperationDhiki.Services;

public interface IEmployeeService
{
    void AddEmployee(Employee employee);
    List<Employee> GetAllEmployees();
    Employee GetEmployeeById(string id);
    void UpdateEmployee(Employee employee);
    void DeleteEmployee(string id);
}