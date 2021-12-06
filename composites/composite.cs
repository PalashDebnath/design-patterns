/*
  Demostration of Composite Design Pattern.

  If we consider the example below. The class CompositeSpecification allow to treat a group of Specifications same way as a single
  Specification. 
*/

namespace DesignPatterns.Composites;

public enum Color { RED, BLUE, GREEN, UNKNOWN }

public enum Size { SMALL, MEDIUM, LARGE, EXTRALARGE, UNKNOWN }

public class Product
{
  public string name;
  public Size size;
  public Color color;
  public Product(string name, Size size, Color color)
  {
    this.name = name ?? throw new ArgumentNullException(paramName: nameof(name));
    this.size = size;
    this.color = color;
  }

  public override string ToString()
  {
    return $"Name: {this.name}, Size: {this.size}, Color: {this.color}";
  }
}

interface ISpecification<T>
{
  bool IsSatisfied(T t);
}

class ColorSpecification : ISpecification<Product>
{
  Color color;
  public ColorSpecification(Color color)
  {
    this.color = color;
  }
  public bool IsSatisfied(Product t)
  {
    return t.color == color;
  }
}

class SizeSpecification : ISpecification<Product>
{
  Size size;
  public SizeSpecification(Size size)
  {
    this.size = size;
  }
  public bool IsSatisfied(Product t)
  {
    return t.size == size;
  }
}

// Created a Composite Specification to apply multiple specifications on a set of product
class CompositeSpecification : ISpecification<Product>
{
  public List<ISpecification<Product>> Specifications { get; set; }
  public CompositeSpecification()
  {
    Specifications = new List<ISpecification<Product>>();
  }
  public bool IsSatisfied(Product product)
  {
    return Specifications.All(spec => spec.IsSatisfied(product));
  }
}

interface IFilter<T>
{
  IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
}

class ProductFilter : IFilter<Product>
{
  public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
  {
    foreach (Product item in items)
    {
      if (spec.IsSatisfied(item)) yield return item;
    }
  }
}

