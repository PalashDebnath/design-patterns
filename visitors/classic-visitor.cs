/*
  Demostration of visitor pattern. Visitor pattern help on performing some operation on a set of hierarchical objects. Now the
  hierarchical word it important here, this means a group of objects inherited or extended from same parent.

  Here we have a School, where a ClassicDoctor is a visitor, who will do a health check on all the ClassicStudents and ClassicTeacher one by one.
  This is how a typical visitor pattern look like. Here we have visited method on IClassicVisitor for each type of derived ClassicMembers 
*/

namespace DesignPatterns.Visitors;

enum Dummy { }

interface IClassicVisitor
{
  void Visit(ClassicStudent ClassicStudent);
  void Visit(ClassicTeacher ClassicTeacher);
}

abstract class ClassicMember
{
  public string Name { get; private set; }
  public ClassicMember(string name)
  {
    Name = name;
  }
  public abstract void Accept(IClassicVisitor visitor);
}

class ClassicStudent : ClassicMember
{
  public ClassicStudent(string name) : base(name) { }
  public override void Accept(IClassicVisitor visitor)
  {
    visitor.Visit(this);
  }
}

class ClassicTeacher : ClassicMember
{
  public ClassicTeacher(string name) : base(name) { }
  public override void Accept(IClassicVisitor visitor)
  {
    visitor.Visit(this);
  }
}

class ClassicDoctor : IClassicVisitor
{
  public string Name { get; private set; }
  public ClassicDoctor(string name)
  {
    Name = name;
  }
  public void Visit(ClassicStudent student)
  {
    Console.WriteLine($"Doctor {Name} did the health checkup of student: {student.Name}");
  }
  public void Visit(ClassicTeacher teacher)
  {
    Console.WriteLine($"Doctor {Name} did the health checkup of teacher: {teacher.Name}");
  }
}