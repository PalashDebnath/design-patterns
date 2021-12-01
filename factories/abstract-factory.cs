/*
  Design implementation of Abstract Factory pattern. Here in place of concreate class, provide a abstract class or interface
  signature.
*/

namespace DesignPatterns.Factories;

enum AbstractFactory { }

public interface IHotDrink
{
  void Consume();
}

// Internal access modifier will stop it use out of the assembly
internal class Tea : IHotDrink
{
  public void Consume()
  {
    Console.WriteLine("This is a nice tea, but I would prefer it with milk!");
  }
}

// Internal access modifier will stop it use out of the assembly
internal class Coffee : IHotDrink
{
  public void Consume()
  {
    Console.WriteLine("This is a nice coffee!");
  }
}

// This is an abstract factory which will return the abstract hot drink.
public interface IHotDrinkFactory
{
  IHotDrink Prepare(int amount);
}

internal class TeaFactory : IHotDrinkFactory
{
  public IHotDrink Prepare(int amount)
  {
    Console.WriteLine($"Put a tea bag, boil water, pour {amount} ml, add lemon, enjoy!");
    return new Tea();
  }
}

internal class CoffeeFactory : IHotDrinkFactory
{
  public IHotDrink Prepare(int amount)
  {
    Console.WriteLine($"Grind some beans, boil water, pour {amount} ml, add sugur and cream, enjoy!");
    return new Coffee();
  }
}

public class HotDrinkMachine
{
  // Used reflection. you can use dependency injection (ex: unity)
  private List<Tuple<string, IHotDrinkFactory>> factories;
  public HotDrinkMachine()
  {
    factories = new List<Tuple<string, IHotDrinkFactory>>();
    foreach (var type in typeof(HotDrinkMachine).Assembly.GetTypes())
    {
      if (typeof(IHotDrinkFactory).IsAssignableFrom(type) && !type.IsInterface)
      {
        var factory = Activator.CreateInstance(type) ?? throw new ArgumentNullException();
        factories.Add(
          Tuple.Create<string, IHotDrinkFactory>(
            type.Name.Replace("Factory", string.Empty), (IHotDrinkFactory)factory
          )
        );
      }
    }
  }
  public IHotDrink MakeDrink()
  {
    Console.WriteLine("Available drinks:");
    for (int index = 0; index < factories.Count; index++)
    {
      Console.WriteLine($"{index}: {factories[index].Item1} (press {index} to prepare {factories[index].Item1})");
    }
    // This loop will keep on iterating until it is a valid input
    while (true)
    {
      if (int.TryParse(Console.ReadLine(), out int i) && i >= 0 && i < factories.Count)
      {
        Console.WriteLine("Specify amount:");
        if (int.TryParse(Console.ReadLine(), out int amount) && amount > 0)
        {
          return factories[i].Item2.Prepare(amount);
        }
      }
      Console.WriteLine("Wrong entry, choose a drink again!");
    }
  }
}