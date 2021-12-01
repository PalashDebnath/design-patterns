/*
  Design implementation of Factory Method. This is another Creational patterns which help to create bulk object,
  unlike builder pattern which create a single object piece by piece

  Here we have a use case where we have to support Cartesian and Polar points. As you can't overload constructor with same
  signature it is difficult to maintain both. Hence we use a Factory Method to restrict the creation of the object internally
*/

namespace DesignPatterns.Factories;

enum Factory { }

public class Point
{
  private double _xValue, _yValue;
  private Point(double x, double y) { _xValue = x; _yValue = y; }

  public override string ToString()
  {
    return $"X: {_xValue}, Y: {_yValue}";
  }
  public static class Factory
  {
    public static Point Cartesian(double x, double y)
    {
      return new Point(x, y);
    }
    public static Point Polar(double radius, double theta)
    {
      return new Point(radius * Math.Cos(theta), theta * Math.Sin(theta));
    }
  }
}