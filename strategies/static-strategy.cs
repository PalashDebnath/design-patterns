/*
  Demonstration of static strategy pattern. The concept is same only different is, client will make a sloution choice upfront
  at the compile time.
*/

namespace DesignPatterns.Strategies;

enum Strategy { }

interface IPaymentStrategy
{
  void Pay(decimal amount);
}

class CreditCardStrategy : IPaymentStrategy
{
  public void Pay(decimal amount)
  {
    Console.WriteLine($"Amount ${amount} paid via credit card.");
  }
}

class DebitCardStrategy : IPaymentStrategy
{
  public void Pay(decimal amount)
  {
    Console.WriteLine($"Amount ${amount} paid via credit card.");
  }
}

class Payment<T> where T : IPaymentStrategy, new()
{
  private IPaymentStrategy paymentStrategy = new T();
  public void Pay(decimal amount)
  {
    paymentStrategy.Pay(amount);
  }
}
