/*
  Demonstration of flyweight design pattern. Flyweight design pattern help to reduce object creation, hence decrease memory
  footprint. Use this pattern to create large number of objects of almost similar in nature.
  
  Here in this example we are going to create bunch of shapes who are identical in nature but only the color is different.
  Using the flyweight design pattern we will reduce the shape object creation.
*/

namespace DesignPatterns.Flyweights;

enum ShapeType { Circle, Square }

abstract class Shape
{
  protected string Color { get; private set; } = "Black";
  public void SetColor(string color)
  {
    Color = color;
  }
  public virtual void Draw()
  {
    Console.WriteLine($"Shape: Draw() [Color : {Color}]");
  }
}

static class ShapeFactory
{
  public static Shape Create(ShapeType type)
  {
    switch (type)
    {
      case ShapeType.Circle:
        return new Circle();
      case ShapeType.Square:
        return new Square();
      default:
        return new Circle(); ;
    }
  }
}

class Circle : Shape
{
  public override void Draw()
  {
    Console.WriteLine($"Circle: Draw() [Color : {Color}]");
  }
}

class Square : Shape
{
  public override void Draw()
  {
    Console.WriteLine($"Square: Draw() [Color : {Color}]");
  }
}

abstract class Cache<TKey, TValue> where TKey : struct
{
  protected Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
  public virtual TValue? Lookup(ShapeType type) { return default(TValue); }
}

class ShapeCache : Cache<ShapeType, Shape>
{
  public override Shape Lookup(ShapeType type)
  {
    Shape? shape;
    if (!dictionary.TryGetValue(type, out shape))
    {
      shape = ShapeFactory.Create(type);
      dictionary.Add(type, shape);
    }
    Console.WriteLine($"Number of shapes in memory: {dictionary.Count()}");
    return shape;
  }
}

