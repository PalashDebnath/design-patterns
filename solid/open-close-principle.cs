/*
  Demonstration of open close principle(OCP), as per OCP a class is only open for extension but close for modification.

  Here the VProductFilter is violating open close principle. To support new filter, it needs to be modified. Example: to add
  a new filter BySizeAndColor(), a new method have to implement inside the VProductFilter class.

  On the other hand ProductFilter class follows open close principle by implementing the interface. The ProductFilter to not
  need to modify to filter by new specification. Just create new specification and pass it in ProductFilter object
*/
namespace DesignPatterns.OpenClosePrinciple;

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

public class VProductFilter
{
  public IEnumerable<Product> BySize(IEnumerable<Product> products, Size size)
  {
    foreach (Product product in products)
    {
      if (product.size == size)
      {
        yield return product;
      }
    }
  }

  public IEnumerable<Product> ByColor(IEnumerable<Product> products, Color color)
  {
    foreach (Product product in products)
    {
      if (product.color == color)
      {
        yield return product;
      }
    }
  }
}

public interface ISpecification<T>
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

public interface IFilter<T>
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