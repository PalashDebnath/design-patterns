/*
  Demonstration of dependency inversion principle(DIP). As per DIP a high level module/class should not depend on low modules/classes.
  Both should depend on abstraction. Also abstraction should not depend on details, details should depend on abstraction.

  Here the VEmployeeBusiness(high-level) class directly depend on the VEmployeeDataAccess(low-level) class. We need to abstract that
  dependency, so that any changes on VEmployeeDataAccess not break VEmployeeBusiness class.

  what does it mean by abstraction shoulo't depend on details, details should depend on abstraction. It means the interface method
  signature shouldn't be derived from the end output. It should be more generic and the implementation of the method on class should
  follow the signature.

  On the other hand EmployeeBusiness and EmployeeDataAccess talk to each other through the IEmployeeDataAccess interface. which follows
  the dependency inversion principle.
*/
namespace DesignPatterns.DependencyInversionPrinciple;

public enum Dummy { }

public class Employee
{
  public int Id { get; set; }
  public string? Name { get; set; }
  public string? Department { get; set; }
  public int Salary { get; set; }

  public override string ToString()
  {
    return $"Name: {Name}, Department: {Department}, Salary: {Salary}";
  }
}

public class VEmployeeDataAccess
{
  public Employee GetEmployeeDetails(int id)
  {
    Employee employee = new Employee() { Id = id, Name = "Palash", Department = "IT", Salary = 10000 };
    return employee;
  }
}

public class VEmployeeBusiness
{
  private readonly VEmployeeDataAccess employeeDataAccess;
  public VEmployeeBusiness() { employeeDataAccess = new VEmployeeDataAccess(); }
  public Employee GetEmployeeDetails(int id)
  {
    return employeeDataAccess.GetEmployeeDetails(id);
  }
}

public interface IEmployeeDataAccess
{
  Employee GetEmployeeDetails(int id);
}

public class EmployeeDataAccess : IEmployeeDataAccess
{
  public Employee GetEmployeeDetails(int id)
  {
    Employee employee = new Employee() { Id = id, Name = "Palash", Department = "IT", Salary = 10000 };
    return employee;
  }
}

public class EmployeeBusiness
{
  private readonly EmployeeDataAccess employeeDataAccess;
  public EmployeeBusiness() { employeeDataAccess = new EmployeeDataAccess(); }
  public Employee GetEmployeeDetails(int id)
  {
    return employeeDataAccess.GetEmployeeDetails(id);
  }
}