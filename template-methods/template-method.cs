/*
  Demonstration of template method pattern. When we encounter common set of steps or logic for a given task. where the
  implementation of those steps might differ but the execution are stay same, we will use template method design pattern.
  The Key to the Template Design Pattern is that we put the general logic in the abstract parent class and let the child
  classes define the specifics.

  Consider the below example where we have a House. Now there are common behaviours to all the House we build.
  The steps of a building a house is same, but the matrial can differs. 
*/

namespace DesignPatterns.TemplateMethods;

enum Dummy { }

abstract class House
{
  // Template Method to build a house
  public void Build()
  {
    Foundation();
    Pillers();
    Roof();
    Walls();
  }
  protected abstract void Foundation();
  protected abstract void Pillers();
  protected abstract void Walls();
  protected abstract void Roof();
}

class ConcreteHouse : House
{
  protected override void Foundation()
  {
    Console.WriteLine("Building foundation using cement, iron rods & sand!");
  }
  protected override void Pillers()
  {
    Console.WriteLine("Building concrete pillers using cement, iron rods & sand!");
  }
  protected override void Roof()
  {
    Console.WriteLine("Building concrete roof using cement, iron rods & sand!");
  }
  protected override void Walls()
  {
    Console.WriteLine("Building concrete walls!");
  }
}

class WoodenHouse : House
{
  protected override void Foundation()
  {
    Console.WriteLine("Building foundation using cement, iron rods, wood & sand!");
  }
  protected override void Pillers()
  {
    Console.WriteLine("Building wooden pillers!");
  }
  protected override void Roof()
  {
    Console.WriteLine("Building wooden roof!");
  }
  protected override void Walls()
  {
    Console.WriteLine("Building wooden walls!");
  }
}