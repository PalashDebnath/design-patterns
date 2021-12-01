/*
  Implement a builder pattern which will store a bunch of actions and operate on the target object one after another.
*/

namespace DesignPatterns.Builders;

public enum DrinkType { HOT, COLD }

public enum DrinkSize { SMALL, MEDIUM, LARGE }

public class Drink
{
  public string Name { get; set; } = string.Empty;
  public DrinkType Type { get; set; }
  public DrinkSize Size { get; set; }

  public override string ToString()
  {
    return $"Drink name: {Name}, Type: {Type}, Size: {Size}";
  }
}

//Access modifier sealed with help to bind with open-close principle
public sealed class DrinkBuilder
{
  private readonly List<Action<Drink>> _actions;

  public DrinkBuilder()
  {
    _actions = new List<Action<Drink>>();
  }
  public DrinkBuilder Start(string name)
  {
    _actions.Add(d => d.Name = name);
    return this;
  }
  public DrinkBuilder Type(DrinkType type)
  {
    _actions.Add(d => d.Type = type);
    return this;
  }
  public DrinkBuilder Size(DrinkSize size)
  {
    _actions.Add(d => d.Size = size);
    return this;
  }
  public Drink Prepare()
  {
    Drink drink = new Drink();
    _actions.ForEach(action => action(drink));
    return drink;
  }
}