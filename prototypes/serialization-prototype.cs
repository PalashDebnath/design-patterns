/*
  Demostration of prototype design pattern using explicit interface approach
*/

using System.Text.Json;

namespace DesignPatterns.prototypes;

enum Note { }

public static class Extensions
{
  public static T DeepClone<T>(this T self)
  {
    // this will automatically close the stream and dispose the MemoryStream object
    using (var ms = new MemoryStream())
    {
      JsonSerializer.Serialize(ms, self);
      ms.Seek(0, SeekOrigin.Begin);
      var clone = JsonSerializer.Deserialize<T>(ms) ?? throw new ArgumentNullException();
      return clone;
    }
  }
}

public class Residence
{
  public string Street { get; set; }
  public string City { get; set; }
  public string Country { get; set; }
  public Residence(string street, string city, string country)
  {
    Street = street;
    City = city;
    Country = country;
  }

  public override string ToString()
  {
    return $"Street: {Street}, City: {City}, Country: {Country}";
  }
}

public class Person
{
  public string FullName { get; set; }
  public Residence Residence { get; set; }

  public Person(string fullName, Residence residence)
  {
    FullName = fullName;
    Residence = residence;
  }

  public override string ToString()
  {
    return $"Name: {FullName}, {Residence}";
  }
}