/*
  Demostration of decorator pattern.

  Here we have a base class Beverage. And two concrete class Expresso and Coffee derived from this abstruct base class.

  Now imagine we have to support every type of Expresso. Consider this example, here we may have below variants of Expresso
  #1 Expresso, #2 ExpressoWithSugar, #3 ExpressoWithCaramel, #4 ExpressoWithSugarAndCaramel to be implemented.
  Sooner we will be in a class hell, which is very hard to maintain. Here decorator pattern will help us to overcome the problem

  We implement a base Expresso type from Beverage and separate out all the add-ons. This add-on will wrap the base Expresso object
  and decorate it as per itself. Here we hace achived the same through IAdjunct interface and Sugar, Caramel classes.  
*/

namespace DesignPatterns.Decorators;

enum Decorators { }

public abstract class Beverage
{
  protected virtual string Description { get; set; } = "Beverage";
  protected virtual decimal Price { get; set; }
  public virtual void AddPrice(decimal price) { Price += price; }
  public virtual void AddDescription(string description) { Description += " + " + description; }

  public override string ToString() { return $"{Description}, Total Cost: {Price}"; }
}

public class Expresso : Beverage
{
  protected override string Description { get; set; } = "Expresso";
  public Expresso(decimal price) { this.Price = price; }
}

public class CafeCream : Beverage
{
  protected override string Description { get; set; } = "Cafe Cream";
  public CafeCream(decimal price) { this.Price = price; }
}

public interface IAdjunct<T>
{
  T AddWith(T t);
}

public class Sugar : IAdjunct<Beverage>
{
  public Beverage AddWith(Beverage beverage)
  {
    beverage.AddPrice(0.50m);
    beverage.AddDescription("Sugar");
    return beverage;
  }
}

public class Caramel : IAdjunct<Beverage>
{
  public Beverage AddWith(Beverage beverage)
  {
    beverage.AddPrice(1.75m);
    beverage.AddDescription("Caramel");
    return beverage;
  }
}