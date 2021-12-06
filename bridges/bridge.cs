/*
  Demonstration of bridge pattern.

  There are couple of ways to drawing a shape. Class Vetor and Raster are two painters. We gonna bridge between the shape and
  painter so that a shape can draw itself in different ways.

  Now without the bridge we have to create different Painter classes for different Shapes. for example TringlePainter,
  RectanglePainter etc.  
*/

namespace DesignPatterns.Bridges;

enum Bridge { }

public interface IPainter
{
  void Render(string name);
}

public class VectorPainter : IPainter
{
  public void Render(string name)
  {
    Console.WriteLine($"Drawing {name} in lines");
  }
}

public class RasterPainter : IPainter
{
  public void Render(string name)
  {
    Console.WriteLine($"Drawing {name} in pixels");
  }
}

public abstract class Shape
{
  protected virtual string Name { get; set; } = "Shape";
  protected IPainter _painter; //By creating this IPainter property, now there is a bridge between Shape and Painters
  public Shape(IPainter painter)
  {
    _painter = painter;
  }
  public abstract void Draw();
}

public class Rectangle : Shape
{
  protected override string Name => "Rectangle";
  public Rectangle(IPainter painter) : base(painter) { }
  public override void Draw()
  {
    _painter.Render(Name);
  }
}

public class Tringle : Shape
{
  protected override string Name => "Tringle";
  public Tringle(IPainter painter) : base(painter) { }
  public override void Draw()
  {
    _painter.Render(Name);
  }
}