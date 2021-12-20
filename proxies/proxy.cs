/*
  Demonstration of proxy design pattern.

  Here we have Employees and as per their designation they can perform certain operations. we create a proxy class to achive
  such situation. This proxy named as restriction proxy. 
*/

namespace DesignPatterns.Proxies;

enum Designation { Ceo, Manager, Developer }

class Employee
{
  public string UserName { get; set; }
  public string Password { get; set; }
  public string FullName { get; set; }
  public Designation Designation { get; set; }
  public Employee(string userName, string password, string fullName, Designation designation)
  {
    UserName = userName;
    Password = password;
    FullName = fullName;
    Designation = designation;
  }
}

interface IOperation
{
  void Read();
  void Write();
}

class Operation : IOperation
{
  public void Read()
  {
    Console.WriteLine("Performing read operation");
  }
  public void Write()
  {
    Console.WriteLine("Performing write operation");
  }
}

class OpeartionProxy : IOperation
{
  private Lazy<Operation> operation = new Lazy<Operation>();
  public Operation Operation => operation.Value;
  public Employee Employee { get; private set; }
  public OpeartionProxy(Employee employee)
  {
    Employee = employee;
  }
  public void Read()
  {
    Operation.Read();
  }
  public void Write()
  {
    if (Employee.Designation == Designation.Ceo || Employee.Designation == Designation.Manager)
      Operation.Write();
    else
      Console.WriteLine("You don't have permission to perform this operation");
  }
}