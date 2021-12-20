/*
  Demonstration of Visitor Pattern.

  In the classic implementation there is a drawback. Consider there is a new type of member appears in future. On that case
  we have to overload the Visit method inside the interface IClassicVisitor with that new type of member. We also have to 
  implement the overload ot all concreate IClassicVisitor class. This completely violate open-close and interface-segregation
  principles. 
*/

namespace DesignPatterns.Visitors;

enum Fake { }

interface IVisitor<T>
{
  void Visit(T t);
}

interface IVisitor
{

}

abstract class Member
{
  public string Name { get; private set; }
  public Member(string name)
  {
    Name = name;
  }
  public abstract void Accept(IVisitor visitor);
}

class Student : Member
{
  public Student(string name) : base(name) { }
  public override void Accept(IVisitor visitor)
  {
    // Here we are doing a type cast which will impact our performance a bit, but it will provide more flexibility.
    if (visitor is IVisitor<Student> finalVisitor)
      finalVisitor.Visit(this);
  }
}

class Teacher : Member
{
  public Teacher(string name) : base(name) { }
  public override void Accept(IVisitor visitor)
  {
    // Here we are doing a type cast which will impact our performance a bit. But it will provide more flexibility.
    if (visitor is IVisitor<Teacher> finalVisitor)
      finalVisitor.Visit(this);
  }
}

class Doctor : IVisitor, IVisitor<Student>, IVisitor<Teacher>
{
  public string Name { get; private set; }
  public Doctor(string name)
  {
    Name = name;
  }
  public void Visit(Student student)
  {
    Console.WriteLine($"Doctor {Name} did the health checkup of student: {student.Name}");
  }
  public void Visit(Teacher teacher)
  {
    Console.WriteLine($"Doctor {Name} did the health checkup of teacher: {teacher.Name}");
  }
}

class SalePerson : IVisitor, IVisitor<Student>
{
  public string Name { get; private set; }
  public SalePerson(string name)
  {
    Name = name;
  }
  public void Visit(Student student)
  {
    Console.WriteLine($"Sale Person {Name} provided a backpack to student: {student.Name}");
  }
}