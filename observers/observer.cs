/*
  Demostration of Observer Pattern. Observer pattern has a simple problem to solve. Instead of pull data and check if a object
  state has changed or not, the object itself will notify to all it's observers that it has change and pass it's updated state. 

  Here we will create a Product Observable/Subject which will notify all the observers who register for it's availability.
*/

namespace DesignPatterns.Observers;

enum Dummy { }

interface IObservable<T>
{
  void Register(IObserver<T> observer);
  void Unregister(IObserver<T> observable);
  void Notify(object? sender, PropertyChangedEventArgs e);
}

interface IObserver<T>
{
  void update(T t);
}

class Product : INotifyPropertyChanged
{
  private int quantity;
  public int Quantity
  {
    get { return quantity; }
    set { quantity = value; OnPropertyChanged(nameof(Quantity)); }
  }
  public string Name { get; private set; }
  public Product(string name)
  {
    Name = name;
  }
  public event PropertyChangedEventHandler? PropertyChanged;
  private void OnPropertyChanged(string name)
  {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
  }
}

class ProductObservable : IObservable<Product>
{
  private Lazy<List<IObserver<Product>>> obs = new Lazy<List<IObserver<Product>>>();
  private List<IObserver<Product>> observers => obs.Value;
  public Product product { get; private set; }
  public ProductObservable(Product product)
  {
    this.product = product;
    product.PropertyChanged += Notify;
  }
  public void Notify(object? sender, PropertyChangedEventArgs e)
  {
    foreach (var observer in observers)
      observer.update(product);
  }
  public void Register(IObserver<Product> observer)
  {
    observers.Add(observer);
  }
  public void Unregister(IObserver<Product> observer)
  {
    observers.Remove(observer);
  }
}

class ProductObserver : IObserver<Product>
{
  public string Name { get; private set; }
  public ProductObserver(string name)
  {
    Name = name;
  }
  public void update(Product product)
  {
    if (product.Quantity > 0)
      Console.WriteLine($"Hello {Name}, {product.Name} is now available. Item left {product.Quantity}");
    else
      Console.WriteLine($"Hello {Name}, {product.Name} is out of stock.");
  }
}