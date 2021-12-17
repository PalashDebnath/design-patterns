/*
  Demonstration of Null-Object Patterns. This is not a Gang of Four design pattern

  
*/

namespace DesignPatterns.NullObjects;

enum NullObject { }

interface ILog
{
  void Info(string message);
  void Warn(string message);
  void Error(string message);
}

// Console Log class
class CLog : ILog
{
  public void Error(string message)
  {
    Console.WriteLine($"ERROR: {message}");
  }
  public void Info(string message)
  {
    Console.WriteLine($"INFO: {message}"); ;
  }
  public void Warn(string message)
  {
    Console.WriteLine($"WARN: {message}"); ;
  }
}

// Null Log class
class NLog : ILog
{
  public void Error(string message) { }
  public void Info(string message) { }
  public void Warn(string message) { }
}

// This singleton will help to create only one instance of the null log object because to create multiple of the same has no
// purpose. Because it is not doing anything.
class SNLog : ILog
{
  private SNLog() { }
  private static Lazy<SNLog> _instance = new Lazy<SNLog>(() => new SNLog());
  public static ILog Instance = _instance.Value;
  public void Error(string message) { }
  public void Info(string message) { }
  public void Warn(string message) { }
}

// If you see over here, it is clearly stated you have to pass a ILog object to create a bank account. But if you do not want to
// log or use that object. on that case you can pass a null object into the constructor which will do nothing. 
class BankAccount
{
  public decimal Balance { get; private set; }
  private ILog _log;
  public BankAccount(ILog log) { _log = log; }
  public void Deposit(decimal value)
  {
    Balance += value;
    _log.Info($"Deposited ${value} into your account.");
  }
  public void Withdraw(decimal value)
  {
    Balance += value;
    _log.Info($"Withdrawal ${value} from your account.");
  }
}