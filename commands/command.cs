/*
  Demostration of command pattern.
*/

namespace DesignPatterns.Commands;

enum Command { Withdraw, Deposit };

interface ICommand
{
  void Call();
  void Undo();
}

class Account
{
  public int Amount { get; private set; }
  internal bool WithDraw(int amount)
  {
    if (Amount >= amount)
    {
      Amount -= amount;
      Console.WriteLine($"Amount Withdrawal: ${amount}. Total balance after the transaction ${Amount}");
      return true;
    }
    return false;
  }
  internal bool Deposit(int amount)
  {
    Amount += amount;
    Console.WriteLine($"Amount Deposited: ${amount}. Total balance after the transaction ${Amount}");
    return true;
  }

  public override string ToString()
  {
    return $"Available balance: {Amount}";
  }
}

class AccountCommand : ICommand
{
  private Account _account;
  private Command _command;
  private int _amount;
  private bool _succeed;
  public AccountCommand(Account account, Command command, int amount)
  {
    _account = account;
    _command = command;
    _amount = amount;
  }
  public void Call()
  {
    switch (_command)
    {
      case Command.Deposit:
        _succeed = _account.Deposit(_amount);
        break;
      case Command.Withdraw:
        _succeed = _account.WithDraw(_amount);
        break;
      default:
        throw new ArgumentOutOfRangeException();
    }
  }

  public void Undo()
  {
    if (!this._succeed) return;
    switch (_command)
    {
      case Command.Deposit:
        _succeed = _account.WithDraw(_amount);
        break;
      case Command.Withdraw:
        _succeed = _account.Deposit(_amount);
        break;
      default:
        throw new ArgumentOutOfRangeException();
    }
  }
}


