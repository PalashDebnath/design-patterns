/*
  Demonstration of State pattern. As per the State Desing pattern when the internal state of an object change, the operational
  behaviour of the object changes accordingly.

  Here we will implement an Account, while it's internal state change the operational behaviour also change. This is a good
  example of State Pattern. 
*/

namespace DesignPatterns.States;

enum Type { Red, Green, Silver, Gold }

interface IRange
{
  decimal lowerLimit { get; set; }
  decimal upperLimit { get; set; }
  bool IsStatisfied(decimal amount, out Type type);
}

class RedRange : IRange
{
  public decimal lowerLimit { get; set; } = -1000.0m;
  public decimal upperLimit { get; set; } = 0.0m;
  public bool IsStatisfied(decimal amount, out Type type)
  {
    type = Type.Red;
    return amount > lowerLimit && amount <= upperLimit;
  }
}

class GreenRange : IRange
{
  public decimal lowerLimit { get; set; } = 0.0m;
  public decimal upperLimit { get; set; } = 5000.0m;
  public bool IsStatisfied(decimal amount, out Type type)
  {
    type = Type.Green;
    return amount > lowerLimit && amount <= upperLimit;
  }
}

class SilverRange : IRange
{
  public decimal lowerLimit { get; set; } = 5000.0m;
  public decimal upperLimit { get; set; } = 10000.0m;
  public bool IsStatisfied(decimal amount, out Type type)
  {
    type = Type.Silver;
    return amount > lowerLimit && amount <= upperLimit;
  }
}

class GoldRange : IRange
{
  public decimal lowerLimit { get; set; } = 10000.0m;
  public decimal upperLimit { get; set; } = 100000.0m;
  public bool IsStatisfied(decimal amount, out Type type)
  {
    type = Type.Gold;
    return amount > lowerLimit && amount <= upperLimit;
  }
}

abstract class State
{
  protected decimal balance;
  protected decimal interest;
  private List<IRange> ranges = new List<IRange>() { new RedRange(), new GreenRange(), new SilverRange(), new GoldRange() };
  protected State(decimal balance)
  {
    this.balance = balance;
  }
  public abstract decimal PayInterest();
  public abstract decimal Deposit(decimal amount);
  public abstract decimal Withdraw(decimal amount);
  public State Check()
  {
    foreach (var range in ranges)
    {
      if (range.IsStatisfied(balance, out var type))
      {
        switch (type)
        {
          case Type.Red:
            return new Red(balance);
          case Type.Green:
            return new Green(balance);
          case Type.Silver:
            return new Silver(balance);
          default:
            return new Gold(balance);
        }
      }
    }
    return this;
  }
}

class Red : State
{
  private decimal serviceFee = 10.0m;
  private IRange range = new RedRange();
  public Red(decimal balance) : base(balance)
  {
    interest = 0.0m;
  }
  public override decimal PayInterest()
  {
    Console.WriteLine("No interest has been paid!");
    return balance;
  }
  public override decimal Deposit(decimal amount)
  {
    balance += amount;
    Check();
    return balance;
  }
  public override decimal Withdraw(decimal amount)
  {
    if (balance > range.lowerLimit) balance -= amount + serviceFee;
    else Console.WriteLine("No funds available for withdrawal!");
    Check();
    return balance;
  }
}

class Green : State
{
  public Green(decimal balance) : base(balance)
  {
    interest = 0.01m;
  }
  public override decimal PayInterest()
  {
    balance += interest * balance;
    Check();
    return balance;
  }
  public override decimal Deposit(decimal amount)
  {
    balance += amount;
    Check();
    return balance;
  }
  public override decimal Withdraw(decimal amount)
  {
    balance -= amount;
    Check();
    return balance;
  }
}

class Silver : State
{
  public Silver(decimal balance) : base(balance)
  {
    interest = 0.02m;
  }
  public override decimal PayInterest()
  {
    balance += interest * balance;
    Check();
    return balance;
  }
  public override decimal Deposit(decimal amount)
  {
    balance += amount;
    Check();
    return balance;
  }
  public override decimal Withdraw(decimal amount)
  {
    balance -= amount;
    Check();
    return balance;
  }
}

class Gold : State
{
  public Gold(decimal balance) : base(balance)
  {
    interest = 0.03m;
  }
  public override decimal PayInterest()
  {
    balance += interest * balance;
    Check();
    return balance;
  }
  public override decimal Deposit(decimal amount)
  {
    balance += amount;
    Check();
    return balance;
  }
  public override decimal Withdraw(decimal amount)
  {
    balance -= amount;
    Check();
    return balance;
  }
}

class Account
{
  private State state;
  public string Owner { get; private set; }
  public decimal Balance { get; private set; }
  public Account(string owner)
  {
    state = new Red(0.0m);
    Owner = owner;
  }
  public void PayInterest()
  {
    Balance = state.PayInterest();
    state = state.Check();
    Console.WriteLine($"State: {state.GetType().Name}, Balance: {Balance}");
  }
  public void Deposit(decimal amount)
  {
    Balance = state.Deposit(amount);
    state = state.Check();
    Console.WriteLine($"State: {state.GetType().Name}, Balance: {Balance}");
  }
  public void Withdraw(decimal amount)
  {
    Balance = state.Withdraw(amount);
    state = state.Check();
    Console.WriteLine($"State: {state.GetType().Name}, Balance: {Balance}");
  }
}