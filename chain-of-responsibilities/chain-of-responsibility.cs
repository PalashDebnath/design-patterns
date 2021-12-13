/*
  Demonstration of chain of resposibility pattern.

  Here we will consider a ATM withdrawal. where we implement the chain of responsibility pattern to handle any given withdrawal
  amount.
*/

namespace DesignPatterns.ChainOfResponsibilities;

enum Dummy { }

public abstract class Dispatcher
{
  protected Dispatcher? Next { get; set; }
  public void NextDispatcher(Dispatcher dispatcher)
  {
    Next = dispatcher;
  }
  public abstract void Dispatch(int amount);
}

public class TwoThousandRupeeNote : Dispatcher
{
  public override void Dispatch(int amount)
  {
    var number = amount / 2000;
    var nextAmount = amount % 2000;
    if (number > 0) Console.WriteLine($"Dispatched {number} two thousand rupee {(number == 1 ? "note" : "notes")}.");
    if (nextAmount > 0) Next?.Dispatch(nextAmount);
  }
}

public class FiveHundredRupeeNote : Dispatcher
{
  public override void Dispatch(int amount)
  {
    var number = amount / 500;
    var nextAmount = amount % 500;
    if (number > 0) Console.WriteLine($"Dispatched {number} five hundred rupee {(number == 1 ? "note" : "notes")}.");
    if (nextAmount > 0) Next?.Dispatch(nextAmount);
  }
}

public class TwoHundredRupeeNote : Dispatcher
{
  public override void Dispatch(int amount)
  {
    var number = amount / 200;
    var nextAmount = amount % 200;
    if (number > 0) Console.WriteLine($"Dispatched {number} two hundred rupee {(number == 1 ? "note" : "notes")}.");
    if (nextAmount > 0) Next?.Dispatch(nextAmount);
  }
}

public class OneHundredRupeeNote : Dispatcher
{
  public override void Dispatch(int amount)
  {
    var number = amount / 100;
    var nextAmount = amount % 100;
    if (number > 0) Console.WriteLine($"Dispatched {number} one hundred rupee {(number == 1 ? "note" : "notes")}.");
    if (nextAmount > 0) Next?.Dispatch(nextAmount);
  }
}

public class ATM
{
  private int _amount;
  private Dispatcher _dispatcher;
  public ATM(Dispatcher dispatcher)
  {
    _dispatcher = dispatcher;
  }
  public void WithDraw(int amount)
  {
    _amount = amount;
    _dispatcher.Dispatch(amount);
  }
}