/*
  Demonstration of Adapter patterns. For demostration take two classes one is Point and other one is Line. The Point class has
  print function which print a single point into the console. So to print a line it will adapt to use the point class because a
  line is actually consist of several points.

  An adapter will take the line object as an input and structure it to a collection of point objects. which finally will be
  iterate through to print the whole line. 
*/

namespace DesignPatterns.Adapters;

enum ObjectAdapter { }

public interface IPrinter<T>
{
  void Print(T t);
}

public class Point
{
  public int X { get; private set; }
  public int Y { get; private set; }
  public Point(int x, int y)
  {
    X = x;
    Y = y;
  }

  public override string ToString()
  {
    return $"({X}, {Y})";
  }
}

public class PointPrinter : IPrinter<Point>
{
  public void Print(Point point)
  {
    Console.Write(".");
  }
}

public class Line
{
  public Point Start { get; private set; }
  public Point End { get; private set; }
  public Line(Point start, Point end)
  {
    Start = start;
    End = end;
  }

  public override string ToString()
  {
    return $"Line({Start}, {End})";
  }
}

public class PointPrinterAdapter : IAdapter<Line>
{
  //Created the end object directly inside.
  private PointPrinter pointPrinter = new PointPrinter();
  public void Adapt(Line line)
  {
    int dX = line.End.X - line.Start.X;
    int dY = line.End.Y - line.Start.Y;
    int D = 2 * dY - dX;
    int y = line.Start.Y;

    for (int x = line.Start.X; x <= line.End.X; x++)
    {
      pointPrinter.Print(new Point(x, y));
      if (D > 0)
      {
        y += 1;
        D = D - 2 * dX;
      }
      D = D + 2 * dY;
    }
  }
}