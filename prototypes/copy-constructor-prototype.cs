/*
  Demostration of prototype design pattern using copy constructors approach
*/

namespace DesignPatterns.prototypes;

enum Record { }

public class Address
{
  public string Street { get; set; }
  public string City { get; set; }
  public string Country { get; set; }
  public Address(string street, string city, string country)
  {
    Street = street;
    City = city;
    Country = country;
  }
  public Address(Address address)
  {
    Street = address.Street;
    City = address.City;
    Country = address.Country;
  }

  public override string ToString()
  {
    return $"Street: {Street}, City: {City}, Country: {Country}";
  }
}

public class Employee
{
  public string FullName { get; set; }
  public Address Address { get; set; }

  public Employee(string fullName, Address address)
  {
    FullName = fullName;
    Address = address;
  }

  public Employee(Employee employee)
  {
    FullName = employee.FullName;
    Address = new Address(employee.Address);
  }

  public override string ToString()
  {
    return $"Name: {FullName}, {Address}";
  }
}
