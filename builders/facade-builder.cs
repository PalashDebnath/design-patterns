/*
  Implement a builder pattern which will act as a facade. It will internally call other builder classes to build up the object
*/

namespace DesignPatterns.Builders;

enum facade { }

public class Person
{
  public string StreetAddress { get; set; } = string.Empty;
  public string PostCode { get; set; } = string.Empty;
  public string City { get; set; } = string.Empty;
  public string CompanyName { get; set; } = string.Empty;
  public string Position { get; set; } = string.Empty;
  public int AnnualIncome { get; set; }

  public override string ToString()
  {
    return $"Street Address: {StreetAddress}, Post Code: {PostCode}, City: {City}, Company Name: {CompanyName}, Position: {Position}, Annual Income: {AnnualIncome}";
  }
}

public class PersonBuilder
{
  // this is the object, all builders will build. Here we are keeping the reference of it.
  protected Person person = new Person();
  // passing the reference of the traget object. Property will give a new JobBuiler which will be referenced a new Person object.
  public JobBuilder Works => new JobBuilder(person);
  // passing the reference of the traget object. Property will give a new AddressBuiler which will be referenced a new Person object. 
  public AddressBuilder Lives => new AddressBuilder(person);
  // this will implicitly covert the PersonBuilder to Person
  public static implicit operator Person(PersonBuilder pb)
  {
    return pb.person;
  }
}

public class JobBuilder : PersonBuilder
{
  public JobBuilder(Person person)
  {
    this.person = person;
  }
  public JobBuilder At(string conpanyName)
  {
    this.person.CompanyName = conpanyName;
    return this;
  }
  public JobBuilder AsA(string position)
  {
    this.person.Position = position;
    return this;
  }
  public JobBuilder OfPackage(int annualIncome)
  {
    this.person.AnnualIncome = annualIncome;
    return this;
  }
}

public class AddressBuilder : PersonBuilder
{
  public AddressBuilder(Person person)
  {
    this.person = person;
  }
  public AddressBuilder At(string street)
  {
    this.person.StreetAddress = street;
    return this;
  }
  public AddressBuilder In(string city)
  {
    this.person.City = city;
    return this;
  }
  public AddressBuilder WithPostCode(string postCode)
  {
    this.person.PostCode = postCode;
    return this;
  }
}