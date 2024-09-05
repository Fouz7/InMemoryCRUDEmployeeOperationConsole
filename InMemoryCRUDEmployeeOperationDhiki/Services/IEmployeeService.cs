using InMemoryCRUDEmployeeOperationDhiki.Models;

namespace InMemoryCRUDEmployeeOperationDhiki.Services;

//Interface Operation
public interface IEmployeeService
{
    void AddEmployee(Employee employee);
    List<Employee> GetAllEmployees();
    Employee GetEmployeeById(string id);
    void UpdateEmployee(Employee employee);
    void DeleteEmployee(string id);
}