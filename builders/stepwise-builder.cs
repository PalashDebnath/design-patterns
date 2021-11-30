/*
  Implement a builder pattern where restrict the execution of steps or rather force the method call in a specific order
*/

namespace DesignPatterns.Builders;

public enum CarType { SEDAN, CROSSOVER }

public interface ICar
{
  Car Build();
}

public interface IWeelSize
{
  ICar HasWeelSize(int size);
}

public interface ICarType
{
  IWeelSize OfType(CarType type);
}

public class Car
{
  public CarType Type { get; set; }
  public int WheelSize { get; set; }

  public override string ToString()
  {
    return $"car type: {Type}, wheel size: {WheelSize}";
  }
}

public class CarBuilder
{
  public ICarType SetCar()
  {
    return new Builder();
  }
  private class Builder : ICarType, IWeelSize, ICar
  {
    Car car = new Car();
    public IWeelSize OfType(CarType type)
    {
      car.Type = type;
      return this;
    }
    public ICar HasWeelSize(int size)
    {
      switch (car.Type)
      {
        case CarType.CROSSOVER when size < 17 || size > 20:
        case CarType.SEDAN when size < 15 || size > 17:
          throw new ArgumentException($"Wrong size of wheel for {car.Type}.");
      }
      car.WheelSize = size;
      return this;
    }
    public Car Build()
    {
      return car;
    }
  }
}
