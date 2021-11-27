/*
  Demonstration of liskov substitution principle(LSP).
  Point#1: It is allowed to substitute a basetype for a subtype without breaking the program.  
  Point#2: It is allowed to substitute an object with it's sub object without breaking the program.

  Here VRectangle is basetype and VSquare is a subtype of it. Consider the below code
    VSquare square = new VSquare();
    square.Length = 4; 
    Console.WriteLine(square.ToString()); -- Length: 4,Breadth: 4, Area: 16
  as per liskov substitution priciple VSquare subtype can be substituted by VRectangle and the output remain same.
    VRectangle square = new VSquare();
    square.Length = 4; 
    Console.WriteLine(square.ToString()); -- Length: 4,Breadth: 0, Area: 0

  Here VApple is base class and VOrange is a sub class. Consider the below code
    VApple apple = new VApple();
    Console.WriteLine(apple.GetColor()); -- Color: Green, Price: 2 
  as per liskov substitution priciple VArange object can be substituted by VOrange object and the output remain same.
    VApple apple = new VOrange();
    Console.WriteLine(apple.GetColor()); -- Color: Orange, Price: 1

  On the other hand Shape, Rectange and Square follows liskon substitution priciple. same also goes for Fruit, Apple
  and Orange. 
*/
namespace DesignPatterns.LiskovSubstitutionPrinciple;

public enum Dummy { }

public class VRectangle
{
  public int Length { get; set; }
  public int Breadth { get; set; }
  public VRectangle() { }
  public VRectangle(int length, int breadth) { Length = length; Breadth = breadth; }
  public int Area() { return Length * Breadth; }

  public override string ToString()
  {
    return $"Length: {Length},Breadth: {Breadth}, Area: {Area()}";
  }
}

public class VSquare : VRectangle
{
  public new int Length { set { base.Length = base.Breadth = value; } }
  public new int Breadth { set { base.Length = base.Breadth = value; } }
}

public class VApple
{
  public decimal Price { get; set; }
  public VApple(decimal price) { Price = price; }
  public virtual string GetDetails()
  {
    return $"Color: Green, Price: {Price}";
  }
}

public class VOrange : VApple
{
  public VOrange(decimal price) : base(price) { }
  public override string GetDetails()
  {
    return $"Color: Orange, Price: {Price}";
  }
}

public class Shape
{
  public int Length { get; set; }
  public int Breadth { get; set; }
  public Shape(int length, int breadth) { Length = length; Breadth = breadth; }
  public int Area() { return Length * Breadth; }

  public override string ToString()
  {
    return $"Length: {Length},Breadth: {Breadth}, Area: {Area()}";
  }
}

public class Rectangle : Shape
{
  public Rectangle(int length, int breadth) : base(length, breadth) { }
}

public class Square : Shape
{
  public Square(int length) : base(length, length) { }
}

public abstract class Fruit
{
  public abstract decimal Price { get; set; }
  public abstract string GetDetails();
}

public class Apple : Fruit
{
  public override decimal Price { get; set; }
  public Apple(decimal price) { Price = price; }
  public override string GetDetails()
  {
    return $"Color: Green, Price: {Price}";
  }
}

public class Orange : Fruit
{
  public override decimal Price { get; set; }
  public Orange(decimal price) { Price = price; }
  public override string GetDetails()
  {
    return $"Color: Orange, Price: {Price}";
  }
}
