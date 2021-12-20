/*
  Demonstration of Mediator design pattern. Imagin you have several objects and all those objects want to communicate with each
  other. To commnunication one onject will end up having reference of serveral other objects. In this case we may use a mediator
  who will instead communicate with other objects.

  Here we have several Person object, who want's to communicate with each other. We have a Mediator call Communicator which will
  allow all the persons to communicate without having any direct reference. 
*/

namespace DesignPatterns.Mediators;

enum Fake { }

interface ICommunicator<T>
{
  void Register(T t);
  void Unregister(T t);
  void Transmit(T source, string message);
  void To(T source, T destination, string message);
}

class Person
{
  public string Name { get; private set; }
  public ICommunicator<Person>? Communicator { get; set; }
  public Person(string name)
  {
    Name = name;
  }
  public void Wrote(string message)
  {
    Communicator?.Transmit(this, message);
  }
  public void WroteTo(Person person, string message)
  {
    Communicator?.To(this, person, message);
  }
  public void Receive(Person sender, string message)
  {
    Console.WriteLine($"[{Name}'s session] {sender.Name}'s message## {message}");
  }
}

class Communicator : ICommunicator<Person>
{
  private Lazy<List<Person>> _persons = new Lazy<List<Person>>();
  private List<Person> persons => _persons.Value;
  public void Register(Person person)
  {
    person.Communicator = this;
    persons.Add(person);
    person.Wrote($"Hello! I have newly registered.");
  }
  public void To(Person source, Person destination, string message)
  {
    persons.FirstOrDefault(p => p.Equals(destination))?.Receive(source, message);
  }
  public void Transmit(Person source, string message)
  {
    foreach (var person in persons)
      if (!person.Equals(source)) person.Receive(source, message);
  }
  public void Unregister(Person person)
  {
    persons.Remove(person);
  }
}