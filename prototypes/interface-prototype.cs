/*
  Demostration of prototype design pattern using explicit interface approach
*/

namespace DesignPatterns.prototypes;

enum Data { }

public interface IDeepCloneable<T> where T : class
{
  T DeepClone();
}

// not have to inherit from IDeepCloneable because all properties are value type.
// hence always get a new copy of those properties.
public class Point
{
  public int X { get; set; }
  public int Y { get; set; }
  public Point(int x, int y)
  {
    X = x;
    Y = y;
  }

  public override string ToString()
  {
    return $"X: {X}, Y: {Y}";
  }
}

public class Line : IDeepCloneable<Line>
{
  public Point Start { get; set; }
  public Point End { get; set; }
  public Line(Point start, Point end)
  {
    Start = start;
    End = end;
  }
  public Line DeepClone()
  {
    return new Line(new Point(Start.X, Start.Y), new Point(End.X, End.Y));
  }

  public override string ToString()
  {
    return $"Start: {{{Start}}}, End: {{{End}}}";
  }
}

