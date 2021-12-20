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
  private Account account;
  private Command command;
  private int amount;
  private bool succeed;
  public AccountCommand(Account account, Command command, int amount)
  {
    this.account = account;
    this.command = command;
    this.amount = amount;
  }
  public void Call()
  {
    switch (command)
    {
      case Command.Deposit:
        succeed = account.Deposit(amount);
        break;
      case Command.Withdraw:
        succeed = account.WithDraw(amount);
        break;
      default:
        throw new ArgumentOutOfRangeException();
    }
  }

  public void Undo()
  {
    if (!this.succeed) return;
    switch (command)
    {
      case Command.Deposit:
        succeed = account.WithDraw(amount);
        break;
      case Command.Withdraw:
        succeed = account.Deposit(amount);
        break;
      default:
        throw new ArgumentOutOfRangeException();
    }
  }
}


