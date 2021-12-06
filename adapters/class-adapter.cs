/*
  Demostration of adapter pattern.
*/

namespace DesignPatterns.Adapters;

enum ClassAdapter { }

public interface IBilling<T>
{
  void Process(T t);
}

public class Employee
{
  public int Id { get; private set; }
  public string FullName { get; private set; }
  public string Designation { get; private set; }
  public decimal Salary { get; private set; }
  public Employee(int id, string fullName, string designation, decimal salary)
  {
    Id = id;
    FullName = fullName;
    Designation = designation;
    Salary = salary;
  }
}

public class EmployeeBilling : IBilling<List<Employee>>
{
  public void Process(List<Employee> employees)
  {
    foreach (Employee employee in employees)
    {
      Console.WriteLine("Rs." + employee.Salary + " Salary Credited to " + employee.FullName + " Account");
    }
  }
}

public class EmployeeBillingAdapter : EmployeeBilling, IAdapter<List<Tuple<int, string, string, int>>>
{
  private List<Employee> newEmployees = new List<Employee>();
  public void Adapt(List<Tuple<int, string, string, int>> employees)
  {
    foreach (var employee in employees)
    {
      newEmployees.Add(new Employee(employee.Item1, employee.Item2, employee.Item3, employee.Item4));
    }

    //calling the base class Process method to process the salary
    Process(newEmployees);
  }
}

